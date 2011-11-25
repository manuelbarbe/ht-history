using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.ExtensionMethods;

namespace HtHistory.Statistics.Players
{
    public class PlayerStatisticsCalculatorCompetitiveGoals : PlayerStatisticsCalculatorBase<IEnumerable<MatchAppearance>, int>
    {
        public override string Name { get { return "Competitive goals"; } }

        public override string Abbreviation { get { return "ComGoa"; } }

        public override int Calculate(IEnumerable<MatchAppearance> matches)
        {
            return matches.Where(m => m.Match.Type.IsCompetitiveSeniorMatch()).Sum(m => m.Goals.Count);
        }
    }
}
