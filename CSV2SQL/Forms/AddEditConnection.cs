using CSV2SQL.Core;
using CSV2SQL.Core.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSV2SQL.Forms
{
    public partial class AddEditConnection : Form
    {
        private const string DEF_PASSW = "*******";

        private const string WIN_AUTH = "Windows authentication";
        private const string SQL_AUTH = "SQL authentication";

        SecureString password = null;
        public int ConnectionId { get; set; }

        public bool IsOk { get; set; }

        public AddEditConnection(int connectionId = -1)
        {
            this.Icon = CSV2SQL.Properties.Resources.banana;
            ConnectionId = connectionId;
            InitializeComponent();

            Initialize();

            if (connectionId != -1)
            { 
                var con = DBConnectionManager.Instance.GetConnectionById(connectionId);
                tbServer.Text = con.Server;
                tbDatabase.Text = con.DataBase;
                tbUserName.Text = con.UserName;
                if (con.Password != null) tbPassword.Text = DEF_PASSW;
                password = con.Password;

                cbAuthenticationMethod.SelectedItem = AuthenticationMethodToString(con.AuthenticationMethod);
                cbAuthenticationMethod_SelectedIndexChanged(cbAuthenticationMethod, new EventArgs());
            }

            this.Text = connectionId == -1 ? "Add connection" : "Edit connection";
        }

        private void Initialize()
        {
            cbAuthenticationMethod.Items.Add(WIN_AUTH);
            cbAuthenticationMethod.Items.Add(SQL_AUTH);

            cbAuthenticationMethod.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbServer.Text) || string.IsNullOrEmpty(tbDatabase.Text))
            {
                MessageBox.Show("Server and database must be informed", "Edit / Create connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DBConnectionManager.Instance.AddOrEditAsync(ConnectionId, tbServer.Text, tbDatabase.Text,
                StringToAuthenticationMethod((string)cbAuthenticationMethod.SelectedItem),
                tbUserName.Text,
                tbPassword.Text != DEF_PASSW ? SecurityHelper.StringToSecureString(tbPassword.Text) : password,
                true);

            this.Close();

            IsOk = true;
        }

        private Enums.AuthenticationMethod StringToAuthenticationMethod(string str)
        {
            switch (str)
            {
                case WIN_AUTH: return Enums.AuthenticationMethod.Windows;
                case SQL_AUTH: return Enums.AuthenticationMethod.SQL;
                default: return Enums.AuthenticationMethod.Windows;
            }
        }

        private string AuthenticationMethodToString(Enums.AuthenticationMethod authenticationMethod)
        {
            switch (authenticationMethod)
            {
                case Enums.AuthenticationMethod.Windows: return WIN_AUTH;
                case Enums.AuthenticationMethod.SQL: return SQL_AUTH;
                default: return WIN_AUTH;
            }
        }

        private void cbAuthenticationMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isSQLEnabled = StringToAuthenticationMethod((string)cbAuthenticationMethod.SelectedItem) == Enums.AuthenticationMethod.SQL;

            tbUserName.Enabled = isSQLEnabled;
            tbPassword.Enabled = isSQLEnabled;
        }

        public static bool ShowAsDialog(int connectionId = -1)
        {
            AddEditConnection conDialog = new AddEditConnection(connectionId);
            conDialog.ShowDialog();
            return conDialog.IsOk;
        }
    }
}
