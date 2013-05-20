using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.DataContainers;
using HtHistory.Core.ExtensionMethods;

namespace HtHistory.Statistics.Filters.Matches
{
    public interface IMatchFilter
    {
        IEnumerable<MatchDetails> Filter(IEnumerable<MatchDetails> input);
    }
}
