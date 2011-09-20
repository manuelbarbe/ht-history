using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.DataContainers;

namespace HtHistory.Core.DataBridges
{
    public interface IMatchArchiveBridge
    {
        MatchArchive GetMatches(uint teamId, DateTime startDate, DateTime endDate);
    }
}
