using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace HtHistory.Dialogs
{
    public partial class WhatsNewBox : Form
    {
        public WhatsNewBox()
        {
            InitializeComponent();
        }

        private void WhatsNewBox_Load(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.LoadFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "version.txt"), RichTextBoxStreamType.PlainText);
            }
            catch (Exception ex)
            {
                richTextBox1.Text = "error loading version.txt";
            }
        }
    }
}
