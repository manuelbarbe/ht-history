using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HtHistory.Pages
{
    public abstract partial class OverviewDetailsPage : UserControl
    {
        public OverviewDetailsPage()
        {
            InitializeComponent();

            Box = new PleaseWaitDialog();
            Worker = new BackgroundWorker();
            Worker.DoWork += DoWork;
            Worker.RunWorkerCompleted += (s, e) => { if (Box.Visible) Box.Hide(); ShowResult(s, e); };
        }

        protected BackgroundWorker Worker { get; set; }
        protected PleaseWaitDialog Box { get; set; }

        public virtual void StartWorking()
        {
            if (!Worker.IsBusy)
            {
                Box.Show();
                Worker.RunWorkerAsync();
            }
        }

        protected abstract void DoWork(object sender, DoWorkEventArgs e);
 
        protected abstract void ShowResult(object sender, RunWorkerCompletedEventArgs e);


    }
}
