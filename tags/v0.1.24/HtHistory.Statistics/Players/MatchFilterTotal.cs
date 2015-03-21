using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.ExtensionMethods;

namespace HtHistory.Statistics.Players
{
    public class MatchFilterTotal : MatchFilterBase
    {
        public MatchFilterTotal(IPlayerStatisticCalculator<IEnumerable<MatchAppearance>> calc) : base(calc) { }

        protected override string FilterName
        {
            get { return "Total"; }
        }

        protected override string FilterAbbreviation
        {
            get { return "Tot"; }
        }

        protected override IEnumerable<MatchAppearance> Filter(IEnumerable<MatchAppearance> matches)
        {
            return matches.Where(m => !m.Match.Type.IsNonSeniorMatch());
        }
    }
}
