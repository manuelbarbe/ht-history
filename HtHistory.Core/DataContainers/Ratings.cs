using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Core.DataContainers
{
    public class Ratings
    {
        public class SectorRating
        {
            public Ability Ability
            {
                get
                {
                    if (Value == 0) return Ability.NonExistent;
                    else return (Ability)(Value + 3 / 4);
                }
            }

            public SubAbility Sub
            {
                get
                {
                    if (Value == 0) return SubAbility.VeryLow;
                    else return (SubAbility)((Value % 4) + 1);
                }
            }

            public uint Value { get; private set; } 

            public SectorRating(uint value)
            {
                Value = value;
            }

            public static implicit operator SectorRating(uint i)
            {
                return new SectorRating(i);
            }

            public static explicit operator uint(SectorRating r)
            {
                return r.Value;
            }

            public override string ToString()
            {
                return String.Format("{0} ({1})", Ability.ToString(), Sub.ToString());
            }
        }

        public SectorRating Midfield { get; private set; }
        public SectorRating LeftDefense { get; private set; }
        public SectorRating RightDefense { get; private set; }
        public SectorRating CentralDefense { get; private set; }
        public SectorRating LeftAttack { get; private set; }
        public SectorRating RightAttack { get; private set; }
        public SectorRating CentralAttack { get; private set; }

        public Ratings( SectorRating midfield,
                        SectorRating leftDefense,
                        SectorRating rightDefense,
                        SectorRating centralDefense,
                        SectorRating leftAttack,
                        SectorRating rightAttack,
                        SectorRating centralAttack)
        {
            Midfield = midfield;
            LeftDefense = leftDefense;
            RightDefense = rightDefense;
            CentralDefense = centralDefense;
            LeftAttack = leftAttack;
            RightAttack = rightAttack;
            CentralAttack = centralAttack;
        }

    }
}
