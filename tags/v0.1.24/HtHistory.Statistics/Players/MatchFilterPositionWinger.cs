using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.ExtensionMethods;

namespace HtHistory.Statistics.Players
{
    class MatchFilterPositionWinger : MatchFilterBase
    {
        public MatchFilterPositionWinger(IPlayerStatisticCalculator<IEnumerable<MatchAppearance>> calc) : base(calc) { }

        protected override string FilterName
        {
            get { return "Winger"; }
        }

        protected override string FilterAbbreviation
        {
            get { return "W"; }
        }

        protected override IEnumerable<MatchAppearance> Filter(IEnumerable<MatchAppearance> matches)
        {
            return matches.Where(m => m.Role.IsWinger());
        }
    }
}
