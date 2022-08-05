using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Data.Types;

namespace HtHistory.Statistics.Filters.Matches
{
    public class MatchFilterNeutral : IMatchFilter
    {
        public MatchFilterNeutral()
        {
        }

        public IEnumerable<MatchDetails> Filter(IEnumerable<MatchDetails> input)
        {
            // TODO: implement
            return new List<MatchDetails>();
        }
    }
}
