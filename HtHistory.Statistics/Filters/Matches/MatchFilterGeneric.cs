using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Data.Types;

namespace HtHistory.Statistics.Filters.Matches
{
    public class MatchFilterGeneric : IMatchFilter
    {
        Func<MatchDetails, bool> _pred;

        public MatchFilterGeneric(Func<MatchDetails, bool> pred)
        {
            if (pred == null) throw new ArgumentNullException("pred");
            _pred = pred;
        }

        public IEnumerable<MatchDetails> Filter(IEnumerable<MatchDetails> input)
        {
            return input.Where(_pred);
        }
    }
}
