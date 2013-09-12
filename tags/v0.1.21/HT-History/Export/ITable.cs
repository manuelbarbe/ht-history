using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Export
{
    public interface ITable
    {
        object[] ColumHeaders { get; }
        object[][] Data { get; } // [row][column]
    }
}
