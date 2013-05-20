using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Statistics.Players
{
    public class PlayerStatisticsCalculatorHattricks : PlayerStatisticsCalculatorBase<IEnumerable<MatchAppearance>, int>
    {

        public override string Name
        {
            get { return "Hattricks"; }
        }

        public override string Abbreviation
        {
            get { return "Hat"; }
        }

        public override int Calculate(IEnumerable<MatchAppearance> source)
        {
            return source.Count(m => (m.Goals != null) && m.Goals.Count >= 3);
        }
    }
}
