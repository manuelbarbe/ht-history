using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.ExtensionMethods;

namespace HtHistory.Core.DataContainers
{
    public class MatchArchive
    {
        public MatchArchive(Team team, DateTime from, DateTime to)
        {
            if (team == null) throw new ArgumentNullException("team");
            Team = team;
            From = from;
            To = to;
        }

        public virtual Team Team { get; set; }
        public virtual DateTime From { get; set; }
        public virtual DateTime To { get; set; }

        public virtual IEnumerable<Match> Matches { get; set; }

        public virtual IEnumerator<Match> GetEnumerator()
        {
            return Matches.SafeEnum().GetEnumerator();
        }
    }
}
