using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV2SQL.Core.Database
{
    public class FileTableTemplate
    {
        private List<FileTableColumn> _columns = new List<FileTableColumn>();
        public List<FileTableColumn> Columns
        {
            get { return _columns; }
        }

        public void AddColumn(FileTableColumn column)
        {
            _columns.Add(column);
        }
    }
}
