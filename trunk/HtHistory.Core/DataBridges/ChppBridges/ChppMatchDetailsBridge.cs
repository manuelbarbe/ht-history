using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.DataContainers;
using HtHistory.Core.DataBridges.ChppBridges.ChppFileAccessors;
using System.Xml.Linq;
using HtHistory.Core.ExtensionMethods;
using System.Globalization;

namespace HtHistory.Core.DataBridges.ChppBridges
{
    public class ChppMatchDetailsBridge : ChppBridgeBase, IMatchDetailsBridge
    {
        public ChppMatchDetailsBridge(IChppAccessor accessor)
            : base(accessor)
        {

        }

        public MatchDetails GetMatchDetails(uint matchId)
        {
            string url = new StringBuilder("file=matchdetails&version=2.0&matchID=")
                                       .Append(matchId)
                                       .Append("&matchEvents=true")
                                       .ToString();

            XDocument doc = XDocument.Load(ChppAccessor.GetDataReader(url, DataFlags.Static));

            XElement elMatch = doc.Root.AssertElement("Match");
            Match match = MatchParserHelper.GetMatch(elMatch);

            MatchDetails md = new MatchDetails(match.ID, match.Type, match.HomeTeam, match.AwayTeam);
            md.Date = match.Date;

            XElement elHomeTeam = elMatch.AssertElement("HomeTeam");
            XElement elAwayTeam = elMatch.AssertElement("AwayTeam");

            uint homeGoals = uint.Parse(elHomeTeam.AssertElement("HomeGoals").Value);
            uint awayGoals = uint.Parse(elAwayTeam.AssertElement("AwayGoals").Value);
            md.FinalScore = new Score(homeGoals, awayGoals);

            XElement elArena = elMatch.Element("Arena");
            if (elArena != null)
            {
                md.Visitors = new Crowd();
                XElement elVisitors = elArena.Element("SoldTotal");
                if (elVisitors != null) md.Visitors.Total = uint.Parse(elVisitors.Value);
                elVisitors = elArena.Element("SoldTerraces");
                if (elVisitors != null) md.Visitors.Terraces = uint.Parse(elVisitors.Value);
                elVisitors = elArena.Element("SoldBasic");
                if (elVisitors != null) md.Visitors.BasicSeats = uint.Parse(elVisitors.Value);
                elVisitors = elArena.Element("SoldRoof");
                if (elVisitors != null) md.Visitors.SeatsUnderRoof = uint.Parse(elVisitors.Value);
                elVisitors = elArena.Element("SoldVIP");
                if (elVisitors != null) md.Visitors.Vip = uint.Parse(elVisitors.Value);   
            }

            IList<Goal> goals = new List<Goal>();
            foreach (XElement elGoal in doc.Root.Descendants("Goal"))
            {
                goals.Add(new Goal(
                                md,
                                uint.Parse(elGoal.AssertElement("ScorerMinute").Value),
                                new Score(
                                    uint.Parse(elGoal.AssertElement("ScorerHomeGoals").Value),
                                    uint.Parse(elGoal.AssertElement("ScorerAwayGoals").Value)),
                                new Team(
                                    uint.Parse(elGoal.AssertElement("ScorerTeamID").Value),
                                    "unnamed team"),
                                new Player(
                                    uint.Parse(elGoal.AssertElement("ScorerPlayerID").Value),
                                    elGoal.AssertElement("ScorerPlayerName").Value)));
            }
            md.Goals = goals;

            IList<MatchEvent> events = new List<MatchEvent>();
            foreach (XElement elEvent in doc.Root.Descendants("Event"))
            {
                events.Add(new MatchEvent(
                match,
                uint.Parse(elEvent.Attribute("Index").Value),
                (MatchEvent.MatchEventType)uint.Parse(elEvent.AssertElement("EventKey").Value.Split('_')[0]),
                uint.Parse(elEvent.AssertElement("Minute").Value),
                elEvent.AssertElement("EventText").Value,
                uint.Parse(elEvent.AssertElement("SubjectTeamID").Value),
                uint.Parse(elEvent.AssertElement("SubjectPlayerID").Value),
                uint.Parse(elEvent.AssertElement("ObjectPlayerID").Value)));
            }
            md.Events = events;


            md.HomeRatings = new Ratings(   uint.Parse(elHomeTeam.AssertElement("RatingMidfield").Value),
                                            uint.Parse(elHomeTeam.AssertElement("RatingLeftDef").Value),
                                            uint.Parse(elHomeTeam.AssertElement("RatingRightDef").Value),
                                            uint.Parse(elHomeTeam.AssertElement("RatingMidDef").Value),
                                            uint.Parse(elHomeTeam.AssertElement("RatingLeftAtt").Value),
                                            uint.Parse(elHomeTeam.AssertElement("RatingRightAtt").Value),
                                            uint.Parse(elHomeTeam.AssertElement("RatingMidAtt").Value));

            md.AwayRatings = new Ratings(   uint.Parse(elAwayTeam.AssertElement("RatingMidfield").Value),
                                            uint.Parse(elAwayTeam.AssertElement("RatingLeftDef").Value),
                                            uint.Parse(elAwayTeam.AssertElement("RatingRightDef").Value),
                                            uint.Parse(elAwayTeam.AssertElement("RatingMidDef").Value),
                                            uint.Parse(elAwayTeam.AssertElement("RatingLeftAtt").Value),
                                            uint.Parse(elAwayTeam.AssertElement("RatingRightAtt").Value),
                                            uint.Parse(elAwayTeam.AssertElement("RatingMidAtt").Value));

            md.HomeLineup = GetLineup(md.ID, md.HomeTeam.ID);
            md.AwayLineup = GetLineup(md.ID, md.AwayTeam.ID);
            return md;
        }

        private Lineup GetLineup(uint matchId, uint teamId)
        {
            string url = new StringBuilder("file=matchlineup&version=1.6&matchID=").Append(matchId)
                                       .Append("&teamID=").Append(teamId).ToString();
                                       
            XDocument doc = XDocument.Load(ChppAccessor.GetDataReader(url, DataFlags.Static));

            XElement elTeam = doc.Root.AssertElement("Team");

            Team compTeam = MatchParserHelper.GetTeam(elTeam, string.Empty);
            if (teamId != compTeam.ID) throw new Exception("received wrong team info");

            XElement elLineup = elTeam.AssertElement("Lineup");

            Lineup lineup = new Lineup();

            foreach (XElement elPlayer in elLineup.Elements("Player"))
            {
                Lineup.LineupRole role;
                XElement elRoleId = elPlayer.Element("RoleID");
                if (elRoleId == null || string.IsNullOrEmpty(elRoleId.Value))
                {
                    role = Lineup.LineupRole.ReplacedPlayerN;
                }
                else
                {
                    role = (Lineup.LineupRole)int.Parse(elPlayer.AssertElement("RoleID").Value);
                }

                double? stars = null;
                XElement elRatingStars = elPlayer.Element("RatingStars");
                if (elRatingStars != null && !string.IsNullOrEmpty(elRatingStars.Value))
                {
                    stars = double.Parse(elRatingStars.Value, CultureInfo.InvariantCulture);
                }

                Player player = MatchParserHelper.GetPlayer(elPlayer);
                lineup.LineupItems.Add(new Lineup.LineupItem() { Player = player, Role = role, RatingStars = stars });
            }

            return lineup;
        }
    }
}
