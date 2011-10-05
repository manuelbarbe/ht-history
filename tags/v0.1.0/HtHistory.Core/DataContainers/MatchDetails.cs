using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Core.DataContainers
{
    public class MatchDetails : Match
    {
        public MatchDetails(uint id, MatchType type, Team home, Team away)
            : base(id, type, home, away)
        {
        }

        public IEnumerable<Goal> Goals { get; set; }
        public IEnumerable<MatchEvent> Events { get; set; }

        public Lineup HomeLineup { get; set; }
        public Lineup AwayLineup { get; set; }
    }
}
