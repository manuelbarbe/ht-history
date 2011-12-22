using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.DataContainers;
using HtHistory.Core.DataBridges;

namespace HtHistory
{
    static class Environment
    {
        public static Team Team { get; set; }
        public static Team Opponent { get; set; }

        public static IDataBridgeFactory DataBridgeFactory { get; set; }
    }
}
