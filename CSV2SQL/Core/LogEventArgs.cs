using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV2SQL.Core
{
    public class LogEventArgs : EventArgs
    {
        public string Message { get; set; }
        public string Details { get; set; }
        public Log.LogLevel LogLevel { get; set; }
        public object Origin { get; set; }
    }
}
