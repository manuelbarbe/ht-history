using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Export
{
    public class Table : ITable
    {
        public object[] ColumHeaders
        {
            get;
            set;
        }

        public object[][] Data
        {
            get;
            set;
        }
    }
}
