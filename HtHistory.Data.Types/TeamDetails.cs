using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Data.Types
{
    public class TeamDetails : Team
    {
        public TeamDetails(int id, string name) : base(id, name) { }

        public User Owner { get; set; }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder(base.ToString());
            if (Owner != null)
            {
                b.Append(", owned by: ").Append(Owner.ToString());
            }
            return b.ToString();
        }
    }
}
