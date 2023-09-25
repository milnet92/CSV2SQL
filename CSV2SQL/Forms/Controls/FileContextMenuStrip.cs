using CSV2SQL.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.IO;
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

            var selectedFileTable = GetSelectedFileItem().FileTable;

            if (selectedFileTable.IsReadyToUse)
            {
                if (selectedFileTable.FileLoadOptions.CreatePrimaryKey)
                {
                    var menu = AddSubmenu("Create script", CSV2SQL.Properties.Resources.script);

                    AddItemAction(menu, "Count", CountScript);
                    AddItemAction(menu, "Print", PrintScript);
                    AddItemAction(menu, "Update", UpdateScript);
                }

                AddItemAction("Edit metadata", ViewEditMetadata, CSV2SQL.Properties.Resources.edit);
                AddItemAction("Reload", Reload, CSV2SQL.Properties.Resources.reload);
                AddItemAction("Delete", Delete, CSV2SQL.Properties.Resources.remove);
                AddItemAction("Open file", OpenFile, CSV2SQL.Properties.Resources.open);
            }
        }
        private void CreateScript(string sourceCode)
        {
            new ScriptForm(GetSelectedFileItem().FileTable, sourceCode).ShowDialog();
        }

        private void CountScript(object sender, EventArgs e)
        {
            string sourceCode = File.ReadAllText("Resources/Templates/count.ori");
            sourceCode = sourceCode.Replace("%temptable%", GetSelectedFileItem().FileTable.TableName);

            CreateScript(sourceCode);
        }

        private void PrintScript(object sender, EventArgs e)
        {
            string sourceCode = File.ReadAllText("Resources/Templates/print.ori");
            sourceCode = sourceCode.Replace("%temptable%", GetSelectedFileItem().FileTable.TableName);

            CreateScript(sourceCode);
        }

        private void UpdateScript(object sender, EventArgs e)
        {
            FileTable table = GetSelectedFileItem().FileTable;
            string sourceCode = File.ReadAllText("Resources/Templates/update.ori");
            sourceCode = sourceCode.Replace("%temptable%", table.TableName); ;

            StringBuilder stringBuilder = new StringBuilder();
            foreach (var column in table.Columns)
            {
                stringBuilder.AppendLine($"\t\t// record.{column.Name} = {GetDefaultValueFromType(column.Type)}");
            }

            sourceCode = sourceCode.Replace("%update%", stringBuilder.ToString());

            CreateScript(sourceCode);
        }

        private string GetDefaultValueFromType(Type type)
        {
            if (type == typeof(string) || type == typeof(DateTime))
                return "\"\"";
            else
                return "0";
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
