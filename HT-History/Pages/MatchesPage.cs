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
    public partial class MatchesPage : UserControl
    {
        public MatchesPage()
        {
            InitializeComponent();
            this.sortableListViewMatches.Columns.AddRange(new ColumnHeader[] {
                new ColumnHeader() { Text = "Date", TextAlign = HorizontalAlignment.Left, Width = 90 },
                new ColumnHeader() { Text = "Week", TextAlign = HorizontalAlignment.Left, Width = 50 },
                new ColumnHeader() { Text = "Opponent", TextAlign = HorizontalAlignment.Left, Width = 220 },
                new ColumnHeader() { Text = "Type", TextAlign = HorizontalAlignment.Left, Width = 150 },  
                new ColumnHeader() { Text = "Venue", TextAlign = HorizontalAlignment.Left, Width = 50 },
                new ColumnHeader() { Text = "Goals", TextAlign = HorizontalAlignment.Center, Width = 70 },
                new ColumnHeader() { Text = "OppGoals", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "Visitors", TextAlign = HorizontalAlignment.Right, Width = 50 },
                new ColumnHeader() { Text = "Hatstats", TextAlign = HorizontalAlignment.Center, Width = 70 },
                new ColumnHeader() { Text = "OppHatstats", TextAlign = HorizontalAlignment.Center, Width = 100 },
            });

            sortableListViewMatches
                .SetSorter(0, UserControls.SortableListView.TagSorter<DateTime>())
                .SetSorter(1, UserControls.SortableListView.NullSorter)
                .SetSorter(5, UserControls.SortableListView.TagSorter<uint>())
                .SetSorter(6, UserControls.SortableListView.TagSorter<uint>())
                .SetSorter(7, UserControls.SortableListView.TagSorter<uint>())
                .SetSorter(8, UserControls.SortableListView.TagSorter<uint>())
                .SetSorter(9, UserControls.SortableListView.TagSorter<uint>());
        }

        public void ShowMatches(IEnumerable<MatchDetails> details, uint teamId)
        {
            try
            {
                sortableListViewMatches.Items.Clear();

                sortableListViewMatches.SuspendLayout();


                foreach (MatchDetails d in details.SafeEnum())
                {
                    ListViewItem item = new ListViewItem(d.Date.ToShortDateString());
                    item.Tag = d.Date;
                    item.SubItems[0].Tag = item.Tag;

                    object value = 0;

                    value = new HtTime(d.Date);
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, (value != null) ? value.ToString() : "-") { Tag = value });
                    
                    value = (teamId != d.HomeTeam.ID) ? d.HomeTeam : d.AwayTeam;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, (value != null) ? value.ToString() : "-") { Tag = value });
                    
                    value = d.Type;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = (teamId == d.HomeTeam.ID) ? "Home" : "Away"; // TODO neutral ground
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = (teamId == d.HomeTeam.ID) ? d.FinalScore.HomeGoals : d.FinalScore.AwayGoals;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = (teamId != d.HomeTeam.ID) ? d.FinalScore.HomeGoals : d.FinalScore.AwayGoals;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = (d.Visitors != null) ? d.Visitors.Total : null;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, (value != null) ? value.ToString() : "-") { Tag = value });

                    value = (teamId == d.HomeTeam.ID) ? ((HatStats)d.HomeRatings).Total : ((HatStats)d.AwayRatings).Total;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = (teamId != d.HomeTeam.ID) ? ((HatStats)d.HomeRatings).Total : ((HatStats)d.AwayRatings).Total;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    sortableListViewMatches.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sortableListViewMatches.ResumeLayout();
            }
        }
    }
}
