using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Data.Types;

namespace HtHistory.Core.DataBridges
{
    public interface IMatchDetailsBridge
    {
        MatchDetails GetMatchDetails(uint matchId);
    }
}
