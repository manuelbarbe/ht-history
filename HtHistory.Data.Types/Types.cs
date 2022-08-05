using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Data.Types
{
    public enum Ability : uint
    {
        NonExistent = 0,
        Disastrous = 1,

        Divine = 20,
    }

    public enum SubAbility : uint
    {
        VeryLow = 1,
        Low = 2,
        High = 3,
        VeryHigh = 4,
    }

}
