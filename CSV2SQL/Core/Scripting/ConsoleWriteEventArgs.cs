using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVS2SQL.Core.Scripting
{
    public class ConsoleWriteEventArgs : EventArgs
    {
        public string Text { get; set; }
        public ConsoleWriteEventArgs(string text)
        {
            Text = text;
        }
    }
}
