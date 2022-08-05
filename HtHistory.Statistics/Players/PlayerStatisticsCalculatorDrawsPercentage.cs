using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Toolbox;
using System.Globalization;
using HtHistory.Statistics.Printer;

namespace HtHistory.Statistics.Players
{
    public class PlayerStatisticsCalculatorDrawsPercentage : PlayerStatisticsCalculatorBase<IEnumerable<MatchAppearance>, double?>
    {
        public override string Name { get { return "draws in %"; } }

        public override string Abbreviation { get { return "Draw%"; } }

        public override double? Calculate(IEnumerable<MatchAppearance> matches)
        {
            int matchesCnt = new PlayerStatisticsCalculatorMatches().Calculate(matches);

            if (matchesCnt == 0) return null;

            return (double)
                new PlayerStatisticsCalculatorDraws().Calculate(matches) / matchesCnt;
        }

        private static IPrinter _printer;
        static PlayerStatisticsCalculatorDrawsPercentage()
        {
            _printer = new PercentagePrinter();
        }

        public override IPrinter GetPrinter()
        {
            return _printer;
        }
    }
}