using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.DataContainers;

namespace HtHistory.Core.DataBridges
{
    public interface IMatchDetailsBridge : IDataBridge<MatchDetails>
    {
        MatchDetails GetMatchDetails(uint matchId);
    }
}
