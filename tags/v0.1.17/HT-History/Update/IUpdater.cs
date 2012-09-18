using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Update
{
    interface IUpdater
    {
        Version GetAvailableUpdateVersion(Version currentVersion);
        void ApplyUpdate();
    }
}
