using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Toolbox;
using HtHistory.Data.Types;

namespace HtHistory.Statistics.Players
{
    class MatchFilterPositionWingBack : MatchFilterBase
    {
        public MatchFilterPositionWingBack(IPlayerStatisticCalculator<IEnumerable<MatchAppearance>> calc) : base(calc) { }

        protected override string FilterName
        {
            get { return "Wing Back"; }
        }

        protected override string FilterAbbreviation
        {
            get { return "WB"; }
        }

        protected override IEnumerable<MatchAppearance> Filter(IEnumerable<MatchAppearance> matches)
        {
            return matches.Where(m => m.Role.IsWingBack());
        }
    }
}
