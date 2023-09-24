using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CSV2SQL.Core;
using CSV2SQL.Core.Database;

namespace CSV2SQL.Forms
{
    public partial class FileLoadOptionsMultipleDialog : Form
    {
        public Dictionary<int, FileLoadOptions> Options = new Dictionary<int, FileLoadOptions>();

        FileLoadOptions defaultOptions;
        List<int> connectionIds;
        public FileLoadOptionsMultipleDialog(List<int> connectionIds, FileLoadOptions defaultOptions)
        {
            this.Icon = CSV2SQL.Properties.Resources.banana;

            DialogResult = DialogResult.Cancel;

            this.defaultOptions = defaultOptions;
            this.connectionIds = connectionIds;

            InitializeComponent();

            this.Load += FileLoadOptionsMultipleDialog_Load;
        }

        private void FileLoadOptionsMultipleDialog_Load(object sender, EventArgs e)
        {
            // Initialize comobox
            connectionIds.ForEach(c =>
            {
                comboConnection.Items.Add(new ConnectionDropDownItem(c));
                Options[c] = (FileLoadOptions)defaultOptions.Clone();
            });

            comboConnection.SelectedIndexChanged += ConComboBox_SelectedIndexChanged;
            comboConnection.SelectedIndex = 0;
        }

        private void ConComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = (ConnectionDropDownItem)comboConnection.SelectedItem;

            tbTableName.Text = Options[selected.ConnectionId].TableName;
            tbSchema.Text = Options[selected.ConnectionId].Schema;
            tbSeparator.Text = Options[selected.ConnectionId].Separator;
            cbFirstRowHeader.Checked = Options[selected.ConnectionId].FirstRowHeader;
            cbEnableScripting.Checked = Options[selected.ConnectionId].EnableScripts;

            var con = DBConnectionManager.Instance.GetConnectionById(selected.ConnectionId);
            tbServer.Text = con.Server;
            tbDatabase.Text = con.DataBase;
        }

        private void cbFirstRowHeader_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var op in Options)
            {
                op.Value.FirstRowHeader = cbFirstRowHeader.Checked;
            }
        }

        private void btAccept_Click(object sender, EventArgs e)
        {
            if (this.ValidateOptions())
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidateOptions()
        {
            foreach (var option in Options)
            {
                var optionConnection = DBConnectionManager.Instance.GetConnectionById(option.Key);

                // Check the for duplicated names for the same server
                foreach (var searchOption in Options)
                {
                    if (option.Key != searchOption.Key && option.Value.TableName == searchOption.Value.TableName)
                    {
                        var searchConnection = DBConnectionManager.Instance.GetConnectionById(searchOption.Key);

                        if (optionConnection.Server == searchConnection.Server)
                        {
                            MessageBox.Show("Connections with the same server cannot have the same Table name. " +
                                "Please specify different table names.", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }

                if (option.Value.Schema == "" || option.Value.Separator == "" || option.Value.TableName == "")
                {
                    MessageBox.Show($"Some of the parameters for connection {optionConnection.Server}.{optionConnection.DataBase} are missing.",
                        "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbTableName_TextChanged(object sender, EventArgs e)
        {
            var selected = (ConnectionDropDownItem)comboConnection.SelectedItem;
            Options[selected.ConnectionId].TableName = tbTableName.Text;
        }

        private void tbSeparator_TextChanged(object sender, EventArgs e)
        {
            foreach (var op in Options)
            {
                op.Value.Separator = tbSeparator.Text;
            }
        }

        private void tbSchema_TextChanged(object sender, EventArgs e)
        {
            var selected = (ConnectionDropDownItem)comboConnection.SelectedItem;
            Options[selected.ConnectionId].Schema = tbSchema.Text;
        }

        private void cbEnableScripting_CheckedChanged(object sender, EventArgs e)
        {
            var selected = (ConnectionDropDownItem)comboConnection.SelectedItem;
            Options[selected.ConnectionId].EnableScripts = cbEnableScripting.Checked;
        }
    }

    public class ConnectionDropDownItem
    {
        public int ConnectionId;

        public string Name
        {
            get
            {
                var con = DBConnectionManager.Instance.GetConnectionById(ConnectionId);

                return $"{con.Server}.{con.DataBase}";
            }
        }

        public ConnectionDropDownItem(int connectionId)
        {
            ConnectionId = connectionId;
        }
    }
}
