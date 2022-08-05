using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.DataBridges.ChppBridges.ChppFileAccessors;

namespace HtHistory.Core.DataBridges.ChppBridges
{
    public class ChppBridgeBase
    {
        public ChppBridgeBase(IChppAccessor chppAccessor)
        {
            ChppAccessor = chppAccessor;
        }

        protected IChppAccessor ChppAccessor { get; private set; }

    }
}
