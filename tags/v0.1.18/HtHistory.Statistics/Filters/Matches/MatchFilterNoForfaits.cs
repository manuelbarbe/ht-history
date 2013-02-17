using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Statistics.Filters.Matches
{
    public class MatchFilterNoForfaits : IMatchFilter
    {
        public IEnumerable<Core.DataContainers.MatchDetails> Filter(IEnumerable<Core.DataContainers.MatchDetails> input)
        {
            return input.Where(m => m.Minutes > 0);
        }
    }
}
