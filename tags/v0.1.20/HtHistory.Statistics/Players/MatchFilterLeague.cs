using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.ExtensionMethods;

namespace HtHistory.Statistics.Players
{
    public class MatchFilterLeague : MatchFilterBase
    {
        public MatchFilterLeague(IPlayerStatisticCalculator<IEnumerable<MatchAppearance>> calc) : base(calc) { }

        protected override string FilterName
        {
            get { return "League"; }
        }

        protected override string FilterAbbreviation
        {
            get { return "Lea"; }
        }

        protected override IEnumerable<MatchAppearance> Filter(IEnumerable<MatchAppearance> matches)
        {
            return matches.Where(m => m.Match.Type.IsLeagueMatch());
        }
    }
}
