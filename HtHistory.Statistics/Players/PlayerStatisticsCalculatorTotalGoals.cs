using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.ExtensionMethods;

namespace HtHistory.Statistics.Players
{
    public class PlayerStatisticsCalculatorTotalGoals : PlayerStatisticsCalculatorBase<IList<MatchAppearance>, int>
    {
        public override string Name { get { return "Total goals"; } }

        public override int Calculate(IList<MatchAppearance> matches)
        {
            return matches.Where(m => !m.Match.Type.IsNonSeniorMatch()).Sum( m => m.Goals.Count );
        }
    }
}
