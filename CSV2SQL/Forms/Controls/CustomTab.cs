using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSV2SQL.Core;

namespace CSV2SQL.Forms.Controls
{
    public partial class CustomTab : TabControl
    {
        private static ImageList imageList;

        static CustomTab()
        {
            // Initialize image list 
            imageList = new ImageList();
            imageList.Images.Add(CSV2SQL.Properties.Resources.close);
        }

        public CustomTab()
        {
            this.ImageList = imageList;
        }


        public virtual void AddTab(TabPage tabPage)
        {
            this.TabPages.Add(tabPage);
        }
    }
}
