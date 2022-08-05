using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Toolbox;
using HtHistory.Data.Types;

namespace HtHistory.Statistics.Filters.Matches
{
    public class MatchFilterUnionSet : IMatchFilter
    {
        private IEnumerable<IMatchFilter> _filters;

        public MatchFilterUnionSet(IEnumerable<IMatchFilter> filters)
        {
            _filters = filters ?? new List<IMatchFilter>();
        }

        public IEnumerable<MatchDetails> Filter(IEnumerable<MatchDetails> input)
        {
            if (_filters == null || _filters.Count() == 0) return input;

            IEnumerable<MatchDetails> resultSet = new MatchDetails[0];

            foreach (IMatchFilter filter in _filters.SafeEnum())
            {
                resultSet = resultSet.Union(filter.Filter(input));
            }

            return resultSet;
        }
    }
}
