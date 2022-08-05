using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Toolbox;

namespace HtHistory.Statistics.Players
{
    public class PlayerStatisticsCalculatorMatches : PlayerStatisticsCalculatorBase<IEnumerable<MatchAppearance>, int>
    {
        public override string Name { get { return "matches"; } }

        public override string Abbreviation { get { return "Mat"; } }

        public override int Calculate(IEnumerable<MatchAppearance> matches)
        {
            return matches.Count();
        }
    }
}
