using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace HtHistory
{
    public partial class WebProxyDialog : Form
    {
        public WebProxyDialog()
        {
            InitializeComponent();
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            try
            {
                IWebProxy proxy = string.IsNullOrEmpty(textBoxProxyURI.Text) ? null : new WebProxy(textBoxProxyURI.Text);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.google.com");
                request.Proxy = proxy;
                request.Timeout = 10000; // 10 sec.
                request.UserAgent = "HT-History test client";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK) MessageBox.Show("Everything is fine!");
                else MessageBox.Show(response.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
