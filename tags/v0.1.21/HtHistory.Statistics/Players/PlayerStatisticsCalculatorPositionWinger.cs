using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.DataContainers;
using HtHistory.Core.ExtensionMethods;

namespace HtHistory.Statistics.Players
{
    public class PlayerStatisticsCalculatorPositionWinger : PlayerStatisticsCalculatorBase<IEnumerable<MatchAppearance>, int>
    {
        public override string Name
        {
            get { return "Matches as Winger"; }
        }

        public override string Abbreviation
        {
            get
            { return "Wing"; }
        }

        public override int Calculate(IEnumerable<MatchAppearance> source)
        {
            return source.Count(m => m.Role.IsWinger());
        }
    }
}
