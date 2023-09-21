using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV2SQL.Core
{
    public class DBConnectionObserverContract
    {
        public DatabaseConnection DBConnection { get; private set; }
        public int Id { get; set; }
        public Enums.NotifyActionType NotifyActionType { get; private set; }

        public DBConnectionObserverContract(int id, DatabaseConnection connection, Enums.NotifyActionType actionType = Enums.NotifyActionType.Add)
        {
            Id = id;
            DBConnection = connection;
            NotifyActionType = actionType;
        }
    }
}
