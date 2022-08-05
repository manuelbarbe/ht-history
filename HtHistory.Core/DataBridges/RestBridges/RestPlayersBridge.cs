using HtHistory.Core.DataContainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtHistory.Core.DataBridges.RestBridges
{
    public class RestPlayersBridge : RestBridgeBase, IPlayersBridge
    {
        public RestPlayersBridge(string base_url) : base(base_url)
        {
        }

        public IEnumerable<PlayerDetails> GetPlayers(uint teamId)
        {
            yield break;
        }
    }
}
