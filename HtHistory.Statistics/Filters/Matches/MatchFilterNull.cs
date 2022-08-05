using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Statistics.Filters.Matches
{
    public class MatchFilterNull : IMatchFilter
    {
        public IEnumerable<Data.Types.MatchDetails> Filter(IEnumerable<Data.Types.MatchDetails> input)
        {
            return input;
        }
    }
}
