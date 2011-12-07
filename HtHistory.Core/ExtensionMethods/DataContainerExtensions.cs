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
            return t.IsLeagueMatch() || t.IsCupMatch() || t.IsQualifierMatch() || t.IsOtherSeniorMatch();
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

        public static bool IsKeeper(this Lineup.LineupRole role)
        {
            return (
                role == Lineup.LineupRole.Keeper ||
                role == Lineup.LineupRole.Keeper_);
        }

        // TODO: behavior "extra defender"
        public static bool IsCentralDefender(this Lineup.LineupRole role)
        {
            return (
                role == Lineup.LineupRole.CentralDefenderLeft ||
                role == Lineup.LineupRole.CentralDefenderMiddle ||
                role == Lineup.LineupRole.CentralDefenderRight || 
                role == Lineup.LineupRole.CentralDefender1_ ||
                role == Lineup.LineupRole.CentralDefender2_);
        }

        public static bool IsWingBack(this Lineup.LineupRole role)
        {
            return (
                role == Lineup.LineupRole.WingBackLeft ||
                role == Lineup.LineupRole.WingBackRight ||
                role == Lineup.LineupRole.WingBackLeft_ ||
                role == Lineup.LineupRole.WingBackRight_);
        }

        // TODO: behavior "extra inner midfielder"
        public static bool IsInnerMidfielder(this Lineup.LineupRole role)
        {
            return (
                role == Lineup.LineupRole.InnerMidfieldLeft ||
                role == Lineup.LineupRole.InnerMidfieldMiddle ||
                role == Lineup.LineupRole.InnerMidfieldRight ||
                role == Lineup.LineupRole.InnerMidfield1_ ||
                role == Lineup.LineupRole.InnerMidfield2_);
        }

        public static bool IsWinger(this Lineup.LineupRole role)
        {
            return (
                role == Lineup.LineupRole.WingerLeft ||
                role == Lineup.LineupRole.WingerRight ||
                role == Lineup.LineupRole.WingerLeft_ ||
                role == Lineup.LineupRole.WingerRight_);
        }

        // TODO: behavior "extra forward"
        public static bool IsForward(this Lineup.LineupRole role)
        {
            return (
                role == Lineup.LineupRole.ForwardLeft ||
                role == Lineup.LineupRole.ForwardMiddle ||
                role == Lineup.LineupRole.ForwardRight ||
                role == Lineup.LineupRole.Forward1_ ||
                role == Lineup.LineupRole.Forward2_);
        }

        public static bool IsUnknownPosition(this Lineup.LineupRole role)
        {
            return (
                role == Lineup.LineupRole.InjuredWithoutReplacement ||
                role == Lineup.LineupRole.RedCardedPlayer ||
                role == Lineup.LineupRole.ReplacedPlayer1 ||
                role == Lineup.LineupRole.ReplacedPlayer2 ||
                role == Lineup.LineupRole.ReplacedPlayer3 ||
                role == Lineup.LineupRole.ReplacedPlayerN );
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
