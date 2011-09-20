using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.DataContainers;
using HtHistory.Core.DataBridges.ChppBridges.ChppFileAccessors;
using System.Xml.Linq;
using HtHistory.Core.ExtensionMethods;

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

            IList<Goal> goals = new List<Goal>();
            foreach (XElement elGoal in doc.Root.Descendants("Goal"))
            {
                goals.Add(new Goal(
                                match,
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
                Lineup.LineupRole role = (Lineup.LineupRole) int.Parse(elPlayer.AssertElement("RoleID").Value);
                Player player = MatchParserHelper.GetPlayer(elPlayer);
                lineup.LineupItems.Add(new Lineup.LineupItem() { Role = role, Player = player });
            }

            return lineup;
        }
    }
}
