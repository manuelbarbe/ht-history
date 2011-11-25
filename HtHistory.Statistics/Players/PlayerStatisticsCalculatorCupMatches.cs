using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.ExtensionMethods;

namespace HtHistory.Statistics.Players
{
    public class PlayerStatisticsCalculatorCupMatches : PlayerStatisticsCalculatorBase<IEnumerable<MatchAppearance>, int>
    {
        public override string Name { get { return "Cup matches"; } }

        public override string Abbreviation { get { return "CupMat"; } }

        public override int Calculate(IEnumerable<MatchAppearance> matches)
        {
            return matches.Count(m => m.Match.Type.IsCupMatch());
        }
    }
}
