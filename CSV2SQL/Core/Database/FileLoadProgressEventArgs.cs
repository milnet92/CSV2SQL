using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV2SQL.Core.Database
{
    public class FileLoadProgressEventArgs : EventArgs
    {
        public int Rows { get; private set; }
        public FileTable FileTable { get; private set; }
        public FileLoadProgressEventArgs(FileTable fileTable, int rows)
        {
            FileTable = fileTable;
            Rows = rows;
        }
    }
}
