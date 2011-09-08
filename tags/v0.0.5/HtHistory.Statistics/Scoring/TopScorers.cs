using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.DataContainers;
using HtHistory.Core.DataBridges;
using HtHistory.Core.ExtensionMethods;

namespace HtHistory.Statistics.Scoring
{
    public class TopScorers
    {
        public class ScorerItem : IComparable<ScorerItem>
        {
            public Player        Scorer;
            public IList<Goal>   Goals = new List<Goal>();
            public IList<Goal>   LeagueGoals = new List<Goal>();
            public IList<Goal>   CupGoals = new List<Goal>();
            public IList<Goal>   QualifierGoals = new List<Goal>();
            public IList<Goal>   FriendlyGoals = new List<Goal>();
            public IList<Goal>   OtherGoals = new List<Goal>();
            public DateTime FirstGoal = DateTime.MaxValue;
            public DateTime LastGoal = DateTime.MinValue;

            public int  CompareTo(ScorerItem other)
            {
 	            return (int)Goals.Count - (int)other.Goals.Count;
            }

            public override string ToString()
            {
                return String.Format("{0,3} {1} (L:{2}, C:{3}, Q:{4}, F:{5} O:{6} 1st:{7} last: {8})",
                    Goals.Count,
                    Scorer.Name,
                    LeagueGoals.Count,
                    CupGoals.Count,
                    QualifierGoals.Count,
                    FriendlyGoals.Count,
                    OtherGoals.Count,
                    FirstGoal.ToShortDateString(),
                    LastGoal.ToShortDateString()
                    );
            }
        }

        public class TopScorersInfo
        {
            public TeamDetails Team { get; set; }
            public TeamDetails Opponent { get; set; }
            public IEnumerable<ScorerItem> Scorers { get; set; }
        }

        public TopScorers(ITeamDetailsBridge tdb, IMatchArchiveBridge mab, IMatchDetailsBridge mdb)
        {
            if (tdb == null || mab == null || mdb == null) throw new ArgumentNullException();
            TDB = tdb;
            MAB = mab;
            MDB = mdb;
        }

        private ITeamDetailsBridge TDB { get; set; }
        private IMatchArchiveBridge MAB { get; set; }
        private IMatchDetailsBridge MDB { get; set; }

        public TopScorersInfo GetScorers(uint teamId, uint opponentId = 0)
        {
            IDictionary<uint, ScorerItem> scorers = new Dictionary<uint, ScorerItem>();

            TeamDetails teamDetails = TDB.GetTeamDetails(teamId);
            if (teamDetails == null || teamDetails.Owner == null || teamDetails.Owner.JoinDate == null)
                throw new Exception("Cannot get join date of owner");

            MatchArchive ar = MAB.GetMatches(teamId, teamDetails.Owner.JoinDate.Value, DateTime.Now); // todo: to ht time

            foreach (Match m in ar.SafeEnum())
            {
                // check if specified opponent is playing match
                if (opponentId != 0 && !(opponentId == m.HomeTeam.ID || opponentId == m.AwayTeam.ID)) continue;

                MatchDetails md = MDB.GetMatchDetails(m.ID);
                foreach (Goal g in md.Goals)
                {
                    if (teamId != g.Team.ID) continue; // ignore opponent goals
                    if (!scorers.ContainsKey(g.Scorer.ID))
                    {
                        scorers.Add( g.Scorer.ID, new ScorerItem() { Scorer = g.Scorer } );
                    }
                    
                    ScorerItem si = scorers[g.Scorer.ID];
                    si.Goals.Add(g);

                    if (m.Date < si.FirstGoal) si.FirstGoal = m.Date;
                    if (m.Date > si.LastGoal) si.LastGoal = m.Date;

                    switch (md.Type)
                    {
                        case Match.MatchType.ClubCompetitiveLeague:
                            si.LeagueGoals.Add(g);
                            break;
                        case Match.MatchType.ClubCompetitiveQualifier:
                            si.QualifierGoals.Add(g);
                            break;
                        case Match.MatchType.ClubCompetitiveCup:
                            si.CupGoals.Add(g);
                            break;
                        case Match.MatchType.ClubFriendly:
                        case Match.MatchType.ClubFriendlyCupRules:
                        case Match.MatchType.ClubFriendlyInternational:
                        case Match.MatchType.ClubFriendlyInternationalCupRules:
                            si.FriendlyGoals.Add(g);
                            break;
                        case Match.MatchType.ClubCompetitiveInternational:
                        case Match.MatchType.ClubCompetitiveInternationalCupRules:
                            si.OtherGoals.Add(g);
                            break;
                        case Match.MatchType.NationalCompetitive:
                        case Match.MatchType.NationalCompetitiveCupRules:
                        case Match.MatchType.NationalFriendly:
                        case Match.MatchType.YouthCompetitiveLeague:
                        case Match.MatchType.YouthFriendly:
                        case Match.MatchType.YouthFriendlyCupRules:
                        case Match.MatchType.YouthFriendlyInternational:
                        case Match.MatchType.YouthFriendlyInternationalCupRules:
                        default:
                            throw new Exception("Unexpected match type " + md.Type.ToString());
                    }
                }
            }

            return new TopScorersInfo() {   Team = teamDetails,
                                            Opponent = opponentId == 0 ? null : TDB.GetTeamDetails(opponentId),
                                            Scorers = scorers.Values.OrderByDescending(v => v.Goals.Count) }; 
        }
    }
}
