using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSV2SQL.Core;
using CSV2SQL.Forms;

namespace CSV2SQL
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfig.Initialize();

            if (ApplicationConfig.Instance.FirstTimeOpen)
            {
                MessageBox.Show("A new version is released, please check all our new super features :D");
                ApplicationConfig.Instance.FirstTimeOpen = false;
                ApplicationConfig.Save();
            }

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Main());
            }
            finally
            {
                DBConnectionManager.CloseAllConnections();
            }
        }
    }
}
