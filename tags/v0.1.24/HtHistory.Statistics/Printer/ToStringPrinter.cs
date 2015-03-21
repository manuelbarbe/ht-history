using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Statistics
{
    public class ToStringPrinter<T> : IPrinter, IPrinter<T>
    {

        public string Print(object o)
        {
            if (o == null) return "-";
            return o.ToString();
        }

        public string Print(T t)
        {
            return Print(t);
        }
    }
}
