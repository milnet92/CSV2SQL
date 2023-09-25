using CSV2SQL.Core;
using CSV2SQL.Core.Database;
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
    public partial class FileLoadOptionsDefaultDialog : Form
    {
        public FileLoadOptions Options;

        public FileLoadOptionsDefaultDialog(int connectionId, FileLoadOptions options)
        {
            DialogResult = DialogResult.Cancel;

            this.Icon = CSV2SQL.Properties.Resources.banana;
            Options = options;

            InitializeComponent();

            // Retrieve connection
            DatabaseConnection connection = DBConnectionManager.Instance.GetConnectionById(connectionId);
            
            // Setup form data
            tbDatabase.Text = connection.DataBase;
            tbServer.Text = connection.Server;

            tbSchema.Text = options.Schema;
            tbSeparator.Text = options.Separator;
            cbFirstRowHeader.Checked = options.FirstRowHeader;
            tbTableName.Text = options.TableName;
            cbPrimaryKey.Checked = options.CreatePrimaryKey;

            this.Text = $"Import data to {connection.DataBase}";
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btAccept_Click(object sender, EventArgs e)
        {
            Options.Separator = tbSeparator.Text;
            Options.Schema = tbSchema.Text;
            Options.FirstRowHeader = cbFirstRowHeader.Checked;
            Options.TableName = tbTableName.Text;
            Options.CreatePrimaryKey = cbPrimaryKey.Checked;

            DialogResult = DialogResult.OK;

            this.Close();
        }
    }
}
