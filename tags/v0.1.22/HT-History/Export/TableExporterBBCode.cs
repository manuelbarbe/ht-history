using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.ExtensionMethods;

namespace HtHistory.Export
{
    public class TableExporterBBCode : ITableExporter
    {
        public void Export(ITable table, System.IO.TextWriter writer)
        {
            writer.Write("[table][tr]");
            foreach (object obj in table.ColumHeaders.SafeEnum())
            {
                writer.Write("[td]");
                writer.Write(obj.ToString());
                writer.Write("[/td]");
            }
            writer.WriteLine("[/tr]");

            foreach (object[] row in table.Data)
            {
                writer.Write("[tr]");
                foreach (object column in row)
                {
                    writer.Write("[td]");
                    writer.Write(column.ToString());
                    writer.Write("[/td]");
                }
                writer.WriteLine("[/tr]");
            }

            writer.Write("[/table]");
        }
    }
}
