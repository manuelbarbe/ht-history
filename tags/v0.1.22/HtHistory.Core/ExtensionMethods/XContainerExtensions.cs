using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Text;

namespace HtHistory.Core.ExtensionMethods
{
    public static class XElementExtensions
    {
        public static XElement AssertElement(this XContainer el, XName name)
        {
            XElement foundEl = el.Element(name);
            if (foundEl == null) throw new Exception("element <" + name + ">not found");
            return foundEl;
        }
    }
}
