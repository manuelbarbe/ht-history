using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HtHistory.Core.DataBridges.ChppBridges.ChppFileAccessors
{
    [Flags]
    public enum DataFlags
    {
        Static  = 0x00000001,
        Dynamic = 0x00000002,
    }

    public interface IChppAccessor
    {
        TextReader GetDataReader(string query, DataFlags flags = DataFlags.Dynamic);
    }
}
