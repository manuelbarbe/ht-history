using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.DataContainers;

namespace HtHistory.Core.DataBridges
{
    public interface IDataBridgeFactory
    {
        IMatchArchiveBridge MatchArchiveBridge { get; }
        IDataBridge<MatchDetails> MatchDetailsBridge { get; }
        ITeamDetailsBridge TeamDetailsBridge { get; }
        IPlayersBridge PlayersBridge { get; }
        ITransferHistoryBridge TransfersBridge { get; }
    }
}
