using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Toolbox;

namespace HtHistory.Statistics.Players
{
    public class PlayerStatisticsCalculatorGoals : PlayerStatisticsCalculatorBase<IEnumerable<MatchAppearance>, int>
    {
        public override string Name { get { return "goals"; } }

        public override string Abbreviation { get { return "Goa"; } }

        public override int Calculate(IEnumerable<MatchAppearance> matches)
        {
            return matches.Sum(m => m.Goals.Count);
        }
    }
}
