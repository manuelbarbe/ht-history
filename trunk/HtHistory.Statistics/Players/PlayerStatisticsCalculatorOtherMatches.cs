using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.ExtensionMethods;

namespace HtHistory.Statistics.Players
{
    public class PlayerStatisticsCalculatorOtherMatches : PlayerStatisticsCalculatorBase<IEnumerable<MatchAppearance>, int>
    {
        public override string Name { get { return "Other matches"; } }

        public override string Abbreviation { get { return "OthMat"; } }

        public override int Calculate(IEnumerable<MatchAppearance> matches)
        {
            return matches.Count(m => m.Match.Type.IsOtherSeniorMatch());
        }
    }
}
