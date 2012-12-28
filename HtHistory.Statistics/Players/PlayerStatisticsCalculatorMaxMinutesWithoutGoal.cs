using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Statistics.Players
{
    public class PlayerStatisticsCalculatorMaxMinutesWithoutGoal : PlayerStatisticsCalculatorBase<IEnumerable<MatchAppearance>, uint>
    {
        public override string Abbreviation
        {   
            get { return "MinWithout"; }
        }

        public override string Name
        {
            get { return "Consecutive minutes without goal"; }
        }

        public override uint Calculate(IEnumerable<MatchAppearance> source)
        {
            uint curMinutes = 0;
            uint maxMinutes = 0;
            IEnumerable<MatchAppearance> sortedMatches = source.OrderBy(m => m.Match.Date);
            foreach (var v in sortedMatches)
            {
                if (v.Goals.Count == 0)
                {
                    curMinutes += v.Minutes;
                }
                else
                {
                    //TODO: handle minutes between goals in same match
                    curMinutes += (v.Goals.Min(g => g.Minute) - (v.SubstituteIn ?? 0));
                    if (curMinutes > maxMinutes) maxMinutes = curMinutes;
                    curMinutes = (v.SubstituteOut ?? v.Match.Minutes) - v.Goals.Max(g => g.Minute);
                }
            }

            if (curMinutes > maxMinutes) maxMinutes = curMinutes;

            return maxMinutes;
        }
    }
}
