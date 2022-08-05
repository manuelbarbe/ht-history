using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Data.Types
{
    public class Crowd
    {
        public uint? Terraces { get; set; }
        public uint? BasicSeats { get; set; }
        public uint? SeatsUnderRoof { get; set; }
        public uint? Vip { get; set; }
        public uint? Total { get; set; }
    }
}
