using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HtHistory.Core.DataContainers;
using HtHistory.Core.ExtensionMethods;

namespace HtHistory.Pages
{
    public partial class TransfersPage : UserControl
    {
        public TransfersPage()
        {
            InitializeComponent();
            InitializeList();
        }


        private void InitializeList()
        {
            this.sortableListViewTransfers.Columns.AddRange(new ColumnHeader[] {
                new ColumnHeader() { Text = "Date", TextAlign = HorizontalAlignment.Left, Width = 90 },
                new ColumnHeader() { Text = "Week", TextAlign = HorizontalAlignment.Left, Width = 50 },
                new ColumnHeader() { Text = "B/S", TextAlign = HorizontalAlignment.Left, Width = 50 },
                new ColumnHeader() { Text = "Player", TextAlign = HorizontalAlignment.Left, Width = 220 },
                new ColumnHeader() { Text = "Team", TextAlign = HorizontalAlignment.Left, Width = 220 },  
                new ColumnHeader() { Text = "Price", TextAlign = HorizontalAlignment.Left, Width = 100 },
            });

            sortableListViewTransfers
                .SetSorter(0, UserControls.SortableListView.TagSorter<DateTime>())
                .SetSorter(1, UserControls.SortableListView.NullSorter)
                .SetSorter(5, UserControls.SortableListView.TagSorter<Money>());
        }

        public void ShowTransfers(TransferHistory th)
        {
            sortableListViewTransfers.Items.Clear();
            if (th == null || th.Team == null) return;

            sortableListViewTransfers.SuspendLayout();

            uint teamId = th.Team.ID;

            foreach (Transfer t in th.Transfers.SafeEnum())
            {   
                ListViewItem item = new ListViewItem(t.Date.ToShortDateString());
                item.Tag = t.Date;
                item.SubItems[0].Tag = item.Tag;

                object value = 0;

                value = new HtTime(t.Date);
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, (value != null) ? value.ToString() : "-") { Tag = value });

                value = (teamId == t.Buyer.ID) ? "bought" : "sold";
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                value = t.Player;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, (value != null) ? value.ToString() : "-") { Tag = value });

                value = (teamId == t.Buyer.ID) ? t.Seller : t.Buyer;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, (value != null) ? value.ToString() : "-") { Tag = value });

                value = t.Price;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, (value != null) ? value.ToString() : "-") { Tag = value });

                sortableListViewTransfers.Items.Add(item);
            }

            sortableListViewTransfers.ResumeLayout();

        }
    }
}
