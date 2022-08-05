using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Data.Types;
using HtHistory.Toolbox;

namespace HtHistory.Statistics.Filters.Matches
{
    public interface IMatchFilter
    {
        IEnumerable<MatchDetails> Filter(IEnumerable<MatchDetails> input);
    }
}
