using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Toolbox;

namespace HtHistory.Statistics.Players
{
    public class PlayerStatisticsCalculatorMinutes : PlayerStatisticsCalculatorBase<IEnumerable<MatchAppearance>, int>
    {
        public override string Name { get { return "minutes"; } }

        public override string Abbreviation { get { return "Min"; } }

        public override int Calculate(IEnumerable<MatchAppearance> matches)
        {
            return matches.Sum(m => (int)m.Minutes);
        }
    }
}