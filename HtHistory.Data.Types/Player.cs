﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Data.Types
{
    public class Player : HtNamedObject
    {
        public static readonly string UnknownName = "unknown player";

        public Player(int id, string name)
            : base(id, name)
        {
        }
    }
}
