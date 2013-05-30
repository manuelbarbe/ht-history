using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Statistics.Types
{
    public class TimeIntervalValue<ValueType> : IComparable<TimeIntervalValue<ValueType>>
    {
        public TimeInterval Interval { get; set; }
        public ValueType Value { get; set; }

        public override string ToString()
        {
            if (Interval != null)
            {
                if (Value != null)
                    return string.Format("{0} ({1}-{2})", Value, Interval.Start.ToShortDateString(), Interval.End.ToShortDateString());
                else
                    return string.Format("(null) ({1}-{2})", null, Interval.Start.ToShortDateString(), Interval.End.ToShortDateString());
            }
            else
            {
                if (Value != null)
                    return string.Format("{0}", Value);
                else
                    return "(null)";
            }
        }

        public int CompareTo(TimeIntervalValue<ValueType> other)
        {
            if (other == null) return 1;
            return System.Collections.Generic.Comparer<ValueType>.Default.Compare(this.Value, other.Value);
        }
    }
}
