using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.ExtensionMethods;

namespace HtHistory.Statistics.Players
{
    public class PlayerStatisticsCalculatorFriendlyGoals : PlayerStatisticsCalculatorBase<IList<MatchAppearance>, int>
    {
        public override string Name { get { return "Friendly goals"; } }

        public override int Calculate(IList<MatchAppearance> matches)
        {
            return matches.Where(m => m.Match.Type.IsFriendlyMatch()).Sum(m => m.Goals.Count);
        }
    }
}