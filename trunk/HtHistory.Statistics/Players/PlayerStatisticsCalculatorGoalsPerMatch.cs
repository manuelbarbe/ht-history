using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.ExtensionMethods;
using System.Globalization;

namespace HtHistory.Statistics.Players
{
    public class PlayerStatisticsCalculatorGoalsPerMatch : PlayerStatisticsCalculatorBase<IEnumerable<MatchAppearance>, double?>
    {
        public override string Name { get { return "goals per match"; } }

        public override string Abbreviation { get { return "GpM"; } }

        public override double? Calculate(IEnumerable<MatchAppearance> matches)
        {
            int matchesCnt = new PlayerStatisticsCalculatorMatches().Calculate(matches);

            if (matchesCnt == 0) return null;

            return (double)
                new PlayerStatisticsCalculatorGoals().Calculate(matches) / matchesCnt;
        }

        private static IPrinter _printer;
        static PlayerStatisticsCalculatorGoalsPerMatch()
        {
            _printer = new DoublePrinter2();
        }

        public override IPrinter GetPrinter()
        {
            return _printer;
        }     
    }
}