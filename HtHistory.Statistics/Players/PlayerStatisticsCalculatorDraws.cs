using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Data.Types;

namespace HtHistory.Statistics.Players
{
    public class PlayerStatisticsCalculatorDraws : PlayerStatisticsCalculatorBase<IEnumerable<MatchAppearance>, int>
    {
        public override string Name
        {
            get { return "Draws"; }
        }

        public override string Abbreviation
        {
            get
            { return "Draw"; }
        }

        public override int Calculate(IEnumerable<MatchAppearance> source)
        {
            return source.Count(m => (TeamGoalDiff(m.Match, m.TeamOfPlayer) == 0));
        }

        private int TeamGoalDiff(Match match, Team team)
        {
            int diff = (int)match.FinalScore.HomeGoals - (int)match.FinalScore.AwayGoals;

            if (team.ID == match.AwayTeam.ID) return -diff;
            return diff;
        }
    }
}
