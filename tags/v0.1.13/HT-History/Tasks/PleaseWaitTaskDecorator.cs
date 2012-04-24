using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace HtHistory.Tasks
{
    public class PleaseWaitTaskDecorator : ITask
    {
        private ITask _decoratee;
        private PleaseWaitDialog _box = new PleaseWaitDialog();

        public PleaseWaitTaskDecorator(ITask decoratee)
        {
            if (decoratee == null) throw new ArgumentNullException("decoratee");
            _decoratee = decoratee;
            _decoratee.ProgressChanged += ProgressWrapper;

            // do some magic to force creation of the window handle so Invoke() can be used
            IntPtr h = _box.Handle;
            _box.Invoke( (Action)(() => { _box.Text = _decoratee.Name; }));
        }

        public string Name
        {
            get { return _decoratee.Name; }
        }

        public object Result
        {
            get { return _decoratee.Result; }
        }

        public void Do()
        {
            _box.Invoke((Action)(() =>
            {
                _box.ReportProgress(0, "started");
                _box.Show();
            }));
            try
            {
                _decoratee.Do();
            }
            finally
            {
                _box.Invoke((Action)(() =>
                {
                    _box.Hide();
                }));
            }
        }

        public event System.ComponentModel.ProgressChangedEventHandler ProgressChanged;

        public void ProgressWrapper(object sender, ProgressChangedEventArgs e)
        {
            _box.BeginInvoke( (Action) (() =>
            {
                _box.ReportProgress(e.ProgressPercentage, e.UserState == null ? string.Empty : e.UserState.ToString());
            }));
         
            if (ProgressChanged != null)
            {
                ProgressChanged(sender, e);
            }
        }

    }
}
