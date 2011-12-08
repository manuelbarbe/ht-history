using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.ExtensionMethods;
using HtHistory.Core.DataContainers;

namespace HtHistory.Statistics.Players
{
    public class MatchFilterSeason : MatchFilterBase
    {
        private int _season;

        public MatchFilterSeason(int season, IPlayerStatisticCalculator<IEnumerable<MatchAppearance>> calc) : base(calc)
        {
            _season = season;
        }

        protected override string FilterName
        {
            get { return string.Empty; }
        }

        protected override string FilterAbbreviation
        {
            get { return string.Empty; }
        }

        protected override IEnumerable<MatchAppearance> Filter(IEnumerable<MatchAppearance> matches)
        {
            return matches.Where(m => new HtTime(m.Match.Date).Season == _season);
        }
    }
}
