﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.DataContainers;

namespace HtHistory.Core.DataBridges
{
    public class DataBridgeFactory : IDataBridgeFactory
    {
        public IMatchArchiveBridge MatchArchiveBridge
        {
            get;
            set;
        }

        public IDataBridge<MatchDetails> MatchDetailsBridge
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
