using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace HtHistory
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
            this.ClientSize = this.BackgroundImage.Size;
        }

        private void SplashScreen_KeyDown(object sender, KeyEventArgs e)
        {
            //DialogResult = DialogResult.Cancel;
            //Close();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            Version v =  Assembly.GetExecutingAssembly().GetName().Version;
            labelVersion.Text = String.Format("v {0}.{1}.{2}", v.Major, v.Minor, v.Build);
        }
    }
}
