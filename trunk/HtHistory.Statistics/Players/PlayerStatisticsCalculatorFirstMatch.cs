using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.ExtensionMethods;

namespace HtHistory.Statistics.Players
{
    public class PlayerStatisticsCalculatorFirstMatch : PlayerStatisticsCalculatorBase<IList<MatchAppearance>, DateTime>
    {
        public override string Name { get { return "First match"; } }

        public override DateTime Calculate(IList<MatchAppearance> matches)
        {
            return matches.Min(m => m.Match.Date);
        }
    }
}