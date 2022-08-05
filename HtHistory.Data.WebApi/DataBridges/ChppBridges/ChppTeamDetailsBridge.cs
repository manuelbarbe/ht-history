using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.DataBridges;
using HtHistory.Data.Types;
using HtHistory.Core.DataBridges.ChppBridges.ChppFileAccessors;
using System.Xml.Linq;
using HtHistory.Toolbox;

namespace HtHistory.Core.DataBridges.ChppBridges
{
    public class ChppTeamDetailsBridge : ChppBridgeBase, ITeamDetailsBridge
    {
        public ChppTeamDetailsBridge(IChppAccessor accessor)
            : base(accessor)
        {

        }

        public TeamDetails GetTeamDetails(uint teamId)
        {
            string url = new StringBuilder("file=teamdetails&version=2.6&teamID=")
                                       .Append(teamId).ToString();

            XDocument doc = XDocument.Load(ChppAccessor.GetDataReader(url, DataFlags.Dynamic));

            XElement elUser = doc.Root.AssertElement("User");

            int userId = int.Parse(elUser.AssertElement("UserID").Value);
            string userName = elUser.AssertElement("Loginname").Value;
            DateTime userJoinDate = DateTime.Parse(elUser.AssertElement("ActivationDate").Value); // not <SignupDate> here

            User user = new User(userId, userName) { JoinDate = userJoinDate };

            Team team = MatchParserHelper.GetTeam(doc.Root.AssertElement("Team"), string.Empty);

            return new TeamDetails(team.ID, team.Name) { Owner = user };
        }
    }
}
