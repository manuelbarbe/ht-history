using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.ExtensionMethods;
using System.Globalization;
using HtHistory.Statistics.Printer;

namespace HtHistory.Statistics.Players
{
    public class PlayerStatisticsCalculatorLossesPercentage : PlayerStatisticsCalculatorBase<IEnumerable<MatchAppearance>, double?>
    {
        public override string Name { get { return "losses in %"; } }

        public override string Abbreviation { get { return "Los%"; } }

        public override double? Calculate(IEnumerable<MatchAppearance> matches)
        {
            int matchesCnt = new PlayerStatisticsCalculatorMatches().Calculate(matches);

            if (matchesCnt == 0) return null;

            return (double)
                new PlayerStatisticsCalculatorLosses().Calculate(matches) / matchesCnt;
        }

        private static IPrinter _printer;
        static PlayerStatisticsCalculatorLossesPercentage()
        {
            _printer = new PercentagePrinter();
        }

        public override IPrinter GetPrinter()
        {
            return _printer;
        }
    }
}