using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.ExtensionMethods;

namespace HtHistory.Statistics.Players
{
    class MatchFilterPositionForward : MatchFilterBase
    {
        public MatchFilterPositionForward(IPlayerStatisticCalculator<IEnumerable<MatchAppearance>> calc) : base(calc) { }

        protected override string FilterName
        {
            get { return "Forward"; }
        }

        protected override string FilterAbbreviation
        {
            get { return "FW"; }
        }

        protected override IEnumerable<MatchAppearance> Filter(IEnumerable<MatchAppearance> matches)
        {
            return matches.Where(m => m.Role.IsForward());
        }
    }
}
