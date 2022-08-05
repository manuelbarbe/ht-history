using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Data.Types
{
    public class PlayerDetails : Player
    {
        public PlayerDetails(int id, string givenName, string nickName, string surName)
            : base(id,
            string.IsNullOrEmpty(nickName) ? string.Format("{0} {1}", givenName, surName)
                                           : string.Format("{0} '{1}' {2}", givenName, nickName, surName))
        { }
    }
}
