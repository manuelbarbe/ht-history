using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Core.DataContainers
{
    public class Goal
    {
        public Goal(Match match, uint minute, Score score, Team team, Player scorer)
        {
            Match = match;
            Minute = minute;
            Score = score;
            Team = team;
            Scorer = scorer;
        }

        public Match Match { get; set; }
        public uint Minute { get; set; }    
        public Score Score { get; set; }
        public Team Team { get; set; }
        public Player Scorer { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}.min {3}", Match, Score, Minute, Scorer);
        }
        
    }
}
