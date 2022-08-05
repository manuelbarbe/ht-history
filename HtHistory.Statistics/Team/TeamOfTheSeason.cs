using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Data.Types;
using HtHistory.Statistics.Players;
using HtHistory.Toolbox;


namespace HtHistory.Statistics.TeamStats
{
    
    public class TeamOfTheSeason
    {
        public class PlayerResult
        {
            public Player Player;
            public object Result;
        }


        public Lineup GetFor(IPlayerStatisticCalculator<IEnumerable<MatchAppearance>> theStatistic,
                             IDictionary<Player, IEnumerable<MatchAppearance>> matchAppearances)
        {
            //TODO: just a brute force 4-4-2 implementation
            var goalieStat = new MatchFilterPositionGoalkeeper(theStatistic);

            var results = matchAppearances.Select(pair => new PlayerResult() { Player = pair.Key, Result = null });
            //var results = matchAppearances.Keys.Select(player => player.Name);


            foreach (var pair in matchAppearances)
            {
                //playersAndResults.Add(pair.Key, goalieStat.Calculate(pair.Value));
            }

            return null;
        }

    
    
    }
}
