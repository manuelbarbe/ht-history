using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace HtHistory.Dialogs
{
    public partial class ChooseItemBox : Form
    {
        public ChooseItemBox(IEnumerable items)
        {
            InitializeComponent();
            listBox1.Items.Clear();
            foreach (object item in items)
            {
                listBox1.Items.Add(item);
            }
            if (listBox1.Items.Count > 0)
            {
                listBox1.SelectedIndex = 0;
            }
        }

        public object Item
        {
            get
            {
                return listBox1.SelectedItem;
            }
        }
    }
}
