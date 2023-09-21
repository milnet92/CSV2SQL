using CSV2SQL.Core;
using CSV2SQL.Core.Database;
using CSV2SQL.Forms.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Shapes;

namespace CSV2SQL.Forms
{
    public partial class Main : Form
    {
        // Custom menu strips used for Connection list box and File list box
        private ConnectionsContextMenuStrip lbConnectionsContextMenu;
        private FileContextMenuStrip lbFileContextMenu;

        public Main()
        {
            this.Icon = CSV2SQL.Properties.Resources.banana;

            InitializeComponent();

            // Change window title
            this.Text = $"CSV2SQL - {System.Reflection.Assembly.GetExecutingAssembly().GetName().Version}";

            // Subscribe to Instance
            Log.MessageSent += Log_MessageSent;

            DBConnectionManager.Instance.Subscribe(lbConnections);
            FileTableManager.Instance.Subscribe(lbFiles);
            FileTableManager.Instance.Subscribe(mainTab);
        }

        private void Log_MessageSent(object sender, LogEventArgs e)
        {
            lblLog.Invoke(new MethodInvoker(() =>
           {
               if (e.LogLevel == Log.LogLevel.Error)
                   MessageDialog.ShowMessage("Error while importing file", e.Message, e.Details);

               lblLog.Text = e.Message;
               lblLog.Refresh();
           }));
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            PostLoad();
        }
        private void PostLoad()
        {
            // Load saved connections 
            _ = DBConnectionManager.Instance.LoadAsync();

            lbConnectionsContextMenu = new ConnectionsContextMenuStrip(lbConnections);
            lbFileContextMenu = new FileContextMenuStrip(lbFiles);

            // Try to select first connection
            if (lbConnections.Items.Count != 0) lbConnections.SelectedIndex = 0;
        }

        #region Connections list box
        private void lbConnections_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lbConnections.SelectedIndex != -1)
            {
                ConnectionListBoxItem selectedItem = (ConnectionListBoxItem)lbConnections.SelectedItem;
                new ConnectionDetails(selectedItem.ConnectionId).ShowDialog();
            }
        }
        private void lbConnections_Resize(object sender, EventArgs e)
        {
            // Force redraw of all items due to custom drawing mode
            lbConnections.Invalidate();
        }
        #endregion

        #region Files list box
        private void lbFiles_Resize(object sender, EventArgs e)
        {
            // Force redraw of all items due to custom drawing methods
            lbFiles.Invalidate();
        }
        private void lbFiles_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.All : DragDropEffects.None;
        }
        private void lbFiles_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;

            string[] data = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (data.Length == 0) return;

            // Validate selected connection
            
            if (lbConnections.SelectedItem == null)
            {
                MessageBox.Show("Please, select a connection", "File error", MessageBoxButtons.OK);
                return;
            }

            try
            {

                List<int> connectionIds = new List<int>();

                foreach (ConnectionListBoxItem item in lbConnections.SelectedItems)
                {
                    connectionIds.Add(item.ConnectionId);
                }

                AddFiles(connectionIds, data);
            }
            catch (Exception ex)
            {
                Log.AddMessage("Error while loading file", ex.Message, Log.LogLevel.Error);
            }
        }

        private void AddFiles(List<int> connectionIds, string[] paths)
        {
            foreach (string path in paths)
            {
                // Is a directory
                if (Directory.Exists(path))
                {
                    foreach (var file in Directory.GetFiles(path))
                    {
                        AddFile(connectionIds, file);
                    }
                }
                else
                {
                    AddFile(connectionIds, path);
                }
            }
        }

        private void AddFile(List<int> connectionIds, string path)
        {
            HashSet<string> serversToRemove = new HashSet<string>();

            // Check if it is already created in 
            foreach (int id in connectionIds)
            {
                var connection = DBConnectionManager.Instance.GetConnectionById(id);

                // Check if file is already imported in the same connection
                if (FileTableManager.IsFileImportedByServer(path, connection.Server))
                {
                    serversToRemove.Add(connection.Server);
                }
            }

            if (serversToRemove.Count > 0 &&
                (MessageBox.Show($"File {path} is already imported in some of the selected servers, do you want to import again?", "Duplicated file",
                    MessageBoxButtons.YesNo) == DialogResult.No))
            {
                return;
            }

            var options = GetOptions(connectionIds, path);

            if (options != null)
            {
                foreach (string server in serversToRemove)
                {
                    FileTableManager.Instance.RemoveByServer(path, server);
                }

                foreach (int connectionId in connectionIds)
                {
                    FileTableManager.Instance.Add(connectionId, path, options[connectionId]);
                }
            }
        }

        private void lbFiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lbFiles.SelectedIndex != -1)
            {
                FileListBoxItem item = (FileListBoxItem)lbFiles.SelectedItem;
                new ViewEditFileTableMetadata(item.FileTable, true).ShowDialog();
            }
        }
        #endregion

        private void btSettings_Click(object sender, EventArgs e)
        {
            new ParametersDialog().ShowDialog();
        }

        private Dictionary<int, FileLoadOptions> GetOptions(List<int> connectionIds, string path)
        {
            Dictionary<int, FileLoadOptions> retOptions = new Dictionary<int, FileLoadOptions>();
            bool isOk = false;

            FileLoadOptions options = FileLoadOptions.Default;
            options.TableName = FileTableManager.GetTableNameFromPath(path);

            if (FileLoadOptions.ShouldShowOptionsDialog(connectionIds))
            {
                if (connectionIds.Count == 1)
                {
                    var dialog = new FileLoadOptionsDefaultDialog(connectionIds[0], options);

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        retOptions[connectionIds[0]] = dialog.Options;
                        isOk = true;
                    }
                }
                else
                {
                    var dialog = new FileLoadOptionsMultipleDialog(connectionIds, options);

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        retOptions = dialog.Options;
                        isOk = true;
                    }
                }
            }
            else
            {
                // Set the tablename based on the server
                Dictionary<string, int> serversVisitted = new Dictionary<string, int>();
                foreach (int id in connectionIds)
                {
                    var connection = DBConnectionManager.Instance.GetConnectionById(id);
                    int alreadyCreated;

                    string tableName = FileTableManager.GetTableNameFromPath(path);

                    if (serversVisitted.TryGetValue(connection.Server, out alreadyCreated))
                    {
                        tableName += "_" + alreadyCreated.ToString();

                        serversVisitted[connection.Server]++;
                    }
                    else
                    {
                        serversVisitted.Add(connection.Server, 1);
                    }

                    FileLoadOptions option = options.Clone() as FileLoadOptions;
                    option.TableName = tableName;

                    retOptions[id] = option;
                }

                isOk = true;
            }

            return isOk ? retOptions : null;
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            new ParametersDialog().ShowDialog();
        }
    }
}
