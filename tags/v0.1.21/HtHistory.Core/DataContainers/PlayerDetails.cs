using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Core.DataContainers
{
    public class PlayerDetails : Player
    {
        public PlayerDetails(uint id, string givenName, string nickName, string surName)
            : base(id,
            string.IsNullOrEmpty(nickName) ? String.Format("{0} {1}", givenName, surName)
                                           : String.Format("{0} '{1}' {2}", givenName, nickName, surName))
        { }
    }
}
