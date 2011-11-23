﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.DataContainers;

namespace HtHistory.Statistics.Players
{
    public class MatchAppearance
    {
        public Player Player { get; set; }
        public MatchDetails Match { get; set; }
        public Lineup.LineupRole Role { get; set; }
        public IList<Goal> Goals { get; set; }
        public uint? SubstituteIn { get; set; }
        public uint? SubstituteOut { get; set; }
        public uint? YellowCarded { get; set; }
        public uint? RedCarded { get; set; }

        public uint Minutes
        {
            get
            {
                try
                {
                    checked
                    {
                        uint minutes = Match.Minutes;

                        if (SubstituteIn != null) minutes -= SubstituteIn.Value;
                        if (SubstituteOut != null) minutes -= (Match.Minutes - SubstituteOut.Value);
                        if (RedCarded != null) minutes -= (Match.Minutes - RedCarded.Value);

                        return minutes;
                    }
                }
                catch
                {
                    return 0;
                }
            }
        }

        public MatchAppearance(Player player, MatchDetails match, Lineup.LineupRole role)
        {
            if (player == null || match == null) throw new ArgumentNullException("player or match");

            Player = player;
            Match = match;
            Role = role;
            Goals = new List<Goal>();
        }
    }
}
