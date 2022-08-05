using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Data.Types
{
    public class TransferHistory
    {
        public TransferHistory(Team team, DateTime from, DateTime to)
        {
            if (team == null) throw new ArgumentNullException("team");
            Team = team;
            From = from;
            To = to;
        }

        public virtual Team Team { get; set; }
        public virtual DateTime From { get; set; }
        public virtual DateTime To { get; set; }

        public virtual IEnumerable<Transfer> Transfers { get; set; }

    }
}
