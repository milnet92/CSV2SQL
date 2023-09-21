using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace CSV2SQL.Core
{
    public class DatabaseConnection
    {
        public Enums.DBConnectionStatus Status { get; set; }
        public string DataBase { get; set; }
        public string Server { get; set; }
        public Enums.AuthenticationMethod AuthenticationMethod { get; set; }
        public string UserName { get; set; }
        public SecureString Password { get; set; }

        public string ErrorMessage { get; set; }
        private static List<SqlConnection> _connectionPool = new List<SqlConnection>();

        public string SecureConnectionString
        {
            get
            {
                if (AuthenticationMethod == Enums.AuthenticationMethod.SQL)
                    return String.Format("Data Source={0};Initial Catalog={1};User Id={2};Password=[SKIPPED];Connection Timeout=1", Server, DataBase, UserName);

                return String.Format("Data Source={0};Initial Catalog={1};Integrated Security=True;Connection Timeout=1", Server, DataBase);
            }
        }

        public string ConnectionString
        {
            get
            {
                if (AuthenticationMethod == Enums.AuthenticationMethod.SQL)
                    return String.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3};Connection Timeout=1", Server, DataBase, UserName, Security.SecurityHelper.SecureStringToString(Password));

                return String.Format("Data Source={0};Initial Catalog={1};Integrated Security=True;Connection Timeout=1", Server, DataBase);
            }
        }

        public DatabaseConnection(string server, string db, Enums.AuthenticationMethod authenticationMethod)
        {
            Server = server;
            DataBase = db;
            AuthenticationMethod = authenticationMethod;
            Status = Enums.DBConnectionStatus.Pending;
        }

        public SqlConnection CreateSqlConnection(string key = "")
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            if (!string.IsNullOrEmpty(key))
                DBConnectionManager.AddToPool(key, connection);

            return connection;
        }

        public void CheckIsValid()
        {
            Status = Enums.DBConnectionStatus.Pending;

            try
            {
                using (var connection = this.CreateSqlConnection())
                {
                    connection.Open();
                    connection.Close();
                }

                Status = Enums.DBConnectionStatus.Connected;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Status = Enums.DBConnectionStatus.NotConnected;
            }
            finally
            {
                DBConnectionManager.RemoveFromPool("");
            }
        }
    }
}
