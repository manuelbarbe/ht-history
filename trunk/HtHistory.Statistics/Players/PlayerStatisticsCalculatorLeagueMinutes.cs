using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.ExtensionMethods;

namespace HtHistory.Statistics.Players
{
    public class PlayerStatisticsCalculatorLeagueMinutes : PlayerStatisticsCalculatorBase<IEnumerable<MatchAppearance>, int>
    {
        public override string Name { get { return "League minutes"; } }

        public override string Abbreviation { get { return "LeaMin"; } }

        public override int Calculate(IEnumerable<MatchAppearance> matches)
        {
            return matches.Where(m => m.Match.Type.IsLeagueMatch()).Sum(m => (int)m.Minutes);
        }
    }
}