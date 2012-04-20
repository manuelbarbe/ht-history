using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.DataContainers;
using HtHistory.Core.DataBridges;
using HtHistory.Core;

namespace HtHistory.Tasks
{
    public class GetPlayersTask : BaseTask
    {
        private IPlayersBridge _pb;
        private uint _teamId;

        private IEnumerable<Player> _pl = null;

        public GetPlayersTask(uint teamId, IPlayersBridge pb)
        {
            if (pb == null) throw new ArgumentNullException("pb");
            _pb = pb;

            _teamId = teamId;
        }

        public uint TeamId { get { return _teamId; } }

        public override string Name
        {
            get { return "GetPlayersTask"; }
        }

        protected override object DoImpl()
        {
            //if (_pl == null)
            {
                _pl = _pb.GetPlayers(Environment.Team.ID);
            }

            return _pl;
        }
    }
}
