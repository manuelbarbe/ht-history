using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Toolbox;

namespace HtHistory.Statistics.Players
{
    public class PlayerStatisticsCalculatorBestPlayer : PlayerStatisticsCalculatorBase<IEnumerable<MatchAppearance>, int>
    {
        public override string Name { get { return "Man of the Match"; } }

        public override string Abbreviation { get { return "MotM"; } }

        public override int Calculate(IEnumerable<MatchAppearance> matches)
        {
            return matches.Count(m => m.BestPlayer);
        }
    }
}
