using CSV2SQL.Core.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV2SQL.Core
{
    public class FileTable
    {
        private int connectionId;
        private string path;
        private string extension;
        private DataTable dataTable;

        public int ConnectionId => connectionId;
        public string Path => path;
        public string Extension => extension;
        public string SqlConnectionKey => Path + ":" + connectionId;

        private string tableName;
        public string TableName
        {
            get { return tableName; }
            set
            {
                FileLoadOptions.TableName = value;
                this.tableName = value;
            }
        }
        public int NumRows { get; set; }
        public int TotalRows { get; set; }
        public string Schema { get; set; }
        public bool FromTemplate { get; set; }
        public bool FirstRowHeader { get; set; }
        public FileLoadOptions FileLoadOptions { get; set; }
        public FileTableTemplate Template { get; set; }
        public List<FileTableColumn> Columns = new List<FileTableColumn>();
        public bool IsReadyToUse { get { return NumRows == TotalRows; } }

        public DataTable DataTable => dataTable;

        public FileTable(int connectionId, string path, FileLoadOptions fileLoadOptions)
        {
            this.connectionId = connectionId;
            this.path = path;
            this.extension = System.IO.Path.GetExtension(path).ToLower();
            FileLoadOptions = fileLoadOptions;
        }

        public void SetDataTable(DataTable dataTable)
        {
            this.dataTable = dataTable;

            // Complete transfer
            NumRows = TotalRows;
        }
    }
}
