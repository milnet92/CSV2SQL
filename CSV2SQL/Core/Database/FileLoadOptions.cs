using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV2SQL.Core.Database
{
    public class FileLoadOptions : ICloneable
    {
        public static FileLoadOptions Default
        {
            get
            {
                return new FileLoadOptions()
                {
                    FirstRowHeader = true,
                    Schema = ApplicationConfig.Instance.DefaultSchema,
                    Separator = ApplicationConfig.Instance.DefaultSeparator,
                    EnableScripts = ApplicationConfig.Instance.EnableScritps
                };
            }
        }

        public bool FirstRowHeader { get; set; }
        public string Schema { get; set; }
        public string TableName { get; set; }
        public string Separator { get; set; }
        public bool IsFromTemplate { get; set; }
        public bool EnableScripts {  get; set; }
        public FileTableTemplate Template { get; set; }

        public static bool ShouldShowOptionsDialog(List<int> connectionIds)
        {
            if (ApplicationConfig.Instance.ShowOptions)
                return true;

            if (ApplicationConfig.Instance.ChangeTableNameForSameFile)
                return false;

            List<string> databases = new List<string>();

            foreach (int connectionId in connectionIds)
            {
                var con = DBConnectionManager.Instance.GetConnectionById(connectionId);

                // If it's the same server
                if (databases.Contains(con.Server))
                {
                    return true;
                }

                databases.Add(con.Server);
            }

            return false;
        }

        public object Clone()
        {
            return new FileLoadOptions()
            {
                FirstRowHeader = FirstRowHeader,
                Schema = Schema,
                TableName = TableName,
                Separator = Separator,
                EnableScripts = EnableScripts,
                Template = Template,
                IsFromTemplate = IsFromTemplate,
            };
        }
    }
}
