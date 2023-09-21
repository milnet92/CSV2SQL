using CSV2SQL.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSV2SQL.Forms.Controls
{
    public class FileContextMenuStrip : ListBoxContextMenuStrip
    {
        public FileContextMenuStrip(ListBox listBox) : base(listBox)
        {
        }

        protected override void UpdateItemActions()
        {
            base.UpdateItemActions();

            if (GetSelectedFileItem().FileTable.IsReadyToUse)
            {
                AddItemAction("Create script", CreateScript);
                AddItemAction("Edit metadata", ViewEditMetadata);
                AddItemAction("Reload", Reload);
                AddItemAction("Delete", Delete);
                AddItemAction("Open file", OpenFile);
            }
        }
        public void CreateScript(object sender, EventArgs e)
        {
            new ScriptForm(GetSelectedFileItem().FileTable).ShowDialog();
        }

        public void OpenFile(object sender, EventArgs e)
        {
            Process.Start(GetSelectedFileItem().FileTable.Path);
        }

        public void ViewEditMetadata(object sender, EventArgs e)
        {
            new ViewEditFileTableMetadata(GetSelectedFileItem().FileTable, true).ShowDialog();
        }

        public void Delete(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete this file table?", "Delete file table", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var fileTable = GetSelectedFileItem().FileTable;
                FileTableManager.Instance.Remove(fileTable.Path, fileTable.ConnectionId);
            }
        }

        public void Reload(object sender, EventArgs e)
        {
            if (MessageBox.Show("This action will delete and recreate the table maintaining the options specified. Do you want to continue?", 
                "Reload file table",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var fileTable = GetSelectedFileItem().FileTable;
                FileTableManager.Instance.Remove(fileTable.Path, fileTable.ConnectionId);
                FileTableManager.Instance.Add(fileTable.ConnectionId, fileTable.Path, fileTable.FileLoadOptions);
            }
        }

        private FileListBoxItem GetSelectedFileItem()
        {
            return (FileListBoxItem)GetSelectedItem();
        }
    }
}
