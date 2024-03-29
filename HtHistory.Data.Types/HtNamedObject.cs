﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Data.Types
{
    public class HtNamedObject : HtObject
    {
        public HtNamedObject(int id, string name)
            : base(id)
        {
            if (name == null) throw new ArgumentNullException("name");
            Name = name;
        }

        public string Name { get; protected set; }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, ID);
        }
    }
}
