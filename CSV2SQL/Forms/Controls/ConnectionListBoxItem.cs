using CSV2SQL.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSV2SQL.Forms.Controls
{
    public class ConnectionListBoxItem : CustomListBoxItem
    {
        public int ConnectionId { get; set; }

        public ConnectionListBoxItem(int connectionId, string server, string database) : base(server, database, CSV2SQL.Properties.Resources.dbIcon)
        {
            ConnectionId = connectionId;
        }

        public override void DrawForListBox(ListBox listBox, DrawItemEventArgs e)
        {
            var connection = DBConnectionManager.Instance.GetConnectionById(ConnectionId);

            this.Text = connection.DataBase;
            this.Title = connection.Server;

            base.DrawForListBox(listBox, e);

            Brush brush = null;

            switch (connection.Status)
            {
                case Enums.DBConnectionStatus.Connected: brush = Brushes.Green; break;
                case Enums.DBConnectionStatus.NotConnected: brush = Brushes.Red; break;
                case Enums.DBConnectionStatus.Pending: brush = Brushes.Yellow; break;
            }

            e.Graphics.FillRectangle(brush, new Rectangle(e.Bounds.X + e.Bounds.Width - 10, e.Bounds.Y, 10, e.Bounds.Height));
        }
    }
}
