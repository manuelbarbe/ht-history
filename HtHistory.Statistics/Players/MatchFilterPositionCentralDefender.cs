using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Toolbox;
using HtHistory.Data.Types;

namespace HtHistory.Statistics.Players
{
    class MatchFilterPositionCentralDefender : MatchFilterBase
    {
        public MatchFilterPositionCentralDefender(IPlayerStatisticCalculator<IEnumerable<MatchAppearance>> calc) : base(calc) { }

        protected override string FilterName
        {
            get { return "Central Defender"; }
        }

        protected override string FilterAbbreviation
        {
            get { return "CD"; }
        }

        protected override IEnumerable<MatchAppearance> Filter(IEnumerable<MatchAppearance> matches)
        {
            return matches.Where(m => m.Role.IsCentralDefender());
        }
    }
}
