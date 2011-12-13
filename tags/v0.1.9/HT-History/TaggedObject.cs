using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory
{
    public class TaggedObject
    {
        public TaggedObject(object obj, object tag = null)
        {
            Object = obj;
            Tag = tag;
        }

        public object Object { get; set; }
        public object Tag { get; set; }

        public override string ToString()
        {
            return (Object == null) ? "(null)" : Object.ToString();
        }
    }
}
