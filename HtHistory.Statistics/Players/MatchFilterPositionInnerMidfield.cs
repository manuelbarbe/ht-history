using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.ExtensionMethods;

namespace HtHistory.Statistics.Players
{
    class MatchFilterPositionInnerMidfield : MatchFilterBase
    {
        public MatchFilterPositionInnerMidfield(IPlayerStatisticCalculator<IEnumerable<MatchAppearance>> calc) : base(calc) { }

        protected override string FilterName
        {
            get { return "Inner Midfield"; }
        }

        protected override string FilterAbbreviation
        {
            get { return "IM"; }
        }

        protected override IEnumerable<MatchAppearance> Filter(IEnumerable<MatchAppearance> matches)
        {
            return matches.Where(m => m.Role.IsInnerMidfielder());
        }
    }
}
