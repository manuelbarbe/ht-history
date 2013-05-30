using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Tasks
{
    public class NullTask : ITask
    {
        public string Name
        {
            get { return "NullTask"; }
        }

        public object Result
        {
            get { return null; }
        }

        public void Do()
        {
            ;
        }

        public event System.ComponentModel.ProgressChangedEventHandler ProgressChanged;
    }
}
