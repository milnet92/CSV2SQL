using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV2SQL.Core.Database
{
    public static class DBCommandHelper
    {
        public static void DropTableIfExists(DatabaseConnection connection, string tableName, string schema)
        {
            using (var sqlConnection = connection.CreateSqlConnection())
            {
                sqlConnection.Open();

                string table = $"{schema}.[{tableName}]";

                SqlCommand sqlCommand = new SqlCommand($@"IF OBJECT_ID('tempdb.{table}', 'U') IS NOT NULL 
                                DROP TABLE {table}", sqlConnection);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public static void RenameTableNameOrSchema(FileTable fileTable, string tableName, string schema, string newTableName, string newSchema)
        {
            // This needs to be done on the master connection for the file
            // otherwise the temporary table will be deleted
            var sqlConnection = DBConnectionManager.GetOpenConnection(fileTable.SqlConnectionKey);

            string oldTable = $"{schema}.[{tableName}]";
            string newTable = $"{newSchema}.[{newTableName}]";

            SqlCommand createCommand = new SqlCommand($"SELECT * INTO {newTable} FROM {oldTable}", sqlConnection);
            createCommand.ExecuteNonQuery();

            SqlCommand dropCommand = new SqlCommand($"DROP TABLE {oldTable}", sqlConnection);
            dropCommand.ExecuteNonQuery();
        }
    }
}
