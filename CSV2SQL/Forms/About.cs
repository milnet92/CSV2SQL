using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSV2SQL.Forms
{
    public partial class About : Form
    {
        public About()
        {
            this.Icon = CSV2SQL.Properties.Resources.banana;

            InitializeComponent();

            this.pictureBox1.Image = CSV2SQL.Properties.Resources.logo;
            this.versionLabel.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/milnet92/CSV2SQL");
        }
    }
}
