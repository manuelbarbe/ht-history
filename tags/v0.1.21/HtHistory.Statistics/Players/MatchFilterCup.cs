using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.ExtensionMethods;

namespace HtHistory.Statistics.Players
{
    public class MatchFilterCup : MatchFilterBase
    {
        public MatchFilterCup(IPlayerStatisticCalculator<IEnumerable<MatchAppearance>> calc) : base(calc) { }

        protected override string FilterName
        {
            get { return "Cup"; }
        }

        protected override string FilterAbbreviation
        {
            get { return "Cup"; }
        }

        protected override IEnumerable<MatchAppearance> Filter(IEnumerable<MatchAppearance> matches)
        {
            return matches.Where(m => m.Match.Type.IsCupMatch());
        }
    }
}
