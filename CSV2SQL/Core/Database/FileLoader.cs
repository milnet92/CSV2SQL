using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV2SQL.Core.Database
{
    public abstract class FileLoader
    {
        private static List<Type> AvailableTypes;

        public string Filename { get; private set; }
        public string Tablename { get; private set; }
        public int Registers { get; internal set; }
        public List<FileTableColumn> Columns { get; internal set; }

        private SqlConnection _sqlConnection;
        private DatabaseConnection connection;

        protected readonly FileTable fileTable;

        public event EventHandler<FileLoadProgressEventArgs> RowsAdded;

        public FileLoader(FileTable fileTable)
        {
            this.fileTable = fileTable;

            Filename = fileTable.Path;
            Tablename = fileTable.FileLoadOptions.TableName;
            connection = DBConnectionManager.Instance.GetConnectionById(fileTable.ConnectionId);
        }

        internal abstract List<FileTableColumn> CalculateColumns();
        internal abstract void FillDataTable(DataTable dataTable);

        private DataTable InitializeDataTable()
        {
            DataTable dataTable = new DataTable(Tablename);

            foreach (var column in Columns)
            {
                DataColumn dataColumn = new DataColumn(column.Name, column.Type);

                if (dataColumn.DataType == typeof(string)) dataColumn.MaxLength = column.Length;

                dataTable.Columns.Add(dataColumn);
            }

            return dataTable;
        }

        private void CreateTemporaryTable(DataTable dataTable)
        {
            string command = "create table " + fileTable.Schema + ".[" + Tablename + "] (";
            int colIdx = 0;
            foreach (var col in Columns)
            {
                if (colIdx!= 0)
                    command += ",";

                colIdx++;
                command += "[" + col.Name+ "]" +
                    " " + col.SqlType + 
                    " " + "null";
            }
            command += ")";

            SqlCommand sqlcommand = new SqlCommand(command, _sqlConnection);
            sqlcommand.ExecuteNonQuery();
        }

        private void InsertIntoSql(DataTable dataTable)
        {
            CreateTemporaryTable(dataTable);

            SqlBulkCopy bc = new SqlBulkCopy(_sqlConnection)
            {
                DestinationTableName = fileTable.Schema + ".[" + Tablename + "]",
                NotifyAfter = dataTable.Rows.Count / 10,
                BatchSize = 5000
            };

            bc.SqlRowsCopied += Bc_SqlRowsCopied;
            bc.WriteToServer(dataTable);
            bc.Close();
        }

        private void Bc_SqlRowsCopied(object sender, SqlRowsCopiedEventArgs e)
        {
            RowsAdded?.Invoke(this, new FileLoadProgressEventArgs(fileTable, Convert.ToInt32(e.RowsCopied)));
        }

        public DataTable Run()
        {
            DataTable dataTable = null;

            try
            {
                _sqlConnection = connection.CreateSqlConnection(fileTable.SqlConnectionKey);
                _sqlConnection.Open();

                Columns = fileTable.FromTemplate ? fileTable.Template.Columns : CalculateColumns();
                dataTable = InitializeDataTable();
                FillDataTable(dataTable);
                InsertIntoSql(dataTable);
            }
            catch (Exception ex)
            {
                Log.AddMessage($"Error while loading file table {Tablename}", ex.Message, Log.LogLevel.Error, fileTable);
                dataTable = null;
            }

            DataTable copyData = null;

            // Only interested in first top 100
            if (dataTable != null)
            {
                copyData = dataTable.AsEnumerable().Take(ApplicationConfig.Instance.PreviewRowCount).CopyToDataTable().Copy();
                copyData.TableName = dataTable.TableName;
            }

            return copyData;
        }

        public static List<Type> GetAvailableTypes()
        {
            if (AvailableTypes == null)
            {
                AvailableTypes = new List<Type>()
                {
                    typeof(Int32),
                    typeof(decimal),
                    typeof(DateTime),
                    typeof(long),
                    typeof(string)
                };
            }

            return AvailableTypes;
        }
    }
}
