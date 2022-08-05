using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Data.Types;

namespace HtHistory.Statistics.Filters.Matches
{
    public class MatchFilterSeason : IMatchFilter
    {
        private int _season;

        public MatchFilterSeason(int season)
        {
            _season = season;
        }

        public IEnumerable<Data.Types.MatchDetails> Filter(IEnumerable<Data.Types.MatchDetails> input)
        {
            return input.Where(m => new HtTime(m.Date).Season == _season);
        }
    }
}
