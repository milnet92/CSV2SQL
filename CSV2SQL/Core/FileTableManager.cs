using CSV2SQL.Core.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSV2SQL.Core
{
    public class FileTableManager : IObservable<FileTableMetadataObserverContract>
    {
        public static FileTableManager Instance = new FileTableManager();

        private List<IObserver<FileTableMetadataObserverContract>> observers = new List<IObserver<FileTableMetadataObserverContract>>();
        private static List<string> allowedFormats = new List<string>() { "csv", "txt", "xslx" };
        private static List<FileTable> fileTables = new List<FileTable>();

        public static bool IsAllowedPath(string path, int connectionId)
        {
            string format = Path.GetExtension(path).Replace(".", "");
            bool ok = !string.IsNullOrEmpty(path) && allowedFormats.Contains(format) && !IsFileImportedByConnectionId(path, connectionId);

            // Check file access
            if (ok)
            {
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
                {
                    var canRead = fs.CanRead;

                    if (!canRead)
                        throw new Exception($"File {path} is not readable.");
                }
            }

            return ok;
        }

        public static FileTable GetFileTableFromPath(string path, int connectionId)
        {
            return fileTables.Where(ft => ft.Path == path && ft.ConnectionId == connectionId).First();
        }

        public void ModifyTableName(string path, int connectionId, string newTableName, string newSchema)
        {
            FileTable fileTable = GetFileTableFromPath(path, connectionId);

            DBCommandHelper.RenameTableNameOrSchema(fileTable,
                fileTable.TableName,
                fileTable.Schema,
                newTableName,
                newSchema);

            fileTable.TableName = newTableName;

            NotifyObservers(fileTable, Enums.NotifyActionType.Update);
        }

        public void ModifyTemplate(string path, int connectionId, FileTableTemplate template)
        {
            FileTable fileTable = GetFileTableFromPath(path, connectionId);

            Remove(path, connectionId);

            StartLoadThread(fileTable.ConnectionId, path, new FileLoadOptions()
            {
                FirstRowHeader = fileTable.FirstRowHeader,
                IsFromTemplate = template != null,
                Schema = fileTable.Schema,
                Separator = ApplicationConfig.Instance.DefaultSeparator,
                TableName = fileTable.TableName,
                Template = template,
                EnableScripts = fileTable.FileLoadOptions.EnableScripts,
            });

        }
        
        public void RemoveByServer(string path, string server)
        {
            List<FileTable> toRemove = fileTables.Where(ft => ft.Path == path && DBConnectionManager.Instance.GetConnectionById(ft.ConnectionId).Server == server).ToList();

            foreach (var ft in toRemove)
            {
                Remove(path, ft.ConnectionId);
            }
        }

        public void Remove(string path, int connectionId)
        {
            FileTable fileTable = GetFileTableFromPath(path, connectionId);

            if (fileTable.IsReadyToUse)
                DBCommandHelper.DropTableIfExists(DBConnectionManager.Instance.GetConnectionById(fileTable.ConnectionId), fileTable.TableName, fileTable.Schema);

            DBConnectionManager.RemoveFromPool(fileTable.SqlConnectionKey);

            fileTables.Remove(fileTable);
            NotifyObservers(fileTable, Enums.NotifyActionType.Delete);
            Log.AddMessage("File table removed");
        }


        public void Add(int connectionId, string path, FileLoadOptions options)
        {
            if (!IsAllowedPath(path, connectionId)) throw new Exception($"Cannot import file {path}");

            StartLoadThread(connectionId, path, options);
        }

        public void StartLoadThread(int connectionId, string path, FileLoadOptions options)
        {
            new Thread(new ThreadStart(() =>
            {
                StartLoad(connectionId, path, options);
            })).Start();
        }

        private FileTable constructFileTable(int connectionId, string path, FileLoadOptions options)
        {
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
            using (StreamReader reader = new StreamReader(stream))
            {
                var totalRows = reader.ReadToEnd().Split(new char[] { '\n' }).Count();
                FileTable fileTable = new FileTable(connectionId, path, options)
                {
                    TableName = options.TableName,
                    TotalRows = totalRows
                };

                fileTable.FirstRowHeader = options.FirstRowHeader;
                fileTable.Schema = options.Schema;
                fileTable.FromTemplate = options.IsFromTemplate;
                fileTable.Template = options.Template;
                return fileTable;
            }
        }

        public void StartLoad(int connectionId, string path, FileLoadOptions options)
        {
            FileTable fileTable = constructFileTable(connectionId, path, options);
            Log.AddMessage($"Importing table {fileTable.TableName}...");

            fileTables.Add(fileTable);

            Instance.NotifyObservers(fileTable, Enums.NotifyActionType.Add);

            CSVFileLoader loader = new CSVFileLoader(fileTable, options.Separator);

            loader.RowsAdded += Loader_RowsAdded;

            var dataTable = loader.Run();

            if (dataTable != null)
            {
                fileTable.SetDataTable(dataTable);
                fileTable.Columns = loader.Columns;
                Instance.NotifyObservers(fileTable, Enums.NotifyActionType.Update);
                Log.AddMessage($"Table {fileTable.TableName} successfully imported");
            }
            else
            {
                Remove(path, connectionId);
            }
        }

        private void Loader_RowsAdded(object sender, FileLoadProgressEventArgs e)
        {
            e.FileTable.NumRows = e.Rows;
            Instance.NotifyObservers(e.FileTable, Enums.NotifyActionType.Update);
        }

        public static string GetTableNameFromPath(string path)
        {
            return "##" + Path.GetFileNameWithoutExtension(path);
        }

        public static List<FileTable> GetFileTablesByConnectionId(int connectionId)
        {
            return fileTables.Where(ft => ft.ConnectionId == connectionId).ToList();
        }

        public static bool IsFileImportedByServer(string path, string server)
        {
            return fileTables.Exists(file => file.Path == path &&
                DBConnectionManager.Instance.GetConnectionById(file.ConnectionId).Server == server);
        }

        public static bool IsFileImportedByConnectionId(string path, int connectionId)
        {
            return fileTables.Exists(file => file.Path == path && file.ConnectionId == connectionId);
        }

        public IDisposable Subscribe(IObserver<FileTableMetadataObserverContract> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);

            return new FileTableUnsubscriber(observers, observer);
        }

        private void NotifyObservers(FileTable fileTable, Enums.NotifyActionType actionType)
        {
            foreach (var observer in observers.ToArray())
            {
                observer.OnNext(new FileTableMetadataObserverContract(fileTable, actionType));
            }
        }
    }

    public class FileTableUnsubscriber : IDisposable
    {
        private List<IObserver<FileTableMetadataObserverContract>> _observers;
        private IObserver<FileTableMetadataObserverContract> _observer;

        public FileTableUnsubscriber(List<IObserver<FileTableMetadataObserverContract>> observers, IObserver<FileTableMetadataObserverContract> observer)
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
