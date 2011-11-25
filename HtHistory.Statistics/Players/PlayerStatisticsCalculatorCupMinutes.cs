using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.ExtensionMethods;

namespace HtHistory.Statistics.Players
{
    public class PlayerStatisticsCalculatorCupMinutes : PlayerStatisticsCalculatorBase<IList<MatchAppearance>, int>
    {
        public override string Name { get { return "Cup minutes"; } }

        public override int Calculate(IList<MatchAppearance> matches)
        {
            return matches.Where(m => m.Match.Type.IsCupMatch()).Sum(m => (int)m.Minutes);
        }
    }
}
