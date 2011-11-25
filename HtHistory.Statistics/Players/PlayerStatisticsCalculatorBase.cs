using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace HtHistory.Statistics.Players
{
    public abstract class PlayerStatisticsCalculatorBase<Source, Result> : IPlayerStatisticCalculator<Source>
    {
        public abstract string Name { get; }

        public virtual string Abbreviation { get { return Name; } }
        
        public virtual string Identifier { get { return GetType().FullName; } }

        public abstract Result Calculate(Source source);

        public IComparer<Result> GetComparer()
        {
            return System.Collections.Generic.Comparer<Result>.Default;
        }

        object IPlayerStatisticCalculator<Source>.Calculate(Source source)
        {
            return Calculate(source);
        }

        IComparer IPlayerStatisticCalculator<Source>.GetComparer()
        {
            return new Generic2ObjectComparer<Result>(GetComparer());
        }

    }
}
