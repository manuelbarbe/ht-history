using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.ExtensionMethods;

namespace HtHistory.Statistics.Players
{
    public class PlayerStatisticsCalculatorCompetitiveBestPlayer : PlayerStatisticsCalculatorBase<IEnumerable<MatchAppearance>, int>
    {
        public override string Name { get { return "Man of the Match (competitive matches)"; } }

        public override string Abbreviation { get { return "ComMotM"; } }

        public override int Calculate(IEnumerable<MatchAppearance> matches)
        {
            return matches.Count(m => m.BestPlayer && m.Match.Type.IsCompetitiveSeniorMatch());
        }
    }
}
