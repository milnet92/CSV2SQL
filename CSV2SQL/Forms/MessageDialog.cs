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
    public partial class MessageDialog : Form
    {
        public MessageDialog(string caption, string message = "", string details = "")
        {
            this.Icon = CSV2SQL.Properties.Resources.banana;
            InitializeComponent();

            this.Text = caption;
            this.messageBox.Text = message +
                Environment.NewLine + Environment.NewLine +
                details;
            this.messageBox.Select(0, 0);
            okButton.Focus();
        }

        public static void ShowMessage(string caption, string message = "", string details = "")
        {
            new MessageDialog(caption, message, details).ShowDialog();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
