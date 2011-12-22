using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.ExtensionMethods;

namespace HtHistory.Statistics.Players
{
    public class MatchFilterCompetitive : MatchFilterBase
    {
        public MatchFilterCompetitive(IPlayerStatisticCalculator<IEnumerable<MatchAppearance>> calc) : base(calc) { }

        protected override string FilterName
        {
            get { return "Competitive"; }
        }

        protected override string FilterAbbreviation
        {
            get { return "Com"; }
        }

        protected override IEnumerable<MatchAppearance> Filter(IEnumerable<MatchAppearance> matches)
        {
            return matches.Where(m => m.Match.Type.IsCompetitiveSeniorMatch());
        }
    }
}
