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

        public IEnumerable<Data.Types.MatchDetails> Filter(IEnumerable<Data.Types.MatchDetails> input)
        {
            return input.Where(m => m.AwayTeam.ID == _teamId);
        }
    }
}
