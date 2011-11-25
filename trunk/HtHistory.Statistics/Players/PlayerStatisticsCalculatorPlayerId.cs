using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.ExtensionMethods;

namespace HtHistory.Statistics.Players
{
    public class PlayerStatisticsCalculatorPlayerId : PlayerStatisticsCalculatorBase<IEnumerable<MatchAppearance>, uint>
    {
        public override string Name { get { return "Player ID"; } }

        public override string Abbreviation { get { return "ID"; } }

        public override uint Calculate(IEnumerable<MatchAppearance> matches)
        {
            MatchAppearance ma = matches.FirstOrDefault();

            if (ma == null) return 0;
            else return ma.Player.ID;
        }
    }
}