using HtHistory.Core.DataContainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtHistory.Core.DataBridges.RestBridges
{
    public class RestTeamDetailsBridge : RestBridgeBase, ITeamDetailsBridge
    {
     
        public RestTeamDetailsBridge(string base_url) : base(base_url)
        {
        }

        public TeamDetails GetTeamDetails(uint teamId)
        {
            string json = ReadFromUrl(string.Format("/teams/{0}/details", teamId));
            var teamDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<TeamDetails>(json);
            return teamDetails;
        }
    }
}
