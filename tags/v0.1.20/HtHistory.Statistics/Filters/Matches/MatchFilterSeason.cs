using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.DataContainers;

namespace HtHistory.Statistics.Filters.Matches
{
    public class MatchFilterSeason : IMatchFilter
    {
        private int _season;

        public MatchFilterSeason(int season)
        {
            _season = season;
        }

        public IEnumerable<Core.DataContainers.MatchDetails> Filter(IEnumerable<Core.DataContainers.MatchDetails> input)
        {
            return input.Where(m => new HtTime(m.Date).Season == _season);
        }
    }
}
