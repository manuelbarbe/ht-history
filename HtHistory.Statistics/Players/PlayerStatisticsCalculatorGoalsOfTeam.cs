using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Data.Types;

namespace HtHistory.Statistics.Players
{
    public class PlayerStatisticsCalculatorGoalsOfTeam : PlayerStatisticsCalculatorBase<IEnumerable<MatchAppearance>, int>
    {
        public override string Name
        {
            get { return "Goals of team"; }
        }

        public override string Abbreviation
        {
            get
            { return "TeamGoa"; }
        }

        public override int Calculate(IEnumerable<MatchAppearance> source)
        {
            return source.Sum(m => GetGoals(m.Match, m.TeamOfPlayer));
        }

        private int GetGoals(Match match, Team team)
        {
            if (team.ID == match.HomeTeam.ID) return (int)match.FinalScore.HomeGoals;
            return (int)match.FinalScore.AwayGoals;
        }
    }
}
