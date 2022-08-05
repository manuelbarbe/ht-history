using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Data.Types
{
    public class Score
    {
        public Score(uint homeGoals, uint awayGoals)
        {
            HomeGoals = homeGoals;
            AwayGoals = awayGoals;
        }

        public uint HomeGoals { get; set; }
        public uint AwayGoals { get; set; }

        public override string ToString()
        {
            return string.Format("{0}:{1}", HomeGoals, AwayGoals);
        }
    }
}
