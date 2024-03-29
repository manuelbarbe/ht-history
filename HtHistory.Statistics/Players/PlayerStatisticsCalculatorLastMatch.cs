﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Toolbox;

namespace HtHistory.Statistics.Players
{
    public class PlayerStatisticsCalculatorLastMatch : PlayerStatisticsCalculatorBase<IEnumerable<MatchAppearance>, DateTime?>
    {
        public override string Name { get { return "Last match"; } }

        public override string Abbreviation { get { return "Last"; } }

        public override DateTime? Calculate(IEnumerable<MatchAppearance> matches)
        {
            if (matches.Count() == 0) return null;
            return matches.Max(m => m.Match.Date);
        }
    }
}