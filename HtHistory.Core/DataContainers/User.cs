using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Core.DataContainers
{
    public class User : HtNamedObject
    {
        public User(int id, string name) : base(id, name) { }

        public DateTime? JoinDate { get; set; }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder(base.ToString());
            if (JoinDate != null)
            {
                b.Append(" (joined: ").Append(JoinDate.Value.ToShortDateString()).Append(")");
            }
            return b.ToString();
        }
    }
}
