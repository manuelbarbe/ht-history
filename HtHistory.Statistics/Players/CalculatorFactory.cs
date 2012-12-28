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

        private static IList<IPlayerStatisticCalculator<IEnumerable<MatchAppearance>>> _allCalculators
            = new List<IPlayerStatisticCalculator<IEnumerable<MatchAppearance>>>();

        static CalculatorFactory()
        {
            _standaloneCalculators.Add(new PlayerStatisticsCalculatorPlayerName());
            _standaloneCalculators.Add(new PlayerStatisticsCalculatorPlayerId());

            _filteredCalculators.Add(new PlayerStatisticsCalculatorMatches());
            _filteredCalculators.Add(new PlayerStatisticsCalculatorSubstituteIn());
            _filteredCalculators.Add(new PlayerStatisticsCalculatorSubstituteOut());
            _filteredCalculators.Add(new PlayerStatisticsCalculatorWins());
            _filteredCalculators.Add(new PlayerStatisticsCalculatorWinsPercentage());
            _filteredCalculators.Add(new PlayerStatisticsCalculatorDraws());
            _filteredCalculators.Add(new PlayerStatisticsCalculatorDrawsPercentage());
            _filteredCalculators.Add(new PlayerStatisticsCalculatorLosses());
            _filteredCalculators.Add(new PlayerStatisticsCalculatorLossesPercentage());
            _filteredCalculators.Add(new PlayerStatisticsCalculatorGoals());
            _filteredCalculators.Add(new PlayerStatisticsCalculatorGoalsPerMatch());
            _filteredCalculators.Add(new PlayerStatisticsCalculatorGoalsPer90Minutes());
            _filteredCalculators.Add(new PlayerStatisticsCalculatorMinutes());
            _filteredCalculators.Add(new PlayerStatisticsCalculatorMinutesPerMatch());
            _filteredCalculators.Add(new PlayerStatisticsCalculatorBestPlayer());
            _filteredCalculators.Add(new PlayerStatisticsCalculatorYellowCards());
            _filteredCalculators.Add(new PlayerStatisticsCalculatorRedCards());
            _filteredCalculators.Add(new PlayerStatisticsCalculatorBruised());
            _filteredCalculators.Add(new PlayerStatisticsCalculatorInjured());
            _filteredCalculators.Add(new PlayerStatisticsCalculatorFirstMatch());
            _filteredCalculators.Add(new PlayerStatisticsCalculatorLastMatch());
            _filteredCalculators.Add(new PlayerStatisticsCalculatorPositionKeeper());
            _filteredCalculators.Add(new PlayerStatisticsCalculatorPositionCentralDefender());
            _filteredCalculators.Add(new PlayerStatisticsCalculatorPositionWingBack());
            _filteredCalculators.Add(new PlayerStatisticsCalculatorPositionInnerMidfielder());
            _filteredCalculators.Add(new PlayerStatisticsCalculatorPositionWinger());
            _filteredCalculators.Add(new PlayerStatisticsCalculatorPositionForward());
            _filteredCalculators.Add(new PlayerStatisticsCalculatorPositionUnknown());
            _filteredCalculators.Add(new PlayerStatisticsCalculatorGoalsOfTeam());
            _filteredCalculators.Add(new PlayerStatisticsCalculatorGoalsOfOpponent());
            _filteredCalculators.Add(new PlayerStatisticsCalculatorMostStars());
            _filteredCalculators.Add(new PlayerStatisticsCalculatorHattricks());
            _filteredCalculators.Add(new PlayerStatisticsCalculatorMaxMinutesWithoutGoal());


            foreach (var v in CreateAllCalulators())
            {
                _allCalculators.Add(v);
            }
        }

        private static IEnumerable<IPlayerStatisticCalculator<IEnumerable<MatchAppearance>>> CreateAllCalulators()
        {
            foreach (var c in _standaloneCalculators)
            {
                yield return c;
            }

            foreach (var c in _filteredCalculators) yield return new MatchFilterTotal(c);
            foreach (var c in _filteredCalculators) yield return new MatchFilterCompetitive(c);
            foreach (var c in _filteredCalculators) yield return new MatchFilterLeague(c);
            foreach (var c in _filteredCalculators) yield return new MatchFilterCup(c);
            foreach (var c in _filteredCalculators) yield return new MatchFilterQualifier(c);
            foreach (var c in _filteredCalculators) yield return new MatchFilterFriendly(c);
            foreach (var c in _filteredCalculators) yield return new MatchFilterOther(c);
        }

        public static IEnumerable<IPlayerStatisticCalculator<IEnumerable<MatchAppearance>>> GetAllCalulators()
        {
            return _allCalculators;
        }
    }
}
