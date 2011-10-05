using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Core.DataContainers
{
    public class Player : HtNamedObject
    {
        public static readonly string UnknownName = "unknown player";

        public Player(uint id, string name)
            : base(id, name)
        {
        }
    }
}
