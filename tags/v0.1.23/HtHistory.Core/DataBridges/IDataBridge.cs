using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Core.DataBridges
{
    public interface IDataBridge<T>
    {
        T Get(uint id);
        void Set(uint id, T t);
    }
}
