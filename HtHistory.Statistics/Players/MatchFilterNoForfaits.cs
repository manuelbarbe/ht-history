using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Toolbox;

namespace HtHistory.Statistics.Players
{
    public class MatchFilterNoForfaits : MatchFilterBase
    {
        public MatchFilterNoForfaits(IPlayerStatisticCalculator<IEnumerable<MatchAppearance>> calc) : base(calc) { }

        protected override string FilterName
        {
            get { return string.Empty; }
        }

        protected override string FilterAbbreviation
        {
            get { return string.Empty; }
        }

        protected override IEnumerable<MatchAppearance> Filter(IEnumerable<MatchAppearance> matches)
        {
            return matches.Where(m => m.Match.Minutes != 0);
        }
    }
}
