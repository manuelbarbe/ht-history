using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Statistics.Players
{
    public class PlayerStatisticsCalculatorBruised : PlayerStatisticsCalculatorBase<IEnumerable<MatchAppearance>, int>
    {
        public override string Name
        {
            get { return "Bruised"; }
        }

        public override string Abbreviation
        {
            get { return "Bru"; }
        }

        public override int Calculate(IEnumerable<MatchAppearance> source)
        {
            return source.Count(m => m.Bruised != null);
        }
    }
}
