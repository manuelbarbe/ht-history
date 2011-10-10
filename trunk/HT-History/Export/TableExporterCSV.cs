using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.ExtensionMethods;

namespace HtHistory.Export
{
    public class TableExporterCSV : ITableExporter
    {
        private string _separator;

        public TableExporterCSV(string separator)
        {
            if (string.IsNullOrEmpty(separator))
            {
                throw new Exception("CSV separator has to contain at least one character");
            }

            _separator = separator;
        }

        public void Export(ITable table, System.IO.TextWriter writer)
        {
            foreach (object obj in table.ColumHeaders.SafeEnum())
            {
                writer.Write(obj.ToString());
                writer.Write(_separator);
            }
            writer.WriteLine();

            foreach (object[] row in table.Data)
            {
                foreach (object column in row)
                {
                    writer.Write(column.ToString());
                    writer.Write(_separator);
                }
                writer.WriteLine();
            }
        }
    }
}
