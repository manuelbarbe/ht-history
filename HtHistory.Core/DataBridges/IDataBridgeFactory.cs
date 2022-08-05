using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Data.Types;

namespace HtHistory.Core.DataBridges
{
    public interface IDataBridgeFactory
    {
        IMatchArchiveBridge MatchArchiveBridge { get; }
        IMatchDetailsBridge MatchDetailsBridge { get; }
        ITeamDetailsBridge TeamDetailsBridge { get; }
        IPlayersBridge PlayersBridge { get; }
        ITransferHistoryBridge TransfersBridge { get; }
    }
}
