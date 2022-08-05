using HtHistory.Data.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtHistory.Core.DataBridges.RestBridges
{
    public class RestMatchDetailsBridge : RestBridgeBase, IMatchDetailsBridge
    {
        public RestMatchDetailsBridge(string base_url) : base(base_url)
        {
        }

        public MatchDetails GetMatchDetails(uint matchId)
        {
            string json = ReadFromUrl(string.Format("/matches/{0}/details", matchId));
            var matchDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<MatchDetails>(json);
            return matchDetails;
        }
    }
}
