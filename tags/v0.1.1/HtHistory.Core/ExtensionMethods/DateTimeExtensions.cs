using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Core.ExtensionMethods
{
    public static class DateTimeExtensions
    {
        private static readonly TimeZoneInfo CET = TimeZoneInfo.FromSerializedString("W. Europe Standard Time;60;(UTC+01:00) Amsterdam, Berlin, Bern, Rom, Stockholm, Wien;Mitteleuropäische Zeit;Mitteleuropäische Sommerzeit;[01:01:0001;12:31:9999;60;[0;02:00:00;3;5;0;];[0;03:00:00;10;5;0;];];");
       
        public static DateTime ToHtTime(this DateTime localTime)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.Now.ToUniversalTime(), CET);
        }

    }
}
