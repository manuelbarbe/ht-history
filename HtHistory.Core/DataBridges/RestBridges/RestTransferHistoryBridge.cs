using HtHistory.Core.DataContainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtHistory.Core.DataBridges.RestBridges
{
    public class RestTransferHistoryBridge : RestBridgeBase, ITransferHistoryBridge
    {

        public RestTransferHistoryBridge(string base_url) : base(base_url)
        {
        }

        public TransferHistory GetTransfers(uint teamId)
        {
            string json = ReadFromUrl(string.Format("/teams/{0}/transfers", teamId));
            var transferHistory = Newtonsoft.Json.JsonConvert.DeserializeObject<TransferHistory>(json);
            return transferHistory;
        }
    }
}
