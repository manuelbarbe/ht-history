using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.DataContainers;

namespace HtHistory.Core.ExtensionMethods
{
    public static class DataContainerExtensions
    {
        public static bool IsLeagueMatch(this Match.MatchType t)
        {
            return t == Match.MatchType.ClubCompetitiveLeague;
        }
    
        public static bool IsQualifierMatch(this Match.MatchType t)
        {
            return t == Match.MatchType.ClubCompetitiveQualifier;
        }

        public static bool IsCupMatch(this Match.MatchType t)
        {
            return t == Match.MatchType.ClubCompetitiveCup;
        }

        public static bool IsFriendlyMatch(this Match.MatchType t)
        {
            switch (t)
            {
                case Match.MatchType.ClubFriendly:
                case Match.MatchType.ClubFriendlyCupRules:
                case Match.MatchType.ClubFriendlyInternational:
                case Match.MatchType.ClubFriendlyInternationalCupRules:
                    return true;
                default:
                    return false;
            }
        }
        
        public static bool IsOtherSeniorMatch(this Match.MatchType t)
        {
            switch (t)
            {
                    case Match.MatchType.ClubCompetitiveInternational:
                    case Match.MatchType.ClubCompetitiveInternationalCupRules:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsCompetitiveSeniorMatch(this Match.MatchType t)
        {
            return t.IsLeagueMatch() || t.IsCupMatch() || t.IsQualifierMatch();
        }

        public static bool IsNonSeniorMatch(this Match.MatchType t)
        {
            return !(t.IsLeagueMatch() || t.IsCupMatch() || t.IsQualifierMatch() || t.IsFriendlyMatch() || t.IsOtherSeniorMatch());  
        }

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

        public static bool IsYellowCard(this MatchEvent.MatchEventType type)
        {
            return
                type == MatchEvent.MatchEventType.YellowCardCheating ||
                type == MatchEvent.MatchEventType.YellowCardNastyPlay;
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
                type == MatchEvent.MatchEventType.InjuredAfterFoulAndExits;
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
