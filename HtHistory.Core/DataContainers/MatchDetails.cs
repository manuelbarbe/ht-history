﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.ExtensionMethods;

namespace HtHistory.Core.DataContainers
{
    public class MatchDetails : Match
    {
        public MatchDetails(int id, MatchType type, Team home, Team away)
            : base(id, type, home, away)
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
