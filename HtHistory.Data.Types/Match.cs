using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Data.Types
{
    public class Match : HtObject
    {
        public enum MatchType : uint
        {
            ClubCompetitiveLeague = 1,
            ClubCompetitiveQualifier = 2,
            ClubCompetitiveCup = 3,
            ClubFriendly = 4,
            ClubFriendlyCupRules = 5,
            ClubCompetitiveInternational = 6,
            ClubCompetitiveInternationalCupRules = 7, // HattrickMasters
            ClubFriendlyInternational = 8,
            ClubFriendlyInternationalCupRules = 9,
            NationalCompetitive = 10,
            NationalCompetitiveCupRules = 11,
            NationalFriendly = 12,
            YouthCompetitiveLeague = 100,
            YouthFriendly = 101,
            YouthFriendlyCupRules = 103,
            YouthFriendlyInternational = 105,
            YouthFriendlyInternationalCupRules = 106,
        }

        public Match(int id, MatchType type, Team homeTeam, Team awayTeam) : base(id)
        {
            if (homeTeam == null || awayTeam == null) throw new ArgumentNullException("home or away team is null");

            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            Type = type;
        }

        public Team HomeTeam { get; private set; }
        public Team AwayTeam { get; private set; }
        public Score FinalScore { get; set; }
        public DateTime Date { get; set; }
        public MatchType Type { get; private set; }

        public override string ToString()
        {
            return string.Format("{0} - {1} {2}", HomeTeam.Name, AwayTeam.Name, FinalScore);//Date.ToShortDateString());
        }
    }
}
