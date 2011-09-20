using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.DataContainers;
using HtHistory.Core.DataBridges;
using HtHistory.Core.ExtensionMethods;
using HtHistory.Core;

namespace HtHistory.Statistics.Appearance
{
    public class TotalMatches
    {
        public class AppearanceInfo
        {
            public Player Player { get; set; }
            public MatchDetails Match { get; set; }
            public Lineup.LineupRole Role { get; set; }
        }

        public TotalMatches(IEnumerable<MatchDetails> matches)
        {
            Matches = matches;
        }

        private IEnumerable<MatchDetails> Matches { get; set; }

        public IDictionary<Player, PlayerStatisticItem<AppearanceInfo> > GetTotalMatches(uint teamId, bool addTeamItem = false)
        {
            IDictionary<Player, PlayerStatisticItem<AppearanceInfo>> ret = new Dictionary<Player, PlayerStatisticItem<AppearanceInfo>>();
            Player teamDummyPlayer = null; // dummy player to represent team statistics
            
            foreach(MatchDetails md in Matches.SafeEnum())
            {
                if (addTeamItem)
                {
                    if (teamDummyPlayer == null)
                    {
                        Team myTeam;
                        if (md.HomeTeam.ID == teamId) myTeam = md.HomeTeam;
                        else if (md.AwayTeam.ID == teamId) myTeam = md.AwayTeam;
                        else
                        {
                            HtLog.Warn("Received a bad match ({0})", md);
                            continue;
                        }

                        teamDummyPlayer = new Player(0, myTeam.Name);
                        ret.Add(teamDummyPlayer, new PlayerStatisticItem<AppearanceInfo>(teamDummyPlayer));
                    }

                    ret[teamDummyPlayer].Add(
                            new AppearanceInfo()
                            {
                                Player = teamDummyPlayer,
                                Match = md,
                                Role = Lineup.LineupRole.Unknown,
                            },
                            md.Date,
                            md.Type);
                }

                IEnumerable<Lineup.LineupItem> items;
                if (md.HomeTeam.ID == teamId) items = md.HomeLineup.LineupItems;
                else if (md.AwayTeam.ID == teamId) items = md.AwayLineup.LineupItems;
                else
                {
                    HtLog.Warn("Received a bad match ({0})", md);
                    continue;
                }

                foreach (Lineup.LineupItem item in items)
                {
                    if (item.Role == Lineup.LineupRole.Captain ||
                        item.Role == Lineup.LineupRole.SetPiecesTaker ||
                        item.Role == Lineup.LineupRole.SubstitutionKeeper ||
                        item.Role == Lineup.LineupRole.SubstitutionKeeper_ ||
                        item.Role == Lineup.LineupRole.SubstitutionDefender ||
                        item.Role == Lineup.LineupRole.SubstitutionDefender_ ||
                        item.Role == Lineup.LineupRole.SubstitutionInnerMidfield ||
                        item.Role == Lineup.LineupRole.SubstitutionInnerMidfield_ ||
                        item.Role == Lineup.LineupRole.SubstitutionWinger ||
                        item.Role == Lineup.LineupRole.SubstitutionWinger_ ||
                        item.Role == Lineup.LineupRole.SubstitutionForward ||
                        item.Role == Lineup.LineupRole.SubstitutionForward_) continue;


                    if (!ret.ContainsKey(item.Player))
                    {
                        ret.Add(item.Player, new PlayerStatisticItem<AppearanceInfo>(item.Player));
                    }
                    else
                    {
                        // TODO: we may adjust an unknown player name here
                    }

                    ret[item.Player].Add(
                        new AppearanceInfo() { Player = item.Player,
                                               Match  = md,
                                               Role = item.Role },
                        md.Date,
                        md.Type);
                }

                foreach (MatchEvent ev in md.Events)
                {
                    if ((ev.TeamId == teamId) &&
                        (ev.Type == MatchEvent.MatchEventType.RedCardSecondWarningCheating ||
                        ev.Type == MatchEvent.MatchEventType.RedCardSecondWarningNastyPlay ||
                        ev.Type == MatchEvent.MatchEventType.RedCardWithoutWarning))
                    {

                        Player player = new Player(ev.PlayerId, Player.UnknownName);

                        if (!ret.ContainsKey(player))
                        {
                            ret.Add(player, new PlayerStatisticItem<AppearanceInfo>(player));
                        }

                        ret[player].Add(
                            new AppearanceInfo()
                            {
                                Player = player,
                                Match = md,
                                Role = Lineup.LineupRole.RedCardedPlayer,
                            },
                            md.Date,
                            md.Type);
                    }
                }
            }

            return ret;
        }
    }
}
