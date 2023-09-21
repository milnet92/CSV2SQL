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
using System.Windows.Forms.Design;

namespace CSV2SQL.Forms.Controls
{
    public partial class FileTabPage : CustomTabPage
    {
        public readonly FileTable FileTable;

        public double Progress { get; set; }

        public FileTabPage(FileTable fileTable)
        {
            FileTable = fileTable;
            Progress = 0;
        }

        public void UpdateText()
        {
            this.Invoke(new MethodInvoker(() =>
            {
               this.Text = Progress != 1 ?
               FileTable.TableName + string.Format(" {0:0}%", Progress * 100) :
               FileTable.TableName;

               this.Invalidate();
            }));
        }
    }
}
