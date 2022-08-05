using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Data.Types;
using HtHistory.Toolbox;

namespace HtHistory.Statistics.Players
{
    public class PlayerStatisticsCalculatorPositionUnknown : PlayerStatisticsCalculatorBase<IEnumerable<MatchAppearance>, int>
    {
        public override string Name
        {
            get { return "Matches on unknown position"; }
        }

        public override string Abbreviation
        {
            get
            { return "Unkn"; }
        }

        public override int Calculate(IEnumerable<MatchAppearance> source)
        {
            return source.Count(m => m.Role.IsUnknownPosition());
        }
    }
}
