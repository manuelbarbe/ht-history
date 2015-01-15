using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.DataContainers;
using HtHistory.Core.DataBridges;
using HtHistory.Core;

namespace HtHistory.Tasks
{
    public class GetTransfersTask : BaseTask
    {
        private ITransferHistoryBridge _thb;
        private int _teamId;

        private TransferHistory _th = null;

        public GetTransfersTask(int teamId, ITransferHistoryBridge thb)
        {
            if (thb == null) throw new ArgumentNullException("thb");
            _thb = thb;

            _teamId = teamId;
        }

        public int TeamId { get { return _teamId; } }

        public override string Name
        {
            get { return "GetTransfersTask"; }
        }

        protected override object DoImpl()
        {
            //if (_pl == null)
            {
                ReportProgress(10, "Getting complete transfer history");
                _th = _thb.GetTransfers((uint)TeamId);
                ReportProgress(100, "done");
            }

            return _th;
        }
    }
}
