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
    public partial class ParametersDialog : Form
    {
        public ParametersDialog()
        {
            this.Icon = CSV2SQL.Properties.Resources.banana;
            InitializeComponent();
            txSchema.Text = ApplicationConfig.Instance.DefaultSchema;
            txSeparator.Text = ApplicationConfig.Instance.DefaultSeparator;
            cbShowOptions.Checked = ApplicationConfig.Instance.ShowOptions;
            cbChangeTableName.Checked = ApplicationConfig.Instance.ChangeTableNameForSameFile;
            tbPreviewRowCount.Text = ApplicationConfig.Instance.PreviewRowCount.ToString();
            cbPrimaryKey.Checked = ApplicationConfig.Instance.CreatePrimaryKey;
        }

        private void btAccept_Click(object sender, EventArgs e)
        {
            ApplicationConfig.Instance.DefaultSeparator = txSeparator.Text;
            ApplicationConfig.Instance.DefaultSchema = txSchema.Text;
            ApplicationConfig.Instance.ShowOptions = cbShowOptions.Checked;
            ApplicationConfig.Instance.ChangeTableNameForSameFile = cbChangeTableName.Checked;
            ApplicationConfig.Instance.PreviewRowCount = int.Parse(tbPreviewRowCount.Text);
            ApplicationConfig.Instance.CreatePrimaryKey = cbPrimaryKey.Checked;

            ApplicationConfig.Save();

            this.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == (char)8) //The  character 8 represents a backspace
            {
                e.Handled = false; //Do not reject the input
            }
            else
            {
                e.Handled = true; //Reject the input
            }
        }
    }
}
