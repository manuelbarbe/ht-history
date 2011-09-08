using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Core.DataContainers
{
    public class MatchArchive : IEnumerable<Match>
    {
        public MatchArchive(Team team, DateTime from, DateTime to)
        {
            if (team == null) throw new ArgumentNullException("team");
            Team = team;
            FirstMatchDate = from;
            LastMatchDate = to;
        }

        public Team Team { get; set; }
        public DateTime FirstMatchDate { get; set; }
        public DateTime LastMatchDate { get; set; }

        public IEnumerable<Match> Matches { get; set; }

        public IEnumerator<Match> GetEnumerator()
        {
            return Matches.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
