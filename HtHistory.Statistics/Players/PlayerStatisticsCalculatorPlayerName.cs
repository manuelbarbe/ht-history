using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.ExtensionMethods;

namespace HtHistory.Statistics.Players
{
    public class PlayerStatisticsCalculatorPlayerName : PlayerStatisticsCalculatorBase<IEnumerable<MatchAppearance>, string>
    {
        public override string Name { get { return "Player name"; } }

        public override string Abbreviation { get { return "Name"; } }

        public override string Calculate(IEnumerable<MatchAppearance> matches)
        {
            MatchAppearance ma = matches.FirstOrDefault(m => m.Player.Name != HtHistory.Core.DataContainers.Player.UnknownName);

            if (ma == null) return HtHistory.Core.DataContainers.Player.UnknownName;
            else return ma.Player.Name;
        }
    }
}