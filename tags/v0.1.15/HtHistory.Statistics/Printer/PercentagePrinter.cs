using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Statistics.Printer
{
    public class PercentagePrinter : IPrinter, IPrinter<double>
    {
        public string Print(double t)
        {
            return string.Format("{0:0.} %", t * 100);
        }

        public string Print(object o)
        {
            if (o is double) return Print((double)o);
            else if (o == null) return "-";
            else return o.ToString();
        }
    }
}
