using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.DataContainers;
using HtHistory.Core.ExtensionMethods;
using HtHistory.Core;

namespace HtHistory.Statistics.Players
{
    public class StandardPlayerStatistics
    {
        public StandardPlayerStatistics(IEnumerable<MatchDetails> matches)
        {
            Matches = matches;
        }

        private IEnumerable<MatchDetails> Matches { get; set; }

        public IDictionary<Player, PlayerStatisticItem<MatchAppearance>> GetFor(uint teamId, bool addTeamItem = false)
        {
            IDictionary<Player, PlayerStatisticItem<MatchAppearance>> ret2 = new Dictionary<Player, PlayerStatisticItem<MatchAppearance>>();
           
            foreach (MatchDetails md in Matches.SafeEnum())
            {
                IDictionary<Player, MatchAppearance> thisMatchAppearances = new Dictionary<Player, MatchAppearance>();

                if (addTeamItem)
                {
                    AddTeamDummyPlayer(teamId, thisMatchAppearances, md);
                    AddTeamDummyGoals(teamId, thisMatchAppearances, md);
                }

                AddLineupPlayers(teamId, thisMatchAppearances, md);
                AddDisappearedPlayers(teamId, thisMatchAppearances, md);
                AddGoals(teamId, thisMatchAppearances, md);

                // add items to return value
                foreach (var v in thisMatchAppearances)
                {
                    if (!ret2.ContainsKey(v.Key))
                    {
                        ret2.Add(v.Key, new PlayerStatisticItem<MatchAppearance>(v.Key));
                    }

                    ret2[v.Key].Add(v.Value, md.Date, md.Type);
                }
            }

            return ret2;
        }

        private static void AddTeamDummyPlayer(uint teamId, IDictionary<Player, MatchAppearance> thisMatchAppearances, MatchDetails md)
        {
            Team myTeam;
            if (md.HomeTeam.ID == teamId) myTeam = md.HomeTeam;
            else if (md.AwayTeam.ID == teamId) myTeam = md.AwayTeam;
            else
            {
                HtLog.Warn("Received a bad match ({0})", md);
                return;
            }

            Player teamDummyPlayer = new Player(0, myTeam.Name);
            thisMatchAppearances.Add(teamDummyPlayer, new MatchAppearance(teamDummyPlayer, md, Lineup.LineupRole.Unknown));
        }

        private static void AddTeamDummyGoals(uint teamId, IDictionary<Player, MatchAppearance> thisMatchAppearances, MatchDetails md)
        {
             Player teamDummyPlayer = new Player(0, "myTeam");

            foreach (Goal g in md.Goals)
            {
                if (teamId != g.Team.ID) continue; // ignore opponent goals

                if (!thisMatchAppearances.ContainsKey(teamDummyPlayer)) throw new Exception("Scorer is not part of lineup. This is very odd.");

                thisMatchAppearances[teamDummyPlayer].Goals.Add(g);
            }   
        }

        private static void AddLineupPlayers(uint teamId, IDictionary<Player, MatchAppearance> ret, MatchDetails md)
        {
            IEnumerable<Lineup.LineupItem> items = null;
            if (md.HomeTeam.ID == teamId) items = md.HomeLineup.LineupItems;
            else if (md.AwayTeam.ID == teamId) items = md.AwayLineup.LineupItems;
            else
            {
                HtLog.Warn("Received a bad match ({0})", md);
                return;
            }

            foreach (Lineup.LineupItem item in items.SafeEnum())
            {
                if (!item.Role.IsActive()) continue;

                if (!ret.ContainsKey(item.Player))
                {
                    ret.Add(item.Player, new MatchAppearance(item.Player, md, item.Role));
                }
                else
                {
                    throw new Exception(string.Format("Tried to add Player {0} twice", item.Player));
                }
            }
        }

        private static void AddDisappearedPlayers(uint teamId, IDictionary<Player, MatchAppearance> ret, MatchDetails md)
        {
            foreach (MatchEvent ev in md.Events)
            {
                uint playerId = ev.PlayerId;

                if ((ev.TeamId == teamId) &&
                    (ev.Type == MatchEvent.MatchEventType.RedCardSecondWarningCheating ||
                    ev.Type == MatchEvent.MatchEventType.RedCardSecondWarningNastyPlay ||
                    ev.Type == MatchEvent.MatchEventType.RedCardWithoutWarning))
                {
                    AddPlayer(ret, playerId, Lineup.LineupRole.RedCardedPlayer, md);
                }
                else if ((ev.TeamId == teamId) &&
                    (ev.Type == MatchEvent.MatchEventType.InjuredAndNoReplacementExists ||
                    ev.Type == MatchEvent.MatchEventType.InjuredAfterFoulAndNoReplacementExists))
                {
                    AddPlayer(ret, playerId, Lineup.LineupRole.InjuredWithoutReplacement, md);
                }
            }
        }

        private static void AddPlayer(IDictionary<Player, MatchAppearance> ret, uint playerId, Lineup.LineupRole role, MatchDetails md)
        {
            Player player = new Player(playerId, Player.UnknownName);

            if (!ret.ContainsKey(player))
            {
                ret.Add(player, new MatchAppearance(player, md, role));
            }
            else
            {
                throw new Exception(string.Format("Tried to add Player {0} twice", player));
            }
        }

        private static void AddGoals(uint teamId, IDictionary<Player, MatchAppearance> thisMatchAppearances, MatchDetails md)
        {
            foreach (Goal g in md.Goals)
            {
                if (teamId != g.Team.ID) continue; // ignore opponent goals

                if (!thisMatchAppearances.ContainsKey(g.Scorer)) throw new Exception("Scorer is not part of lineup. This is very odd.");

                thisMatchAppearances[g.Scorer].Goals.Add(g);
            }   
        }
    }
}
