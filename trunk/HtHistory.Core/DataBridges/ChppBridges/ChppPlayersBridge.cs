using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using HtHistory.Core.DataBridges.ChppBridges.ChppFileAccessors;
using HtHistory.Core.ExtensionMethods;
using HtHistory.Core.DataContainers;

namespace HtHistory.Core.DataBridges.ChppBridges
{
    public class ChppPlayersBridge : ChppBridgeBase, IPlayersBridge
    {
        public ChppPlayersBridge(IChppAccessor accessor) : base(accessor) { }

        public IEnumerable<DataContainers.PlayerDetails> GetPlayers(uint teamId)
        {
            string url = new StringBuilder("file=players&version=2.0&teamID=")
                                       .Append(teamId).ToString();

            XDocument doc = XDocument.Load(ChppAccessor.GetDataReader(url, DataFlags.Dynamic));

            XElement elTeam = doc.Root.AssertElement("Team");

            Team compTeam = MatchParserHelper.GetTeam(elTeam, string.Empty);
            if (teamId != compTeam.ID) throw new Exception("received wrong team info");

            IList<PlayerDetails> players = new List<PlayerDetails>();

            foreach (XElement el in elTeam.AssertElement("PlayerList").Elements("Player"))
            {
                int id = int.Parse(el.AssertElement("PlayerID").Value);
                string givenName = el.AssertElement("FirstName").Value;
                string nickName = el.AssertElement("NickName").Value;
                string surName = el.AssertElement("LastName").Value;

                players.Add(new PlayerDetails(id, givenName, nickName, surName));
                //yield return new PlayerDetails(id, givenName, nickName, surName); // this was very slow, why?
            }

            return players;
        }
    }
}
