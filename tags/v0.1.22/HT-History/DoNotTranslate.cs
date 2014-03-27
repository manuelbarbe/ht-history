using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory
{
    [AttributeUsage(AttributeTargets.Field)]
    public class DoNotTranslate : System.Attribute
    {
        public DoNotTranslate(string reason)
        {
        }
    }
}
