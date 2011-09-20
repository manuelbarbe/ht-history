using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Core.DataContainers
{
    public class Lineup
    {
        public enum LineupRole
        {
            // old positions
            Keeper_ = 1,
            WingBackRight_ = 2,
            CentralDefender1_ = 3,
            CentralDefender2_ = 4,
            WingBackLeft_ = 5,
            WingerRight_ = 6,
            InnerMidfield1_ = 7,
            InnerMidfield2_ = 8,
            WingerLeft_ = 9,
            Forward1_ = 10,
            Forward2_ = 11,
            SubstitutionKeeper_ = 12,
            SubstitutionDefender_ = 13,
            SubstitutionInnerMidfield_ = 14,
            SubstitutionWinger_ = 15,
            SubstitutionForward_ = 16,

            // new positions
            Keeper = 100,
            WingBackRight = 101,
            CentralDefenderRight = 102,
            CentralDefenderMiddle = 103,
            CentralDefenderLeft = 104,
            WingBackLeft = 105,
            WingerRight = 106,
            InnerMidfieldRight = 107,
            InnerMidfieldMiddle = 108,
            InnerMidfieldLeft = 109,
            WingerLeft = 110,
            ForwardRight = 111,
            ForwardMiddle = 112,
            ForwardLeft = 113,
            SubstitutionKeeper = 114,
            SubstitutionDefender = 115,
            SubstitutionInnerMidfield = 116,
            SubstitutionWinger = 117,
            SubstitutionForward = 118,

            // unchanged postitions
            SetPiecesTaker = 17,
            Captain = 18,
            ReplacedPlayer1 = 19,
            ReplacedPlayer2 = 20,
            ReplacedPlayer3 = 21,

            // extended by me
            RedCardedPlayer = 21771,
            Unknown = 21772,
        }

        public class LineupItem
        {
            public Player Player { get; set; }
            public LineupRole Role { get; set; }
        }

        public Lineup()
        {
            LineupItems = new List<LineupItem>();
        }

        public IList<LineupItem> LineupItems { get; set; }
    }
}
