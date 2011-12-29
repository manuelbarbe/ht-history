using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Statistics.Players
{
    public class PlayerStatisticsCalculatorYellowCards : PlayerStatisticsCalculatorBase<IEnumerable<MatchAppearance>, int>
    {
        public override string Name
        {
            get { return "Yellow cards"; }
        }

        public override string Abbreviation
        {
            get { return "Yellow"; }
        }

        public override int Calculate(IEnumerable<MatchAppearance> source)
        {
            return source.Count(m => m.YellowCarded != null);
        }
    }
}
