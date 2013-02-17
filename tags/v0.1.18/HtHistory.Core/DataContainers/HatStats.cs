using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Core.DataContainers
{
    public class HatStats
    {
        public uint Midfield { get; private set; }
        public uint LeftDefense { get; private set; }
        public uint RightDefense { get; private set; }
        public uint CentralDefense { get; private set; }
        public uint LeftAttack { get; private set; }
        public uint RightAttack { get; private set; }
        public uint CentralAttack { get; private set; }
        
        public static explicit operator HatStats(Ratings r)
        {
            HatStats hs = new HatStats();
            hs.Midfield = (uint)r.Midfield * 3;
            hs.LeftDefense = (uint)r.LeftDefense;
            hs.RightDefense = (uint)r.RightDefense;
            hs.CentralDefense = (uint)r.CentralDefense;
            hs.LeftAttack = (uint)r.LeftAttack;
            hs.RightAttack = (uint)r.RightAttack;
            hs.CentralAttack = (uint)r.CentralAttack;

            return hs;
        }

        public uint Total { get { return Midfield + LeftDefense + RightDefense + CentralDefense + LeftAttack + RightAttack + CentralAttack; } }
        public uint Defense { get { return LeftDefense + RightDefense + CentralDefense; } }
        public uint Attack { get { return LeftAttack + RightAttack + CentralAttack; } }

    }
}
