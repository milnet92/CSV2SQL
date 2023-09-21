using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV2SQL.Core.Database
{
    public class CSVFileLoader : FileLoader
    {
        public string Separator { get; set; }

        public CSVFileLoader(FileTable fileTable, string separator) : base(fileTable)
        {
            Separator = separator;
        }

        internal override List<FileTableColumn> CalculateColumns()
        {
            List<FileTableColumn> columns = new List<FileTableColumn>();
            int colIdx;
            int reg = 0;

            foreach (var values in GetFileLines())
            {
                reg += 1;

                // Is First
                if (reg == 1)
                {
                    if (!fileTable.FirstRowHeader)
                    {
                        columns = GetEmptyColumns(values);
                    }
                    else
                    {
                        columns = GetEmptyColumnsFromHeader(values);
                        continue;
                    }
                }

                // Iterate throught line values
                colIdx = 0;
                foreach (var val in values)
                {
                    SetType(val, columns[colIdx]);
                    colIdx++;
                }
            }

            return columns;
        }

        internal override void FillDataTable(DataTable dataTable)
        {
            int rowIdx = 0;

            foreach (var values in GetFileLines())
            {
                rowIdx++;
                int colIdx = 0;
                if (rowIdx == 1 && fileTable.FirstRowHeader) continue;

                DataRow row = dataTable.NewRow();
                foreach (var val in values)
                {
                    var column = Columns[colIdx];
                    row[column.Name] = column.GetValue(val);
                    colIdx++;
                }
                dataTable.Rows.Add(row);
            }
        }


        private List<FileTableColumn> GetEmptyColumns(string[] values)
        {
            List<FileTableColumn> columns = new List<FileTableColumn>();
            for (var idx = 0; idx < values.Length; idx++) columns.Add(new FileTableColumn() { Name = $"Column{idx}" });
            return columns;
        }

        private List<FileTableColumn> GetEmptyColumnsFromHeader(string[] values)
        {
            List<FileTableColumn> columns = new List<FileTableColumn>();
            foreach (var val in values) columns.Add(new FileTableColumn() { Name = val });
            return columns;
        }

        private IEnumerable<string[]> GetFileLines()
        {
            using (FileStream stream = new FileStream(Filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
            using (StreamReader reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    string[] values = line.Split(new string[] { Separator }, StringSplitOptions.None);

                    yield return values;
                }
            }
        }

        private void SetType(string value, FileTableColumn column)
        {
            object val;
            bool ok;

            // It is already a string
            if (column.HasType && column.Type == typeof(string))
            {
                decideMaxLength(value, column);
                return;
            }

            val = canConvertToInt(value, out ok);
            if (!ok) val = canConvertToInt64(value, out ok);
            if (!ok) val = canConvertToDecimal(value, out ok);
            if (!ok) val = canConvertToDateTime(value, out ok);
            if (!ok) val = value;

            if (!column.HasType ||
                column.Type == val.GetType())
            {
                column.Type = val.GetType();
            }
            else if ((val.GetType() == typeof(decimal) && column.Type == typeof(int)) ||
                    (val.GetType() == typeof(int) && column.Type == typeof(decimal)))
            {
                column.Type = typeof(decimal);
            }
            else if ((val.GetType() == typeof(Int64) && column.Type == typeof(int)) ||
                    (val.GetType() == typeof(int) && column.Type == typeof(Int64)))
            {
                column.Type = typeof(Int64);
            }
            else if (column.Type != val.GetType())
            {
                column.Type = typeof(string);
            }

            decideMaxLength(value.ToString(), column);
        }

        private void decideMaxLength(string value, FileTableColumn column)
        {
            if (value.Length > column.Length)
                column.Length = value.Length;
        }

        private Int64 canConvertToInt64(string v, out bool ok)
        {
            Int64 val;
            ok = Int64.TryParse(v, out val);
            return val;
        }

        private int canConvertToInt(string v, out bool ok)
        {
            int val;
            ok = int.TryParse(v, out val);
            return val;
        }

        private decimal canConvertToDecimal(string v, out bool ok)
        {
            decimal val;
            ok = decimal.TryParse(v, out val);
            return val;
        }

        private DateTime canConvertToDateTime(string v, out bool ok)
        {
            DateTime val;
            ok = DateTime.TryParse(v, out val);
            return val;
        }

        public static List<FileTableColumn> GetSchema(FileTable fileTable, string separator)
        {
            CSVFileLoader loader = new CSVFileLoader(fileTable, separator);
            return loader.CalculateColumns();
        }
    }
}
