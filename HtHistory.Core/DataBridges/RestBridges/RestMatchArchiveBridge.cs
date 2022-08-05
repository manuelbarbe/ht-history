using HtHistory.Data.Types;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtHistory.Core.DataBridges.RestBridges
{
    public class RestMatchArchiveBridge : RestBridgeBase, IMatchArchiveBridge
    {
        public RestMatchArchiveBridge(string base_url) : base(base_url)
        {
        }

        public MatchArchive GetMatches(uint teamId, DateTime startDate, DateTime endDate)
        {
            string url = string.Format("/teams/{0}/matcharchive?start={1}&end={2}",
                teamId,
                startDate.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                endDate.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
            
            string json = ReadFromUrl(url);
            var MatchArchive = Newtonsoft.Json.JsonConvert.DeserializeObject<MatchArchive>(json);
            return MatchArchive;
        }
    }
}
