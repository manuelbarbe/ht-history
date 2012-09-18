using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.DataContainers;
using HtHistory.Core.ExtensionMethods;

namespace HtHistory.Statistics.Filters.Matches
{
    public class MatchFilterIntersectionSet : IMatchFilter
    {
        private IEnumerable<IMatchFilter> _filters;

        public MatchFilterIntersectionSet(IEnumerable<IMatchFilter> filters)
        {
            _filters = filters ?? new List<IMatchFilter>();
        }

        public IEnumerable<MatchDetails> Filter(IEnumerable<MatchDetails> input)
        {
            IEnumerable<MatchDetails> resultSet = input;

            foreach (IMatchFilter filter in _filters.SafeEnum())
            {
                resultSet = resultSet.Intersect(filter.Filter(input));
            }

            return resultSet;
        }

    }
}
