using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Data.Types;

namespace HtHistory.Statistics.Players
{
    public class MatchAppearance
    {
        public Player Player { get; set; }
        public Team TeamOfPlayer { get; set; }
        public MatchDetails Match { get; set; }
        public Lineup.LineupRole Role { get; set; }
        public IList<Goal> Goals { get; set; }
        public double? RatingStars { get; set; }
        public uint? SubstituteIn { get; set; }
        public uint? SubstituteOut { get; set; }
        public uint? Bruised { get; set; }
        public uint? Injured { get; set; }
        public uint? YellowCarded { get; set; }
        public uint? RedCarded { get; set; }
        public bool BestPlayer { get; set; }


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

        public MatchAppearance(Player player, Team teamOfPlayer, MatchDetails match, Lineup.LineupRole role, double? ratingStars = null)
        {
            if (player == null || teamOfPlayer == null || match == null) throw new ArgumentNullException("player, team or match");

            Player = player;
            TeamOfPlayer = teamOfPlayer;
            Match = match;
            Role = role;
            RatingStars = ratingStars;
            Goals = new List<Goal>();
        }
    }
}
