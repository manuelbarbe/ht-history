﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Toolbox;
using System.Globalization;

namespace HtHistory.Statistics.Players
{
    public class PlayerStatisticsCalculatorGoalsPer90Minutes : PlayerStatisticsCalculatorBase<IEnumerable<MatchAppearance>, double?>
    {
        public override string Name { get { return "goals per 90 minutes"; } }

        public override string Abbreviation { get { return "Gp90Min"; } }

        public override double? Calculate(IEnumerable<MatchAppearance> matches)
        {
            int minutesCnt = new PlayerStatisticsCalculatorMinutes().Calculate(matches);

            if (minutesCnt == 0) return null;

            return (double)
                new PlayerStatisticsCalculatorGoals().Calculate(matches) * 90 / minutesCnt;
        }

        private static IPrinter _printer;
        static PlayerStatisticsCalculatorGoalsPer90Minutes()
        {
            _printer = new DoublePrinter2();
        }

        public override IPrinter GetPrinter()
        {
            return _printer;
        }    
    }
}