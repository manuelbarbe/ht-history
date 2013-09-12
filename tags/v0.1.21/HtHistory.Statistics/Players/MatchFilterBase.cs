using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Statistics.Players
{
    public abstract class MatchFilterBase : IPlayerStatisticCalculator<IEnumerable<MatchAppearance>>
    {
        private IPlayerStatisticCalculator<IEnumerable<MatchAppearance>> _calc;

        protected MatchFilterBase(IPlayerStatisticCalculator<IEnumerable<MatchAppearance>> calc)
        {
            if (calc == null) throw new ArgumentNullException("calc");
            _calc = calc;
        }

        protected abstract string FilterName { get; }
        protected abstract string FilterAbbreviation { get; }
        protected abstract IEnumerable<MatchAppearance> Filter (IEnumerable<MatchAppearance> matches);

        public string Name
        {
            get { return String.Format("{0} {1}", FilterName, _calc.Name); }
        }

        public string Abbreviation
        {
            get { return String.Format("{0}{1}", FilterAbbreviation, _calc.Abbreviation); }
        }

        public string Identifier
        {
            get { return Abbreviation; }
        }

        public object Calculate(IEnumerable<MatchAppearance> source)
        {
            return _calc.Calculate(Filter(source)); ;
        }

        public System.Collections.IComparer GetComparer()
        {
            return _calc.GetComparer();
        }

        public override string ToString()
        {
            return String.Format("{0} ({1})", Name, Abbreviation);
        }

        public IPrinter GetPrinter()
        {
            return _calc.GetPrinter();
        }
    }
}
