using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Data.Types;
using System.Xml.Linq;
using HtHistory.Toolbox;

namespace HtHistory.Core.DataBridges.ChppBridges
{
    internal static class MatchParserHelper
    {
        public static Match GetMatch(XElement elMatch)
        {
            if (elMatch == null) throw new ArgumentNullException("elMatch");
            Match m = new Match(
                        int.Parse(elMatch.AssertElement("MatchID").Value),
                        (Match.MatchType)uint.Parse(elMatch.AssertElement("MatchType").Value),
                        GetTeam(elMatch.AssertElement("HomeTeam"), "Home"),
                        GetTeam(elMatch.AssertElement("AwayTeam"), "Away"));

            m.Date = DateTime.Parse(elMatch.AssertElement("MatchDate").Value);
            return m;
        }

        public static Team GetTeam(XElement elTeam, string team)
        {
            if (elTeam == null) throw new ArgumentNullException("elTeam"); ;
            XElement elTeamId = elTeam.AssertElement(team + "TeamID");
            XElement elTeamName = elTeam.AssertElement(team + "TeamName");
            return new Team(int.Parse(elTeamId.Value), elTeamName.Value);
        }

        public static Player GetPlayer(XElement elPlayer)
        {
            if (elPlayer == null) throw new ArgumentNullException("elPlayer");
            return new Player(int.Parse(elPlayer.AssertElement("PlayerID").Value),
                               elPlayer.AssertElement("PlayerName").Value);
        }
    }
}

