using CSV2SQL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSV2SQL.Forms.Controls
{
    public class ConnectionsContextMenuStrip : ListBoxContextMenuStrip
    {
        public int CurrentConnectionId
        {
            get
            {
                if (SelectedIndex == -1) return -1;
                return ((ConnectionListBoxItem)this.GetSelectedItem()).ConnectionId;
            }
        }

        public ConnectionsContextMenuStrip(ListBox listBox) : base(listBox)
        {
        }

        protected override void UpdateNoItemActions()
        {
            base.UpdateNoItemActions();

            AddNoItemAction("Add", Add);
        }

        protected override void UpdateItemActions()
        {
            base.UpdateItemActions();

            var connection = DBConnectionManager.Instance.GetConnectionById(CurrentConnectionId);

            if (connection.Status != Enums.DBConnectionStatus.Pending)
            {
                AddItemAction("Edit", Edit);
                AddItemAction("Delete", Delete);
            }
        }

        public void Edit(object sender, EventArgs e)
        {
            if (AddEditConnection.ShowAsDialog(CurrentConnectionId))
                DBConnectionManager.Instance.Save();
        }

        public void Delete(object sender, EventArgs e)
        {
            var connection = DBConnectionManager.Instance.GetConnectionById(CurrentConnectionId);
            string message = $"Do you want to delete connection { connection.Server} - { connection.DataBase}?" + Environment.NewLine + Environment.NewLine;

            var fileTables = FileTableManager.GetFileTablesByConnectionId(CurrentConnectionId);

            if (fileTables.Count > 0)
            {
                message += "The following files will also be deleted: " + Environment.NewLine + Environment.NewLine;

                foreach (var fileTable in fileTables)
                {
                    message += "     " + fileTable.TableName + Environment.NewLine;
                }
            }

            if (MessageBox.Show(message, "Delete connection", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DBConnectionManager.Instance.Remove(CurrentConnectionId);
                DBConnectionManager.Instance.Save();
            }
        }

        public void Add(object sender, EventArgs e)
        {
            if (AddEditConnection.ShowAsDialog())
                DBConnectionManager.Instance.Save();
        }
    }
}
