using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.DataBridges.ChppBridges.ChppFileAccessors;
using HtHistory.Core.DataContainers;

namespace HtHistory.Core.DataBridges.ChppBridges
{
    public class ChppTransferHistoryBridge : ChppBridgeBase, ITransferHistoryBridge
    {
        public ChppTransferHistoryBridge(IChppAccessor accessor)
            : base(accessor)
        {

        }

        public DataContainers.TransferHistory GetTransfers(uint teamId)
        {
            List<Transfer> matches = new List<Transfer>();

            StringBuilder url = new StringBuilder("file=transfersteam&version=1.2")
                            .Append("&teamID=").Append(teamId)
                            .Append("&pageIndex=");

            return null;
       
        }
    }
}
