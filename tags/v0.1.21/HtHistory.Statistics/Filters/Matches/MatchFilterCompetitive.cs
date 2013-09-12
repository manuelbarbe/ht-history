using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.ExtensionMethods;

namespace HtHistory.Statistics.Filters.Matches
{
    public class MatchFilterCompetitive : IMatchFilter
    {
        public IEnumerable<Core.DataContainers.MatchDetails> Filter(IEnumerable<Core.DataContainers.MatchDetails> input)
        {
            return input.Where(m => m.Type.IsCompetitiveSeniorMatch()); 
        }
    }
}
