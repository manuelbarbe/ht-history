using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.DataContainers;

namespace HtHistory.Core.DataBridges
{
    public interface IPlayersBridge
    {
        IEnumerable<PlayerDetails> GetPlayers(uint teamId);
    }
}
