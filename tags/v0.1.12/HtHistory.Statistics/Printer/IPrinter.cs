using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Statistics
{
    public interface IPrinter
    {
        string Print(object o);
    }

    public interface IPrinter<T>
    {
        string Print(T t);
    }
}
