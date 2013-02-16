using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Statistics.Types;
using HtHistory.Core.DataContainers;

namespace HtHistory.Statistics.Players
{
    public class PlayerStatisticsCalculatorMaxMinutesWithoutOppGoal :
        PlayerStatisticsCalculatorBase<IEnumerable<MatchAppearance>, TimeIntervalValue<uint>>
    {
        public override string Abbreviation
        {
            get { return "MinNotConceded"; }
        }

        public override string Name
        {
            get { return "Consecutive minutes without conceding a goal"; }
        }

        public override TimeIntervalValue<uint> Calculate(IEnumerable<MatchAppearance> source)
        {
            TimeIntervalValue<uint> cur = new TimeIntervalValue<uint>() { Value = 0 };
            TimeIntervalValue<uint> max = new TimeIntervalValue<uint>() { Value = 0 };

            IEnumerable<MatchAppearance> sortedMatches = source.OrderBy(m => m.Match.Date);
            foreach (var v in sortedMatches)
            {
                if (cur.Interval == null) cur.Interval = new TimeInterval(v.Match.Date, v.Match.Date);
                cur.Interval.End = v.Match.Date;

                uint minuteOn = v.SubstituteIn == null ? 0 : v.SubstituteIn.Value;
                uint minuteOff = v.SubstituteOut == null ? v.Match.Minutes : v.SubstituteOut.Value;
                if (v.RedCarded != null) minuteOff = v.RedCarded.Value;

                IEnumerable<Goal> opponentGoalsWhileOnPitch = v.Match.Goals.Where( g =>
                    g.Team.ID != v.TeamOfPlayer.ID &&
                    g.Minute >= minuteOn &&
                    g.Minute <= minuteOff);
                
                if (opponentGoalsWhileOnPitch.Count() == 0)
                {
                    cur.Value += (minuteOff - minuteOn);
                }
                else
                {
                    //TODO: handle minutes between goals in same match
                    cur.Value += (opponentGoalsWhileOnPitch.Min(g => g.Minute) - minuteOn);

                    if (cur.Value > max.Value) max = cur;
                    cur = new TimeIntervalValue<uint>()
                    {
                        Value = minuteOff - opponentGoalsWhileOnPitch.Max(g => g.Minute),
                        Interval = new TimeInterval(v.Match.Date, v.Match.Date)
                    };
                }
            }

            if (cur.Value > max.Value) max = cur;

            return max;
        }
    }
}
