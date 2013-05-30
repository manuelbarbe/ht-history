using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Statistics.Filters.Matches
{
    public class MatchFilterTeam : IMatchFilter
    {
        private uint _teamId;

        public MatchFilterTeam(uint teamId)
        {
            _teamId = teamId;
        }

        public IEnumerable<Core.DataContainers.MatchDetails> Filter(IEnumerable<Core.DataContainers.MatchDetails> input)
        {
            if (_teamId == 0) return input;
            return input.Where(m => m.HomeTeam.ID == _teamId || m.AwayTeam.ID == _teamId);
        }
    }
}
