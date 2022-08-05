using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Toolbox;

namespace HtHistory.Statistics.Players
{
    public class PlayerStatisticsCalculatorFirstMatch : PlayerStatisticsCalculatorBase<IEnumerable<MatchAppearance>, DateTime?>
    {
        public override string Name { get { return "First match"; } }

        public override string Abbreviation { get { return "First"; } }

        public override DateTime? Calculate(IEnumerable<MatchAppearance> matches)
        {
            if (matches.Count() == 0) return null;
            return matches.Min(m => m.Match.Date);
        }
    }
}