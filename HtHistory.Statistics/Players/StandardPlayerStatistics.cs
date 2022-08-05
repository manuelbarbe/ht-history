using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Data.Types;
using HtHistory.Toolbox;
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

        public IDictionary<Player, IList<MatchAppearance>> GetMatchesOfPlayers(int teamId, bool addTeamItem = false)
        {
            IDictionary<Player, IList<MatchAppearance>> ret2 = new Dictionary<Player, IList<MatchAppearance>>();
           
            foreach (MatchDetails md in Matches.SafeEnum())
            {
                Team myTeam;
                if (md.HomeTeam.ID == teamId) myTeam = md.HomeTeam;
                else if (md.AwayTeam.ID == teamId) myTeam = md.AwayTeam;
                else
                {
                    HtLog.Warn("Received a bad match ({0})", md);
                    continue;
                }

                IDictionary<Player, MatchAppearance> thisMatchAppearances = new Dictionary<Player, MatchAppearance>();

                if (addTeamItem)
                {
                    AddTeamDummyPlayer(myTeam, thisMatchAppearances, md);
                    AddTeamDummyGoals(myTeam, thisMatchAppearances, md);
                }

                AddLineupPlayers(myTeam, thisMatchAppearances, md);
                AddDisappearedPlayers(myTeam, thisMatchAppearances, md);
                AddGoals(myTeam, thisMatchAppearances, md);
                AddReplacements(myTeam, thisMatchAppearances, md);
                AddBestPlayer(myTeam, thisMatchAppearances, md);
                AddYellowCards(myTeam, thisMatchAppearances, md);
                AddBruisedAndInjured(myTeam, thisMatchAppearances, md);

                // add items to return value
                foreach (var v in thisMatchAppearances)
                {
                    if (!ret2.ContainsKey(v.Key))
                    {
                        ret2.Add(v.Key, new List<MatchAppearance>());
                    }

                    ret2[v.Key].Add(v.Value);
                }
            }

            return ret2;
        }

        private static void AddTeamDummyPlayer(Team myTeam, IDictionary<Player, MatchAppearance> thisMatchAppearances, MatchDetails md)
        {
            Player teamDummyPlayer = new Player(0, myTeam.Name);
            thisMatchAppearances.Add(teamDummyPlayer, new MatchAppearance(teamDummyPlayer, myTeam, md, Lineup.LineupRole.Unknown));
        }

        private static void AddTeamDummyGoals(Team myTeam, IDictionary<Player, MatchAppearance> thisMatchAppearances, MatchDetails md)
        {
            Player teamDummyPlayer = new Player(0, myTeam.Name);

            foreach (Goal g in md.Goals)
            {
                if (myTeam.ID != g.Team.ID) continue; // ignore opponent goals

                if (!thisMatchAppearances.ContainsKey(teamDummyPlayer)) throw new Exception("Scorer is not part of lineup. This is very odd.");

                thisMatchAppearances[teamDummyPlayer].Goals.Add(g);
            }   
        }

        private static void AddLineupPlayers(Team myTeam, IDictionary<Player, MatchAppearance> ret, MatchDetails md)
        {
            IEnumerable<Lineup.LineupItem> items = null;
            if (md.HomeTeam.ID == myTeam.ID)
            {
                myTeam = md.HomeTeam;
                items = md.HomeLineup.LineupItems;
            }
            else if (md.AwayTeam.ID == myTeam.ID)
            {
                items = md.AwayLineup.LineupItems;
            }
            else
            {
                HtLog.Warn("Received a bad match ({0})", md);
                return;
            }

            foreach (Lineup.LineupItem item in items.SafeEnum())
            {
                if (!item.Role.IsActive()) continue;

                if (item.Player.ID == 0) continue; // ignore neighbourhood players

                if (!ret.ContainsKey(item.Player))
                {
                    ret.Add(item.Player, new MatchAppearance(item.Player, myTeam, md, item.Role, item.RatingStars));
                }
                else
                {
                    throw new Exception(string.Format("Tried to add Player {0} twice", item.Player));
                }
            }
        }

        private static void AddDisappearedPlayers(Team myTeam, IDictionary<Player, MatchAppearance> ret, MatchDetails md)
        {
            foreach (MatchEvent ev in md.Events)
            {
                if (ev.TeamId != myTeam.ID) continue;

                int playerId = ev.PlayerId;

                if ( ev.Type.IsRedCard() )
                {
                    AddPlayer(ret, playerId, myTeam, Lineup.LineupRole.RedCardedPlayer, md, ev.Minute, null, null);
                }
                else if ( ev.Type.IsInjuredWithoutSubstitute() )
                {
                    AddPlayer(ret, playerId, myTeam, Lineup.LineupRole.InjuredWithoutReplacement, md, null, null, ev.Minute);
                }
            }
        }

        private static void AddPlayer(IDictionary<Player, MatchAppearance> ret, int playerId, Team playerTeam, Lineup.LineupRole role, MatchDetails md, uint? redcarded, uint? substitutedIn, uint? substitutedOut)
        {
            if (playerId == 0) return; // ignore neighbourhood players

            Player player = new Player(playerId, Player.UnknownName);

            if (!ret.ContainsKey(player))
            {
                ret.Add(player, new MatchAppearance(player, playerTeam, md, role));
            }
            
            if (substitutedIn != null)  ret[player].SubstituteIn  = substitutedIn;
            if (substitutedOut != null) ret[player].SubstituteOut = substitutedOut;
            if (redcarded != null)      ret[player].RedCarded     = redcarded;
        }

        private static void AddGoals(Team myTeam, IDictionary<Player, MatchAppearance> thisMatchAppearances, MatchDetails md)
        {
            foreach (Goal g in md.Goals)
            {
                if (myTeam.ID != g.Team.ID) continue; // ignore opponent goals

                if (g.Scorer.ID == 0) continue; // ignore neighbourhood players

                if (!thisMatchAppearances.ContainsKey(g.Scorer))
                {
                    HtLog.Warn("Scorer is not part of lineup. This is very odd.");
                    continue;
                }

                thisMatchAppearances[g.Scorer].Goals.Add(g);
            }   
        }

        private void AddReplacements(Team myTeam, IDictionary<Player, MatchAppearance> thisMatchAppearances, MatchDetails md)
        {
            foreach (MatchEvent ev in md.Events)
            {
                if (ev.TeamId != myTeam.ID) continue;

                if (ev.Type.IsSubstitution())
                {
                    // out player
                    AddPlayer(thisMatchAppearances, ev.PlayerId, myTeam, Lineup.LineupRole.Unknown, md, null, null, ev.Minute);
                    // in player
                    AddPlayer(thisMatchAppearances, ev.OtherPlayerId, myTeam, Lineup.LineupRole.Unknown, md, null, ev.Minute, null);
                }
            }
        }

        private void AddBestPlayer(Team myTeam, IDictionary<Player, MatchAppearance> thisMatchAppearances, MatchDetails md)
        {
            foreach (MatchEvent ev in md.Events)
            {
                if (ev.TeamId != myTeam.ID) continue;

                if (ev.Type == MatchEvent.MatchEventType.BestPlayer)
                {
                    if (ev.PlayerId == 0) continue; // ignore neighbourhood players

                    Player player = new Player(ev.PlayerId, Player.UnknownName);

                    if (thisMatchAppearances.ContainsKey(player))
                    {
                        thisMatchAppearances[player].BestPlayer = true;
                    }
           
                }
            }
        }

        private void AddYellowCards(Team myTeam, IDictionary<Player, MatchAppearance> thisMatchAppearances, MatchDetails md)
        {
            foreach (MatchEvent ev in md.Events)
            {
                if (ev.TeamId != myTeam.ID) continue;

                if (ev.Type.IsYellowCard())
                {
                    if (ev.PlayerId == 0) continue; // ignore neighbourhood players

                    Player player = new Player(ev.PlayerId, Player.UnknownName);

                    if (thisMatchAppearances.ContainsKey(player))
                    {
                        thisMatchAppearances[player].YellowCarded = ev.Minute;
                    }

                }
            }
        }

        private void AddBruisedAndInjured(Team myTeam, IDictionary<Player, MatchAppearance> thisMatchAppearances, MatchDetails md)
        {
            foreach (MatchEvent ev in md.Events)
            {
                if (ev.TeamId != myTeam.ID) continue;

                if (ev.Type.IsBruised())
                {
                    if (ev.PlayerId == 0) continue; // ignore neighbourhood players

                    Player player = new Player(ev.PlayerId, Player.UnknownName);

                    if (thisMatchAppearances.ContainsKey(player))
                    {
                        thisMatchAppearances[player].Bruised = ev.Minute;
                    }
                }
                else if (ev.Type.IsInjury())
                {
                    if (ev.PlayerId == 0) continue; // ignore neighbourhood players

                    Player player = new Player(ev.PlayerId, Player.UnknownName);

                    if (thisMatchAppearances.ContainsKey(player))
                    {
                        thisMatchAppearances[player].Injured = ev.Minute;
                    }
                }
            }
        }
    }
}
