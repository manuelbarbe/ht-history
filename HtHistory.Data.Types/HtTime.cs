﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Data.Types
{
    public class HtTime
    {
        public static readonly DateTime HattrickEpoch = new DateTime(1997, 9, 22); //Monday?

        public HtTime(DateTime htTime)
        {
            DateTime = htTime;
        }

        public HtTime(int season, int week, int day = 1)
        {
            Season = season;
            Week = week;
            Day = day;
        }

        public DateTime DateTime
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                TimeSpan s = value - HattrickEpoch;
                int days = s.Days;
                Season = days / 7 / 16 + 1;
                Week = days / 7 % 16 + 1;
                Day = days % 7 + 1;
            }
        }

        //TODO: add checks
        public int Season { get; set; }
        public int Week { get; set; }
        public int Day { get; set; }

        public override string ToString()
        {
            return string.Format("({0}/{1,02})", Season, Week);
        }
    }
}
