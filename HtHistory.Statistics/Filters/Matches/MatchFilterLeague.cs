using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Toolbox;
using HtHistory.Data.Types;

namespace HtHistory.Statistics.Filters.Matches
{
    public class MatchFilterLeague : IMatchFilter
    {
        public IEnumerable<Data.Types.MatchDetails> Filter(IEnumerable<Data.Types.MatchDetails> input)
        {
            return input.Where(m => m.Type.IsLeagueMatch());
        }
    }
}
