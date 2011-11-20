using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.DataContainers;

namespace HtHistory.Core.ExtensionMethods
{
    public static class DataContainerExtensions
    {
        public static bool IsActive(this Lineup.LineupRole role)
        {
            return !(
                role == Lineup.LineupRole.Captain ||
                role == Lineup.LineupRole.SetPiecesTaker ||
                role == Lineup.LineupRole.SubstitutionKeeper ||
                role == Lineup.LineupRole.SubstitutionKeeper_ ||
                role == Lineup.LineupRole.SubstitutionDefender ||
                role == Lineup.LineupRole.SubstitutionDefender_ ||
                role == Lineup.LineupRole.SubstitutionInnerMidfield ||
                role == Lineup.LineupRole.SubstitutionInnerMidfield_ ||
                role == Lineup.LineupRole.SubstitutionWinger ||
                role == Lineup.LineupRole.SubstitutionWinger_ ||
                role == Lineup.LineupRole.SubstitutionForward ||
                role == Lineup.LineupRole.SubstitutionForward_);
        }

        public static bool IsRedCard(this MatchEvent.MatchEventType type)
        {
            return
                type == MatchEvent.MatchEventType.RedCardSecondWarningCheating ||
                type == MatchEvent.MatchEventType.RedCardSecondWarningNastyPlay ||
                type == MatchEvent.MatchEventType.RedCardWithoutWarning;
        }

        public static bool IsSubstitution(this MatchEvent.MatchEventType type)
        {
            return
                type == MatchEvent.MatchEventType.SubstitutionMinute ||
                type == MatchEvent.MatchEventType.SubstitutionTeamIsAhead ||
                type == MatchEvent.MatchEventType.SubstitutionTeamIsBehind ||
                type == MatchEvent.MatchEventType.ModeratelyInjuredLeavesField ||
                type == MatchEvent.MatchEventType.BadlyInjuredLeavesField ||
                type == MatchEvent.MatchEventType.InjuredAfterFoulButExits;
        }

        public static bool IsInjuredWithoutSubstitute(this MatchEvent.MatchEventType type)
        {
            return
                type == MatchEvent.MatchEventType.InjuredAndNoReplacementExists ||
                type == MatchEvent.MatchEventType.InjuredAfterFoulAndNoReplacementExists ||
                type == MatchEvent.MatchEventType.KeeperInjuredFieldPlayerHasToTakeHisPlace;
        }
    }
}
