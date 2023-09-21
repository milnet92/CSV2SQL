using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV2SQL.Core
{
    public class FileTableColumn
    {
        public string Name { get; set; }
        public Type Type { get; set; }
        public int Length { get; set; }
        public bool HasType { get { return Type != null; } }
        public string SqlType
        {
            get
            {
                if (Type == typeof(int)) return "int";
                if (Type == typeof(decimal)) return "decimal(32, 16)";
                if (Type == typeof(long)) return "bigint";
                if (Type == typeof(DateTime)) return "datetime";
                if (Type == typeof(string))
                {
                    if (Length == -1) return "nvarchar(" + Length.ToString() + ")";
                    return "nvarchar(max)";
                }
                throw new Exception("Type " + Type.ToString() + "not supported.");
            }
        }


        public dynamic GetValue(string value)
        {
            if (Type == typeof(string)) return value;
            if (Type == typeof(int)) return Convert.ToInt32(value);
            if (Type == typeof(Int64)) return Convert.ToInt64(value);
            if (Type == typeof(DateTime)) return Convert.ToDateTime(value);
            if (Type == typeof(decimal)) return Convert.ToDecimal(value);

            throw new Exception($"Tyepe {Type.ToString()} not supported.");
        }
    }
}
