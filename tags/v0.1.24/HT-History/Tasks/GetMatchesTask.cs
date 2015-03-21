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
        private IDataBridge<MatchDetails> _mdb;
        private ITeamDetailsBridge _tdb;
        private DateTime? _startDate;
        private DateTime? _endDate;
        private int _teamId;

        private IList<MatchDetails> _mdl = null;

        public GetMatchesTask(  int teamId,
                                DateTime? startDate,
                                DateTime? endDate,
                                IMatchArchiveBridge mab,
                                IDataBridge<MatchDetails> mdb)
        {
            if (startDate == null) throw new ArgumentNullException("startDate");
            _startDate = startDate;

            if (endDate == null) throw new ArgumentNullException("endDate");
            _endDate = endDate;

            if (mab == null) throw new ArgumentNullException("mab");
            _mab = mab;

            if (mdb == null) throw new ArgumentNullException("mdb");
            _mdb = mdb;

            _teamId = teamId;
        }

        public GetMatchesTask(int teamId, ITeamDetailsBridge tdb, IMatchArchiveBridge mab, IDataBridge<MatchDetails> mdb)
        {
            if (tdb == null) throw new ArgumentNullException("tbd");
            _tdb = tdb;

            if (mab == null) throw new ArgumentNullException("mab");
            _mab = mab;

            if (mdb == null) throw new ArgumentNullException("mdb");
            _mdb = mdb;
            
            _teamId = teamId;
        }

        public int TeamId { get { return _teamId; } } 

        protected override object DoImpl()
        {
            //if (_mdl == null)
            {
                ReportProgress(0, "Getting general team information");

                DateTime? startDate = _startDate;
                DateTime? endDate = _endDate;

                if (_tdb != null)
                {
                    TeamDetails teamDetails = _tdb.GetTeamDetails((uint)_teamId);
                    if (teamDetails == null || teamDetails.Owner == null || teamDetails.Owner.JoinDate == null)
                    {
                        throw new Exception("Cannot get join date of owner");
                    }

                    startDate = teamDetails.Owner.JoinDate.Value;
                    endDate = DateTime.Now.ToHtTime();
                }

                if (startDate == null || endDate == null)
                {
                    throw new Exception("missing start and/or end date");
                }

                //ReportProgress(10, String.Format("Getting match archive from {0} to {1}", startDate.Value.ToShortDateString(), endDate.Value.ToShortDateString()));
                ReportProgress(10, "Getting match archive");


                MatchArchive ar = _mab.GetMatches((uint)_teamId, startDate.Value, endDate.Value);
                int noMatches = ar.Count();
                int noCurMatch = 0;

                _mdl = new List<MatchDetails>();
                foreach (Match m in ar.SafeEnum())
                {
                    ReportProgress(20 + (80 * noCurMatch / noMatches), String.Format("Getting match {0}/{1}", noCurMatch + 1, noMatches));
                    _mdl.Add(_mdb.Get((uint)m.ID));
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
