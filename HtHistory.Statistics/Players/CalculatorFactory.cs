using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Statistics.Players
{
    public class CalculatorFactory
    {
        private static IList<IPlayerStatisticCalculator<IEnumerable<MatchAppearance>>> _standaloneCalculators
            = new List<IPlayerStatisticCalculator<IEnumerable<MatchAppearance>>>();

        private static IList<IPlayerStatisticCalculator<IEnumerable<MatchAppearance>>> _filteredCalculators
            = new List<IPlayerStatisticCalculator<IEnumerable<MatchAppearance>>>();

        static CalculatorFactory()
        {
            _standaloneCalculators.Add(new PlayerStatisticsCalculatorPlayerName());
            _standaloneCalculators.Add(new PlayerStatisticsCalculatorPlayerId());

            _filteredCalculators.Add(new PlayerStatisticsCalculatorMatches());
            _filteredCalculators.Add(new PlayerStatisticsCalculatorGoals());
            _filteredCalculators.Add(new PlayerStatisticsCalculatorMinutes());
            _filteredCalculators.Add(new PlayerStatisticsCalculatorBestPlayer());
            _filteredCalculators.Add(new PlayerStatisticsCalculatorFirstMatch());
            _filteredCalculators.Add(new PlayerStatisticsCalculatorLastMatch());
        }

        public static IEnumerable<IPlayerStatisticCalculator<IEnumerable<MatchAppearance>>> GetAllCalulators()
        {
            foreach (var c in _standaloneCalculators)
            {
                yield return c;
            }

            foreach (var c in _filteredCalculators)
            {
                yield return new MatchFilterTotal(c);
                yield return new MatchFilterLeague(c);
                yield return new MatchFilterCup(c);
                yield return new MatchFilterQualifier(c);
                yield return new MatchFilterFriendly(c);
                yield return new MatchFilterOther(c);
            }
        }

    }
}
