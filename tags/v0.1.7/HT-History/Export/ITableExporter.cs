using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HtHistory.Export
{
    public interface ITableExporter
    {
        void Export(ITable table, TextWriter writer);
    }
}
