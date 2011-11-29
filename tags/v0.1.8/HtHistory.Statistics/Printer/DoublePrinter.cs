using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Statistics
{
    public class DoublePrinter : IPrinter, IPrinter<double>
    {
        public string Print(double t)
        {
            return t.ToString("0.00");
        }

        public string Print(object o)
        {
            if (o is double) return Print((double)o);
            else if (o == null) return "-";
            else return o.ToString();
        }
    }
}
