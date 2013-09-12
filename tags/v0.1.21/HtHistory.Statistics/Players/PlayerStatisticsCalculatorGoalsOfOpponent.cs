using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.DataContainers;

namespace HtHistory.Statistics.Players
{
    public class PlayerStatisticsCalculatorGoalsOfOpponent : PlayerStatisticsCalculatorBase<IEnumerable<MatchAppearance>, int>
    {
        public override string Name
        {
            get { return "Goals of opponent"; }
        }

        public override string Abbreviation
        {
            get
            { return "OppGoa"; }
        }

        public override int Calculate(IEnumerable<MatchAppearance> source)
        {
            return source.Sum(m => GetOpponentGoals(m.Match, m.TeamOfPlayer));
        }

        private int GetOpponentGoals(Match match, Team team)
        {
            if (team.ID == match.HomeTeam.ID) return (int)match.FinalScore.AwayGoals;
            return (int)match.FinalScore.HomeGoals;
        }
    }
}
