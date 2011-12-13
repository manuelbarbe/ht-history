using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.ExtensionMethods;

namespace HtHistory.Statistics.Players
{
    public class PlayerStatisticsCalculatorMostStars : PlayerStatisticsCalculatorBase<IEnumerable<MatchAppearance>, double?>
    {
        public override string Name { get { return "Most stars"; } }

        public override string Abbreviation { get { return "Stars"; } }

        public override double? Calculate(IEnumerable<MatchAppearance> matches)
        {
            return matches.Max(m => m.RatingStars);
        }

        private static IPrinter _printer;
        static PlayerStatisticsCalculatorMostStars()
        {
            _printer = new DoublePrinter1();
        }

        public override IPrinter GetPrinter()
        {
            return _printer;
        }
    }
}