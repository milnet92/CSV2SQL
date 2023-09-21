using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV2SQL.Core
{
    public static class Enums
    {
        public enum NotifyActionType
        {
            Add, Delete, Update
        }

        public enum AuthenticationMethod
        {
            Windows,
            SQL
        }

        public enum DBConnectionStatus
        {
            Pending,
            NotConnected,
            Connected
        }
    }
}
