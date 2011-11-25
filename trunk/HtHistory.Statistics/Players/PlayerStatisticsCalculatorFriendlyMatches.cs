using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.ExtensionMethods;

namespace HtHistory.Statistics.Players
{
    public class PlayerStatisticsCalculatorFriendlyMatches : PlayerStatisticsCalculatorBase<IEnumerable<MatchAppearance>, int>
    {
        public override string Name { get { return "Friendly matches"; } }

        public override string Abbreviation { get { return "FriMat"; } }

        public override int Calculate(IEnumerable<MatchAppearance> matches)
        {
            return matches.Count(m => m.Match.Type.IsFriendlyMatch());
        }
    }
}
