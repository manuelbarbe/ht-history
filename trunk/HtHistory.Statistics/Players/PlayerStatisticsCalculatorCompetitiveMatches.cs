using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.ExtensionMethods;

namespace HtHistory.Statistics.Players
{
    public class PlayerStatisticsCalculatorCompetitiveMatches : PlayerStatisticsCalculatorBase<IEnumerable<MatchAppearance>, int>
    {
        public override string Name { get { return "Competitive matches"; } }

        public override string Abbreviation { get { return "ComMat"; } }

        public override int Calculate(IEnumerable<MatchAppearance> matches)
        {
            return matches.Where(m => m.Match.Type.IsCompetitiveSeniorMatch()).Count();
        }
    }
}
