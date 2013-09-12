using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Core.DataBridges.DatabaseBridges
{
    public class DatabaseMatchDetailsBridge : IMatchDetailsBridge
    {
        public DataContainers.MatchDetails GetMatchDetails(uint matchId)
        {
            return null;
        }

        public DataContainers.MatchDetails Get(uint id)
        {
            return GetMatchDetails(id);
        }

        public void Set(uint id, DataContainers.MatchDetails t)
        {
            ;
        }
    }
}
