using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Globalization;

namespace HtHistory.Statistics.Players
{
    public abstract class PlayerStatisticsCalculatorBase<Source, Result> : IPlayerStatisticCalculator<Source>
    {
        public abstract string Name { get; }

        public virtual string Abbreviation { get { return Name; } }

        public virtual string Identifier { get { return Abbreviation; } }

        public abstract Result Calculate(Source source);

        public virtual IComparer<Result> GetComparer()
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

        public override string ToString()
        {
            return String.Format("{0} ({1})", Name, Abbreviation);
        }

        private IPrinter _printer = new ToStringPrinter<Result>();
        public virtual IPrinter GetPrinter()
        {
            return _printer;
        }
    }
}
