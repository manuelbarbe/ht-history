using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

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

                return Comparer<TagType>.Default.Compare((TagType)x.Tag, (TagType)y.Tag);
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

        #endregion

        /// <summary>ctor
        /// </summary>
        public SortableListView()
        {
            View = View.Details;
            FullRowSelect = true;
            MultiSelect = false;
            ListViewItemSorter = this; // hej, we are self sorting
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
            MultiSelect = false;
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
    }

}
