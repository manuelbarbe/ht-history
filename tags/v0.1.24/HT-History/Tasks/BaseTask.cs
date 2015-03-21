using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Tasks
{
    public abstract class BaseTask : ITask
    {
        private object _result;
        public object Result
        {
            get
            {
                if (_result == null) throw new Exception(String.Format("Task '{0}' was not processed yet", Name));
                return _result;
            }
            private set
            {
                _result = value;
            }
        }

        public abstract string Name { get; }
        protected abstract object DoImpl();

        public void Do()
        {
            Result = DoImpl();
        }

        protected void ReportProgress(int percentage, object status)
        {
            if (ProgressChanged != null)
            {
                ProgressChanged(this, new System.ComponentModel.ProgressChangedEventArgs(percentage, status));
            }
        }

        public event System.ComponentModel.ProgressChangedEventHandler ProgressChanged;
    }
}
