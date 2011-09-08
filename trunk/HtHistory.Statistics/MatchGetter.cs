using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.DataContainers;
using HtHistory.Core.DataBridges;
using HtHistory.Core.ExtensionMethods;

namespace HtHistory.Statistics
{
    public class MatchGetter : IEnumerable<MatchDetails>
    {
        public MatchGetter( uint teamId,
                            uint opponentId,
                            ITeamDetailsBridge tdb,
                            IMatchArchiveBridge mab,
                            IMatchDetailsBridge mdb)
        {
            if (tdb == null || mab == null || mdb == null) throw new ArgumentNullException();
            TDB = tdb;
            MAB = mab;
            MDB = mdb;

            TeamId = teamId;
            OpponentId = opponentId;
        }

        public uint TeamId { get; private set; }
        public uint OpponentId { get; private set; }
        private ITeamDetailsBridge TDB { get; set; }
        private IMatchArchiveBridge MAB { get; set; }
        private IMatchDetailsBridge MDB { get; set; }

        public IEnumerator<MatchDetails> GetEnumerator()
        {
            TeamDetails teamDetails = TDB.GetTeamDetails(TeamId);
            if (teamDetails == null || teamDetails.Owner == null || teamDetails.Owner.JoinDate == null)
                throw new Exception("Cannot get join date of owner");

            MatchArchive ar = MAB.GetMatches(TeamId, teamDetails.Owner.JoinDate.Value, DateTime.Now); // todo: to ht time

            IList<MatchDetails> mdl = new List<MatchDetails>();

            foreach (Match m in ar.SafeEnum())
            {
                // check if specified opponent is playing match
                if (OpponentId != 0 && !(OpponentId == m.HomeTeam.ID || OpponentId == m.AwayTeam.ID)) continue;

                mdl.Add(MDB.GetMatchDetails(m.ID));
            }

            return mdl.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
