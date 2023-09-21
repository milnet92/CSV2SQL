using CSV2SQL.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSV2SQL.Forms
{
    public partial class ConnectionDetails : Form
    {
        public readonly int ConnectionId;

        public ConnectionDetails(int connectionId)
        {
            this.Icon = CSV2SQL.Properties.Resources.banana;
            ConnectionId = connectionId;

            InitializeComponent();
            LoadConnectionDetails();
        }

        public void LoadConnectionDetails()
        {
            var connection = DBConnectionManager.Instance.GetConnectionById(ConnectionId);

            tbServer.Text = connection.Server;
            tbDatabase.Text = connection.DataBase;
            tbTimeout.Text = "30"; // TODO: connection.SqlConnection.ConnectionTimeout.ToString();
            tbConnectionString.Text = connection.SecureConnectionString;
            tbErrorMessage.Text = connection.Status == Enums.DBConnectionStatus.NotConnected ? "" : connection.ErrorMessage;

            tbStat.Text = connection.Status.ToString();
        }
    }
}
