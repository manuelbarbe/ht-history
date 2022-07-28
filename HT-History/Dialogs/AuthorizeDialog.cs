using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HtHistory.Core.DataBridges.ChppBridges.ChppFileAccessors;

namespace HtHistory
{
    public partial class AuthorizeDialog : Form
    {
        public AuthorizeDialog()
        {
            InitializeComponent();
        }

        private ChppOnlineAccessor _accessor = new ChppOnlineAccessor();
        public string AccessToken { get; private set; }
        public string AccessTokenSecret { get; private set; }

        private void AuthorizeDialog_Load(object sender, EventArgs e)
        {
            try
            {
                noTr_linkLabelRequestUri.Text = _accessor.GetAuthorizeUrl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("It seems, that CHPP cannot be accessed right now. Please check your internet connection or try again later.\n\n{0}", ex), "Error");
                DialogResult = DialogResult.Abort;
                Close();
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                string[] token_info = _accessor.Authorize(noTr_textBoxPIN.Text);
                AccessToken = token_info[0];
                AccessTokenSecret = token_info[1];
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("This failed. Please try again.\n\n{0}", ex), "Error");
            }
        }

        private void linkLabelRequestUri_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //System.Diagnostics.Process.Start(noTr_linkLabelRequestUri.Text);
            //Clipboard.SetText(noTr_linkLabelRequestUri.Text);
            string url = noTr_linkLabelRequestUri.Text.Replace("&", "^&");
            Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
            
        }
    }
}
