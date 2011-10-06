using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.DataContainers;

namespace HtHistory.Statistics
{
    public class PlayerStatisticItem<T>
    {
            public PlayerStatisticItem (Player player)
            {
                if (player == null) throw new ArgumentNullException("player");
                Player = player;
            }

            public Player     Player { get; private set; }
            public IList<T>   TotalItems = new List<T>();
            public IList<T>   LeagueItems = new List<T>();
            public IList<T>   CupItems = new List<T>();
            public IList<T>   QualifierItems = new List<T>();
            public IList<T>   FriendlyItems = new List<T>();
            public IList<T>   OtherItems = new List<T>();
            public DateTime   First = DateTime.MaxValue;
            public DateTime   Last = DateTime.MinValue;

            public void Add(T t, DateTime date, Match.MatchType matchType)
            {                                   
                TotalItems.Add(t);

                if (date < First) First = date;
                if (date > Last)  Last  = date;

                switch (matchType)
                {
                    case Match.MatchType.ClubCompetitiveLeague:
                        LeagueItems.Add(t);
                        break;
                    case Match.MatchType.ClubCompetitiveQualifier:
                        QualifierItems.Add(t);
                        break;
                    case Match.MatchType.ClubCompetitiveCup:
                        CupItems.Add(t);
                        break;
                    case Match.MatchType.ClubFriendly:
                    case Match.MatchType.ClubFriendlyCupRules:
                    case Match.MatchType.ClubFriendlyInternational:
                    case Match.MatchType.ClubFriendlyInternationalCupRules:
                        FriendlyItems.Add(t);
                        break;
                    case Match.MatchType.ClubCompetitiveInternational:
                    case Match.MatchType.ClubCompetitiveInternationalCupRules:
                        OtherItems.Add(t);
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
                        throw new Exception("Unexpected match type " + matchType.ToString());
                }
            }

            public int  CompareTo(PlayerStatisticItem<T> other)
            {
 	            return (int)TotalItems.Count - (int)other.TotalItems.Count;
            }

            public override string ToString()
            {
                return String.Format("{0,3} {1} (L:{2}, C:{3}, Q:{4}, F:{5} O:{6} 1st:{7} last: {8})",
                    TotalItems.Count,
                    Player.Name,
                    LeagueItems.Count,
                    CupItems.Count,
                    QualifierItems.Count,
                    FriendlyItems.Count,
                    OtherItems.Count,
                    First.ToShortDateString(),
                    Last.ToShortDateString()
                    );
            }
    }
}
