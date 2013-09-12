using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Statistics.Types;

namespace HtHistory.Statistics.Players
{
    public class PlayerStatisticsCalculatorMaxMinutesWithoutPlayerGoal :
        PlayerStatisticsCalculatorBase<IEnumerable<MatchAppearance>, TimeIntervalValue<uint> >
    {
        public override string Abbreviation
        {   
            get { return "MinNotScored"; }
        }

        public override string Name
        {
            get { return "Consecutive minutes without scoring a goal"; }
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

                if (v.Goals.Count == 0)
                {
                    cur.Value += v.Minutes;
                }
                else
                {
                    //TODO: handle minutes between goals in same match
                    cur.Value += (v.Goals.Min(g => g.Minute) - (v.SubstituteIn ?? 0));
                    if (cur.Value > max.Value) max = cur;
                    cur = new TimeIntervalValue<uint>()
                    {
                        Value = (v.SubstituteOut ?? v.Match.Minutes) - v.Goals.Max(g => g.Minute),
                        Interval = new TimeInterval(v.Match.Date, v.Match.Date)
                    };
                }
            }

            if (cur.Value > max.Value) max = cur;

            return max;
        }
    }
}
