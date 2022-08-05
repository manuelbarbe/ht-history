using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Toolbox;

namespace HtHistory.Data.Types
{
    public class MatchDetails : Match
    {
        public MatchDetails(int id, MatchType type, Team homeTeam, Team awayTeam)
            : base(id, type, homeTeam, awayTeam)
        {
        }

        private uint? _minutes = null;
        public uint Minutes
        {
            get
            {
                if (_minutes == null)
                {
                    foreach (MatchEvent ev in Events.SafeEnum())
                    {
                        if (ev.Type == MatchEvent.MatchEventType.MatchFinished)
                        {
                            _minutes = ev.Minute;
                        }
                    }

                    if (_minutes == null) _minutes = 90; // default to 90
                }

                return _minutes.Value; // default to 90
            }
        }

        public Crowd Visitors { get; set; }

        public IEnumerable<Goal> Goals { get; set; }
        public IEnumerable<MatchEvent> Events { get; set; }

        public Lineup HomeLineup { get; set; }
        public Lineup AwayLineup { get; set; }

        public Lineup HomeStartingLineup { get; set; }
        public Lineup AwayStartingLineup { get; set; }

        public Ratings HomeRatings { get; set; }
        public Ratings AwayRatings { get; set; }

    }
}
