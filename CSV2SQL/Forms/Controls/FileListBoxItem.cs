using CSV2SQL.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSV2SQL.Forms.Controls
{
    public class FileListBoxItem : CustomListBoxItem
    {
        public readonly FileTable FileTable;

        public FileListBoxItem(FileTable fileTable, string path, string tableName) : base(path, tableName, CSV2SQL.Properties.Resources.sqlfile)
        {
            this.FileTable = fileTable;
        }

        public static string FormatDisplayPath(string path)
        {
            string directoryPath = path;
            string[] parts = directoryPath.Split(new char[] { '\\' });

            if (parts.Length > 1)
            {
                directoryPath = "...";
                for (int i = parts.Length - 2;  i <= parts.Length - 1; i++)
                {
                    directoryPath += "\\" + parts[i];
                }
            }

            return directoryPath;
        }

        public override void DrawForListBox(ListBox listBox, DrawItemEventArgs e)
        {
            base.DrawForListBox(listBox, e);

            Font regFont = new Font(e.Font.FontFamily, e.Font.Size * 0.65f);

            TextRenderer.DrawText(e.Graphics, $"{FileTable.TotalRows} registers \n  " +
                (FileTable.IsReadyToUse ? "" : "(Loading) ") +
                $"{DBConnectionManager.Instance.GetConnectionById(FileTable.ConnectionId).DataBase}", regFont, e.Bounds, FontColor, TextFormatFlags.Right);
        }
    }
}
