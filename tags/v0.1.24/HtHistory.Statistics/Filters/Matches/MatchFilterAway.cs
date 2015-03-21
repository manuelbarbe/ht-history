using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Statistics.Filters.Matches
{
    public class MatchFilterAway : IMatchFilter
    {
        private int _teamId;

        public MatchFilterAway(int teamId)
        {
            _teamId = teamId;
        }

        public IEnumerable<Core.DataContainers.MatchDetails> Filter(IEnumerable<Core.DataContainers.MatchDetails> input)
        {
            return input.Where(m => m.AwayTeam.ID == _teamId);
        }
    }
}
