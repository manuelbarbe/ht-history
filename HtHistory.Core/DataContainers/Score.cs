using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Core.DataContainers
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
            return String.Format("{0} : {1}", HomeGoals, AwayGoals);
        }
    }
}
