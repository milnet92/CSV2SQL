using CSV2SQL.Core;
using CSV2SQL.Forms.Controls;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace CSV2SQL.Core
{
    public class DBConnectionManager : IObservable<DBConnectionObserverContract>
    {
        private int idCount = 0;

        private static Dictionary<string, SqlConnection> _sqlConnectionPool = new Dictionary<string, SqlConnection>();

        public static DBConnectionManager Instance = new DBConnectionManager();

        public readonly List<int> Ids = new List<int>();
        public readonly List<DatabaseConnection> Connections = new List<DatabaseConnection>();


        private List<IObserver<DBConnectionObserverContract>> observers = new List<IObserver<DBConnectionObserverContract>>();

        public IDisposable Subscribe(IObserver<DBConnectionObserverContract> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);

            return new DBConnectionUnsubscriber(observers, observer);
        }

        internal static void CloseAllConnections()
        {
            foreach (var conn in _sqlConnectionPool)
            {
                var value = conn.Value;

                if (value != null && value.State != System.Data.ConnectionState.Closed)
                    value.Close();
            }
        }

        private void NotifyObservers(int id, DatabaseConnection connection, Enums.NotifyActionType actionType)
        {
            foreach (var observer in observers.ToArray())
            {
                observer.OnNext(new DBConnectionObserverContract(id, connection, actionType));
            }
        }

        public async Task AddAsync(DatabaseConnection connection, bool check = false)
        {
            Task task = new Task(() =>
            {
                if (Exists(connection.Server, connection.DataBase)) return;

                Connections.Add(connection);
                Ids.Add(++idCount);

                NotifyObservers(idCount, connection, Enums.NotifyActionType.Add);

                Log.AddMessage("New connection created");

                if (check) connection.CheckIsValid();

                NotifyObservers(idCount, connection, Enums.NotifyActionType.Update);
            });
            task.Start();
            await task;
        }

        public async Task AddOrEditAsync(int connectionId, string server, string database, 
            Enums.AuthenticationMethod authenticationMethod = Enums.AuthenticationMethod.Windows,
            string userName = "",
            SecureString password = null,
            bool check = false)
        {
            if (connectionId == -1 || !Ids.Contains(connectionId))
            { 
                await AddAsync(server, database, authenticationMethod, userName, password, check);
            }
            else
                await EditAsync(connectionId, server, database, authenticationMethod, userName, password, check);
        }

        public async Task AddAsync(string server, string database, Enums.AuthenticationMethod authenticationMethod, string userName = "", SecureString password = null, bool check = false)
        {
            await AddAsync(new DatabaseConnection(server, database, authenticationMethod)
            {
                UserName = userName,
                Password = password
            },
            check);
        }

        public async Task EditAsync(int connectionId, string server, string database,
            Enums.AuthenticationMethod authenticationMethod,
            string userName = "",
            SecureString password = null,
            bool check = false)
        {
            Task task = new Task(() =>
            {
                DatabaseConnection connection = GetConnectionById(connectionId);

                connection.Server = server;
                connection.DataBase = database;
                connection.AuthenticationMethod = authenticationMethod;
                connection.UserName = userName;
                connection.Password = password;
                connection.Status = Enums.DBConnectionStatus.Pending; // Disabled before checking connection

                NotifyObservers(connectionId, connection, Enums.NotifyActionType.Update);

                connection.CheckIsValid();

                Log.AddMessage("Connection updated");

                NotifyObservers(connectionId, connection, Enums.NotifyActionType.Update);
            });
            task.Start();
            await task;
        }
        public DatabaseConnection GetConnectionById(int connectionId)
        {
            var idx = Ids.IndexOf(connectionId);

            return Connections[idx];
        }

        public void Remove(int connectionId)
        {
            int idx = Ids.IndexOf(connectionId);

            foreach (var file in FileTableManager.GetFileTablesByConnectionId(connectionId))
            {
                FileTableManager.Instance.Remove(file.Path, connectionId);
            }

            var con = Connections[idx];

            Connections.RemoveAt(idx);
            Ids.RemoveAt(idx);

            NotifyObservers(connectionId, null, Enums.NotifyActionType.Delete);
        }

        public async Task LoadAsync()
        {
            List<Task> tasks = new List<Task>();
            Log.AddMessage("Initialization starts");
            foreach (var con in ApplicationConfig.Instance.Connections)
            {
                Log.AddMessage($"Checking {con.Server} - {con.Database}...");
                try
                {
                    var task = new Task(async () => await AddAsync(con.Connection, true));
                    task.Start();
                    tasks.Add(task);
                }
                catch { }
            }

            await Task.WhenAll(tasks);

            Log.AddMessage("Initialization ended");
        }

        public bool Exists(string server, string database)
        {
            // Check by server and database
            return Connections.Exists(con => con.Server == server && con.DataBase == database);
        }

        public void Save()
        {
            ApplicationConfig.Instance.Connections.Clear();

            foreach (var con in Connections)
            {
                ApplicationConfig.Instance.Connections.Add(new ConfigDBConnection() { 
                    Server = con.Server, 
                    Database = con.DataBase,
                    AuthenticationMethod = con.AuthenticationMethod,
                    UserName = con.UserName,
                    Password = Security.SecurityHelper.SecureStringToString(con.Password)
                });
            }

            ApplicationConfig.Save();
        }

        public static SqlConnection GetOpenConnection(string key)
        {
            return _sqlConnectionPool[key];
        }

        public static void AddToPool(string key, SqlConnection sqlConnection)
        {
            _sqlConnectionPool.Add(key, sqlConnection);
        }

        public static void RemoveFromPool(string key)
        {
            if (_sqlConnectionPool.ContainsKey(key))
            {
                var connection = _sqlConnectionPool[key];

                if (connection.State != System.Data.ConnectionState.Closed)
                    connection.Close();

                _sqlConnectionPool.Remove(key);
            }
        }
    }

    public class DBConnectionUnsubscriber : IDisposable
    {
        private List<IObserver<DBConnectionObserverContract>> _observers;
        private IObserver<DBConnectionObserverContract> _observer;

        public DBConnectionUnsubscriber(List<IObserver<DBConnectionObserverContract>> observers, IObserver<DBConnectionObserverContract> observer)
        {
            this._observers = observers;
            this._observer = observer;
        }

        public void Dispose()
        {
            if (_observer != null && _observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }

}
