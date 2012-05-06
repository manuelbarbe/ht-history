using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace HtHistory.Tasks
{
    public interface ITask
    {
        string Name { get; }
        
        object Result { get; }
        void Do();

        event ProgressChangedEventHandler ProgressChanged;
    }
}
