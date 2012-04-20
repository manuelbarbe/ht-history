using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.DataBridges;
using HtHistory.Core.DataContainers;
using HtHistory.Core.ExtensionMethods;

namespace HtHistory.Tasks
{
    public class GetMatchesTask : BaseTask
    {
        private IMatchArchiveBridge _mab;
        private IMatchDetailsBridge _mdb;
        private ITeamDetailsBridge _tdb;
        private uint _teamId;

        private IList<MatchDetails> _mdl = null;

        public GetMatchesTask(uint teamId, ITeamDetailsBridge tdb, IMatchArchiveBridge mab, IMatchDetailsBridge mdb)
        {
            if (tdb == null) throw new ArgumentNullException("tbd");
            _tdb = tdb;

            if (mab == null) throw new ArgumentNullException("mab");
            _mab = mab;

            if (mdb == null) throw new ArgumentNullException("mdb");
            _mdb = mdb;
            
            _teamId = teamId;
        }

        public uint TeamId { get { return _teamId; } } 

        protected override object DoImpl()
        {
            //if (_mdl == null)
            {
                ReportProgress(0, "Getting general team information");

                TeamDetails teamDetails = _tdb.GetTeamDetails(_teamId);
                if (teamDetails == null || teamDetails.Owner == null || teamDetails.Owner.JoinDate == null)
                {
                    throw new Exception("Cannot get join date of owner");
                }

                ReportProgress(10, "Getting match archive");

                MatchArchive ar = _mab.GetMatches(_teamId, teamDetails.Owner.JoinDate.Value, DateTime.Now.ToHtTime());
                int noMatches = ar.Count();
                int noCurMatch = 0;

                _mdl = new List<MatchDetails>();
                foreach (Match m in ar.SafeEnum())
                {
                    ReportProgress(20 + (80 * noCurMatch / noMatches), String.Format("Getting match {0}/{1}", noCurMatch + 1, noMatches));
                    _mdl.Add(_mdb.GetMatchDetails(m.ID));
                    ++noCurMatch;
                }

            }

            ReportProgress(100, "Done.");

            return _mdl;
        }


        public override string Name
        {
            get { return "GetMatchesTask"; }
        }


    }
}
