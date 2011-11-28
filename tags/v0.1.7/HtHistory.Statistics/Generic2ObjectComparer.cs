using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace HtHistory.Statistics
{
    public class Generic2ObjectComparer<TagType> : IComparer
    {
        private IComparer<TagType> _comparer;

        public Generic2ObjectComparer(IComparer<TagType> comparer)
        {
            if (comparer == null) throw new ArgumentNullException("comparer");

            _comparer = comparer;
        }

        public int Compare(object x, object y)
        {
            if (x == null)
            {
                if (y == null) return 0;
                else return -1;
            }

            if (y == null) return 1;

            if (!(x is TagType))
            {
                if (!(y is TagType)) return 0;
                else return -1;
            }

            if (!(y is TagType)) return 1;

            return _comparer.Compare((TagType)x, (TagType)y);
        }  
    }
}
