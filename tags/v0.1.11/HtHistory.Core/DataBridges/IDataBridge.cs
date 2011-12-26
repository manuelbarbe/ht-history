using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Core.DataBridges
{
    interface IDataBridge<T>
    {
        T Get(uint id);
    }
}
