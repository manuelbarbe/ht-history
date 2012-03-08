using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Core.ExtensionMethods
{
    public static class DateTimeExtensions
    {
        private static readonly TimeZoneInfo CET = TimeZoneInfo.CreateCustomTimeZone(
			"HT Sweden time",
			new TimeSpan(1, 0, 0),
			"HT Sweden time",
			"HT Sweden time",
			"HT Sweden time", 
			new TimeZoneInfo.AdjustmentRule[]
				{TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(
					new DateTime(1, 1, 1),
					new DateTime(9999, 12, 31),
					new TimeSpan(1, 0, 0),
					TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 2, 0, 0), 3, 5, DayOfWeek.Sunday),
					TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 3, 0, 0), 10, 5, DayOfWeek.Sunday))
				},
			true);
			
        public static DateTime ToHtTime(this DateTime localTime)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.Now.ToUniversalTime(), CET);
        }

    }
}
