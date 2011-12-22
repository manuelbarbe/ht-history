using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using HtHistory.Core.ExtensionMethods;

namespace HtHistory.Dialogs
{
    public partial class ChooseColumnsDialog : Form
    {
        public IEnumerable Left { get { return listBoxLeft.Items; } }
        public IEnumerable Right { get { return listBoxRight.Items; } }
        public string MyName { get { return textBoxName.Text; } }

        public ChooseColumnsDialog(IEnumerable left, IEnumerable right, string name = null)
        {
            InitializeComponent();

            foreach (object l in left.SafeEnum())
            {
                listBoxLeft.Items.Add(l);
            }

            foreach (object r in right.SafeEnum())
            {
                listBoxRight.Items.Add(r);
            }

            if (name == null)
            {
                labelName.Visible = textBoxName.Visible = false;
            }
            else
            {
                textBoxName.Text = name;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            IList movingItems = new ArrayList();

            listBoxRight.SelectedItems.Clear();

            foreach (object o in listBoxLeft.SelectedItems)
            {
                movingItems.Add(o);
            }

            foreach(object o in movingItems)
            {
                MoveItem(o, listBoxLeft.Items, listBoxRight.Items);
                listBoxRight.SelectedItems.Add(o);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            IList movingItems = new ArrayList();

            foreach (object o in listBoxRight.SelectedItems)
            {
                movingItems.Add(o);
            }

            foreach (object o in movingItems)
            {
                MoveItem(o, listBoxRight.Items, listBoxLeft.Items);
            }
        }

        private void MoveItem(object o, IList from, IList to)
        {
            from.Remove(o);
            to.Add(o);
        }

        private void SwapItem(IList list, object a, object b)
        {
            int index_a = list.IndexOf(a);
            int index_b = list.IndexOf(b);

            if (index_a == -1 || index_b == -1) return;

            list.Remove(a);
            list.Remove(b);

            if (index_a < index_b)
            {
                list.Insert(index_a, b);
                list.Insert(index_b, a);
            }
            else
            {
                list.Insert(index_b, a);
                list.Insert(index_a, b);
            }
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            object a = listBoxRight.SelectedItem;
            IList items = listBoxRight.Items;

            if (a != null) //is there an item selected?
            {
                int index_a = items.IndexOf(a);


                if (index_a > 0 )
                {
                    SwapItem(items, a, items[index_a - 1]);
                    listBoxRight.SelectedItem = a;
                }
            }
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            object a = listBoxRight.SelectedItem;
            IList items = listBoxRight.Items;

            if (a != null) //is there an item selected?
            {
                int index_a = items.IndexOf(a);

                if ((index_a != -1) && (index_a < (items.Count - 1)))
                {
                    SwapItem(items, a, items[index_a + 1]);
                    listBoxRight.SelectedItem = a;
                }
            }
        }

        private void listBoxRight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                buttonRemove_Click(sender, e);
            }
        }

        private void listBoxRight_DoubleClick(object sender, EventArgs e)
        {
            buttonRemove_Click(sender, e);
        }

        private void listBoxLeft_DoubleClick(object sender, EventArgs e)
        {
            buttonAdd_Click(sender, e);
        }
    }
}
