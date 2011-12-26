using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace HtHistory.Statistics.Players
{
    public interface IPlayerStatisticCalculator<Source>
    {
        string Name { get; }
        string Abbreviation { get; }
        string Identifier { get; }

        object Calculate(Source source);
        IComparer GetComparer();
        IPrinter GetPrinter();
    }
}
