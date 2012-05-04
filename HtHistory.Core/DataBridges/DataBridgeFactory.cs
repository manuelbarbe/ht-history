using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Core.DataBridges
{
    public class DataBridgeFactory : IDataBridgeFactory
    {
        public IMatchArchiveBridge MatchArchiveBridge
        {
            get;
            set;
        }

        public IMatchDetailsBridge MatchDetailsBridge
        {
            get;
            set;
        }

        public ITeamDetailsBridge TeamDetailsBridge
        {
            get;
            set;
        }

        public IPlayersBridge PlayersBridge
        {
            get;
            set;
        }

        public ITransferHistoryBridge TransfersBridge
        {
            get;
            set;
        }
    }
}
