using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.ComponentModel;
using HtHistory.Export;
using System.IO;

namespace HtHistory.UserControls
{
    public class SortableListView : ListView, IComparer
    {
        #region Predefined sorters

        /// <summary>Predefined sorter for sorting by .Text property of subitems
        /// </summary>
        private class ListViewSubItemTextSorter : IComparer<ListViewItem.ListViewSubItem>
        {
            public int Compare(ListViewItem.ListViewSubItem x, ListViewItem.ListViewSubItem y)
            {
                if (x == null)
                {
                    if (y == null) return 0;
                    else return -1;
                }

                if (y == null) return 1;

                if (x.Text == null)
                {
                    if (y.Text == null) return 0;
                    else return -1;
                }

                if (y.Text == null) return 1;

                return Comparer<string>.Default.Compare(x.Text, y.Text);
            }
        }
       
        /// <summary>Predefined sorter for sorting by .Tag property of subitems
        /// </summary>
        /// <typeparam name="TagType">the type the tag will be casted to</typeparam>
        private class ListViewSubItemTagSorter<TagType> : IComparer<ListViewItem.ListViewSubItem>
        {
            private IComparer<TagType> _comparer;

            public ListViewSubItemTagSorter() : this (Comparer<TagType>.Default)
            {
            }

            public ListViewSubItemTagSorter(IComparer<TagType> comparer)
            {
                if (comparer == null) throw new ArgumentNullException("comparer");

                _comparer = comparer;
            }

            public int Compare(ListViewItem.ListViewSubItem x, ListViewItem.ListViewSubItem y)
            {
                if (x == null)
                {
                    if (y == null) return 0;
                    else return -1;
                }

                if (y == null) return 1;

                if (!(x.Tag is TagType))
                {
                    if (!(y.Tag is TagType)) return 0;
                    else return -1;
                }

                if (!(y.Tag is TagType)) return 1;

                return _comparer.Compare((TagType)x.Tag, (TagType)y.Tag);
            }
        }

        /// <summary>Predefined sorter for sorting by .Tag property of subitems
        /// </summary>
        private class ListViewSubItemTagSorter : IComparer<ListViewItem.ListViewSubItem>
        {
            private IComparer _comparer;

            public ListViewSubItemTagSorter()
                : this(Comparer.Default)
            {
            }

            public ListViewSubItemTagSorter(IComparer comparer)
            {
                if (comparer == null) throw new ArgumentNullException("comparer");

                _comparer = comparer;
            }

            public int Compare(ListViewItem.ListViewSubItem x, ListViewItem.ListViewSubItem y)
            {
                return _comparer.Compare(x.Tag, y.Tag);
            }
        }

        /// <summary>Predefined sorter for actually not sorting anything
        /// </summary>
        private class ListViewSubItemNullSorter : IComparer<ListViewItem.ListViewSubItem>
        {
            public int Compare(ListViewItem.ListViewSubItem x, ListViewItem.ListViewSubItem y)
            {
                return 0;
            }
        }

        /// <summary>Predefined default sorter instance
        /// </summary>
        public static IComparer<ListViewItem.ListViewSubItem> DefaultSorter = new ListViewSubItemTextSorter();
        /// <summary>Predefined null sorter instance
        /// </summary>
        public static IComparer<ListViewItem.ListViewSubItem> NullSorter = new ListViewSubItemNullSorter();
        /// <summary>Creates tag sorter instance
        /// </summary>
        /// <typeparam name="TagType"></typeparam>
        /// <returns></returns>
        public static IComparer<ListViewItem.ListViewSubItem> TagSorter<TagType>()
        {
            return new ListViewSubItemTagSorter<TagType>();
        }
        /// <summary>Creates tag sorter instance
        /// </summary>
        /// <typeparam name="TagType"></typeparam>
        /// <returns></returns>
        public static IComparer<ListViewItem.ListViewSubItem> TagSorter<TagType>(IComparer<TagType> comparer)
        {
            return new ListViewSubItemTagSorter<TagType>(comparer);
        }
        /// <summary>Creates tag sorter instance
        /// </summary>
        /// <returns></returns>
        public static IComparer<ListViewItem.ListViewSubItem> TagSorter()
        {
            return new ListViewSubItemTagSorter();
        }
        /// <summary>Creates tag sorter instance
        /// </summary>
        /// <returns></returns>
        public static IComparer<ListViewItem.ListViewSubItem> TagSorter(IComparer comparer)
        {
            return new ListViewSubItemTagSorter(comparer);
        }

        #endregion

        /// <summary>ctor
        /// </summary>
        public SortableListView()
        {
            View = View.Details;
            FullRowSelect = true;
            ListViewItemSorter = this; // hej, we are self sorting

            InitializeContextMenu();
        }

        #region sorter handling

        private IDictionary<int, IComparer<ListViewItem.ListViewSubItem>> _sorters = new Dictionary<int, IComparer<ListViewItem.ListViewSubItem>>();

        public IComparer<ListViewItem.ListViewSubItem> GetSorter(int column)
        {
            IComparer<ListViewItem.ListViewSubItem> sorter;
            if (_sorters.TryGetValue(column, out sorter))
            {
                return sorter ?? DefaultSorter;
            }

            return DefaultSorter;
        }
        public SortableListView SetSorter(int column, IComparer<ListViewItem.ListViewSubItem> sorter)
        {
            _sorters[column] = sorter;
            return this;
        }

        #endregion

        private int _currentSortColumn = -1;
        private SortOrder _currentSortOrder = SortOrder.None;

        #region ListView overrides

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            View = View.Details;
            FullRowSelect = true;
            ListViewItemSorter = this; // hej, we are self sorting
        }

        protected override void OnColumnClick(ColumnClickEventArgs e)
        {
            base.OnColumnClick(e);

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == _currentSortColumn)
            {
                // Reverse the current sort direction for this column.
                if (_currentSortOrder == SortOrder.Ascending)
                {
                    _currentSortOrder = SortOrder.Descending;
                }
                else
                {
                    _currentSortOrder = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                _currentSortColumn = e.Column;                
                _currentSortOrder = SortOrder.Descending;
            }

            // Perform the sort with these new sort options.
            Sort();
            
        }

        #endregion

        #region IComparer implementation

        /// <summary>
        /// This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
        /// </summary>
        /// <param name="x">First object to be compared</param>
        /// <param name="y">Second object to be compared</param>
        /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
        public int Compare(object x, object y)
        {
            int result = 0;

            if (_currentSortOrder == SortOrder.None || _currentSortColumn < 0) return 0;

            ListViewItem listviewX, listviewY;

            // Cast the objects to be compared to ListViewItem objects
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            if (_currentSortColumn >= listviewX.SubItems.Count)
            {
                if (_currentSortColumn >= listviewY.SubItems.Count) result = 0;
                else result = -1;
            }
            else if (_currentSortColumn >= listviewY.SubItems.Count) result = 1;
            else result = GetSorter(_currentSortColumn).Compare(listviewX.SubItems[_currentSortColumn],
                                                                listviewY.SubItems[_currentSortColumn]);

            if (_currentSortOrder == SortOrder.Descending) result = -result;

            return result;
        }

        #endregion

        #region context menu

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToCSVToolStripMenuItem;

        private void InitializeContextMenu()
        {
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip();
            this.copyToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToClipboardToolStripMenuItem, this.exportToCSVToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(170, 48);
            // 
            // copyToClipboardToolStripMenuItem
            // 
            this.copyToClipboardToolStripMenuItem.Name = "copyToClipboardToolStripMenuItem";
            this.copyToClipboardToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.copyToClipboardToolStripMenuItem.Text = "Copy to clipboard";
            this.copyToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyToClipboardToolStripMenuItem_Click);
            // 
            // exportToCSVToolStripMenuItem
            // 
            this.exportToCSVToolStripMenuItem.Name = "exportToCSVToolStripMenuItem";
            this.exportToCSVToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.exportToCSVToolStripMenuItem.Text = "Export to CSV...";
            this.exportToCSVToolStripMenuItem.Click += new System.EventHandler(this.exportToCSVToolStripMenuItem_Click);

            this.contextMenuStrip1.ResumeLayout(false);

            this.ContextMenuStrip = contextMenuStrip1;
        }

        private void copyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ITable table = this.ToTable();

            StringWriter wr = new StringWriter();
            new TableExporterBBCode().Export(table, wr);

            Clipboard.SetText(wr.ToString());
        }

        private void exportToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SaveDo(() =>
            {
                SaveFileDialog safeFileDialog = new SaveFileDialog();
                safeFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";

                if (safeFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ITable table = this.ToTable();
                    using (FileStream stream = new FileStream(safeFileDialog.FileName, FileMode.Create))
                    {
                        using (StreamWriter wr = new StreamWriter(stream, Encoding.UTF8))
                        {
                            //wr.Write((char)0xFEFF); // BOM
                            new TableExporterCSV(";").Export(table, wr);
                        }
                    }
                }
            });
        }

        private ITable ToTable()
        {
            Table table = new Table();
            IEnumerable<ColumnHeader> headers = Columns.Cast<ColumnHeader>();
            table.ColumHeaders = headers.Select((ch) => ch.Text).ToArray();

            ICollection items = (SelectedItems.Count > 1) ? (ICollection)SelectedItems : Items;

            table.Data =
            items.Cast<ListViewItem>().Select(
                (lvi) => lvi.SubItems.Cast<ListViewItem.ListViewSubItem>().Select(
                    (lvsi) => lvsi.Text).ToArray()).ToArray();

            return table;
        }

        /*
        [Category("Behavior")]
        public bool ShowContextMenu
        {
            get { }
            set { }
        }
        */


        #endregion
    }

}
