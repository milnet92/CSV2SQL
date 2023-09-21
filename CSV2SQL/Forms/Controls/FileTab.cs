using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSV2SQL.Core;
using System.Reflection;

namespace CSV2SQL.Forms.Controls
{
    public partial class FileTab : CustomTab, IObserver<FileTableMetadataObserverContract>
    {
        public FileTab()
        {
        }

        public void OnCompleted()
        {
            // No-Op
        }

        public void OnError(Exception error)
        {
            // No-Op
        }

        public void OnNext(FileTableMetadataObserverContract contract)
        {
            switch (contract.NotifyActionType)
            {
                case Enums.NotifyActionType.Add:
                    CreatePage(contract);
                    break;
                case Enums.NotifyActionType.Update:
                    {
                        var page = GetFileTabPageFromFileTable(contract.FileTable);
                        
                        if (contract.FileTable.IsReadyToUse)
                        {
                            this.SetupGridView(page, new DataView(contract.FileTable.DataTable));
                        }

                        page.CanBeClosed = contract.FileTable.IsReadyToUse;
                        page.Progress = (double)contract.FileTable.NumRows / contract.FileTable.TotalRows;

                        page.UpdateText();
                        page.Invalidate();
                    }
                    break;
                case Enums.NotifyActionType.Delete:
                    {
                        var page = GetFileTabPageFromFileTable(contract.FileTable);
                        this.Invoke(new MethodInvoker(() =>
                        {
                            this.TabPages.Remove(page);
                        }));
                    }
                    break;
            }
        }

        private FileTabPage GetFileTabPageFromFileTable(FileTable fileTable)
        {
            foreach (FileTabPage page in this.TabPages)
            {
                if (page.FileTable == fileTable) return page;
            }

            return null;
        }


        // Setup page
        public void CreatePage(FileTableMetadataObserverContract contract)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                var tabPage = new FileTabPage(contract.FileTable);
                this.AddTab(tabPage);
                tabPage.UpdateText();
            }));
        }

        // Setup grid view for tab
        public void SetupGridView(FileTabPage page, DataView dataView)
        {
            page.Invoke(new MethodInvoker(() =>
            {
                DataGridView dataGridView = new DataGridView()
                {
                    Name = "dataGridView",
                    DataSource = dataView,
                    Dock = DockStyle.Fill,
                    AllowUserToDeleteRows = false,
                    AllowUserToAddRows = false,
                    AllowUserToOrderColumns = false,
                    AllowUserToResizeColumns = true,
                    AllowUserToResizeRows = false,
                    ReadOnly = true
                };

                typeof(Control).InvokeMember("DoubleBuffered",
                      BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                      null, dataGridView, new object[] { true });

                page.Controls.Add(dataGridView);
            }));
        }
    }
}
