using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.ExtensionMethods;
using System.Globalization;
using HtHistory.Statistics.Printer;

namespace HtHistory.Statistics.Players
{
    public class PlayerStatisticsCalculatorWinsPercentage : PlayerStatisticsCalculatorBase<IEnumerable<MatchAppearance>, double?>
    {
        public override string Name { get { return "wins in %"; } }

        public override string Abbreviation { get { return "Win%"; } }

        public override double? Calculate(IEnumerable<MatchAppearance> matches)
        {
            int matchesCnt = new PlayerStatisticsCalculatorMatches().Calculate(matches);

            if (matchesCnt == 0) return null;

            return (double)
                new PlayerStatisticsCalculatorWins().Calculate(matches) / matchesCnt;
        }

        private static IPrinter _printer;
        static PlayerStatisticsCalculatorWinsPercentage()
        {
            _printer = new PercentagePrinter();
        }

        public override IPrinter GetPrinter()
        {
            return _printer;
        }
    }
}