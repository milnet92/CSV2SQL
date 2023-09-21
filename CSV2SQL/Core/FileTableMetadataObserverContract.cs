using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV2SQL.Core
{
    public class FileTableMetadataObserverContract
    {
        FileTable fileTable;

        public FileTable FileTable => fileTable;
        public Enums.NotifyActionType NotifyActionType { get; private set; }

        public FileTableMetadataObserverContract(FileTable fileTable, Enums.NotifyActionType actionType = Enums.NotifyActionType.Add)
        {
            NotifyActionType = actionType;
            this.fileTable = fileTable;
        }
    }
}
