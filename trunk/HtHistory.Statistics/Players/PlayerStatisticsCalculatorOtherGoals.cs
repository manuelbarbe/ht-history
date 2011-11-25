using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.ExtensionMethods;

namespace HtHistory.Statistics.Players
{
    public class PlayerStatisticsCalculatorOtherGoals : PlayerStatisticsCalculatorBase<IEnumerable<MatchAppearance>, int>
    {
        public override string Name { get { return "Other goals"; } }

        public override string Abbreviation { get { return "OthGoa"; } }

        public override int Calculate(IEnumerable<MatchAppearance> matches)
        {
            return matches.Where(m => m.Match.Type.IsOtherSeniorMatch()).Sum(m => m.Goals.Count);
        }
    }
}