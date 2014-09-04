using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Statistics.Filters.Matches
{
    public class MatchFilterHome : IMatchFilter
    {
        private uint _teamId;

        public MatchFilterHome(uint teamId)
        {
            _teamId = teamId;
        }

        public IEnumerable<Core.DataContainers.MatchDetails> Filter(IEnumerable<Core.DataContainers.MatchDetails> input)
        {
            return input.Where(m => m.HomeTeam.ID == _teamId);
        }
    }
}
