using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Statistics
{
    public class DoublePrinter1 : IPrinter, IPrinter<double>
    {
        public virtual string Print(double t)
        {
            return t.ToString("0.0");
        }

        public virtual string Print(object o)
        {
            if (o is double) return Print((double)o);
            else if (o == null) return "-";
            else return o.ToString();
        }
    }

    public class DoublePrinter2 : DoublePrinter1, IPrinter, IPrinter<double>
    {
        public override string Print(double t)
        {
            return t.ToString("0.00");
        }
    }
}
