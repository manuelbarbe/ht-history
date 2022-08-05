using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Data.Types;
using HtHistory.Toolbox;

namespace HtHistory.Statistics.Players
{
    public class PlayerStatisticsCalculatorPositionInnerMidfielder : PlayerStatisticsCalculatorBase<IEnumerable<MatchAppearance>, int>
    {
        public override string Name
        {
            get { return "Matches as inner midfielder"; }
        }

        public override string Abbreviation
        {
            get
            { return "IM"; }
        }

        public override int Calculate(IEnumerable<MatchAppearance> source)
        {
            return source.Count(m => m.Role.IsInnerMidfielder());
        }
    }
}
