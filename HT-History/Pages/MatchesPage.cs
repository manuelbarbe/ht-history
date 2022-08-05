using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HtHistory.Data.Types;
using HtHistory.Toolbox;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;

namespace HtHistory.Pages
{
    public partial class MatchesPage : UserControl
    {
        public MatchesPage()
        {
            InitializeComponent();
            InitializeList();
        }

        private void InitializeList()
        {
            
            this.sortableListViewMatches.Columns.AddRange(new ColumnHeader[] {
                new ColumnHeader() { Name = "columnHeaderMatchDate", Text = "Date", TextAlign = HorizontalAlignment.Left, Width = 90 },
                new ColumnHeader() { Name = "columnHeaderMatchWeek", Text = "Week", TextAlign = HorizontalAlignment.Left, Width = 50 },
                new ColumnHeader() { Name = "columnHeaderMatchOpponent", Text = "Opponent", TextAlign = HorizontalAlignment.Left, Width = 220 },
                new ColumnHeader() { Name = "columnHeaderMatchType", Text = "Type", TextAlign = HorizontalAlignment.Left, Width = 150 },  
                new ColumnHeader() { Name = "columnHeaderMatchVenue", Text = "Venue", TextAlign = HorizontalAlignment.Left, Width = 50 },
                new ColumnHeader() { Name = "columnHeaderMatchGoals", Text = "Goals", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Name = "columnHeaderMatchOppGoals", Text = "OppGoals", TextAlign = HorizontalAlignment.Center, Width = 70 },
                new ColumnHeader() { Name = "columnHeaderMatchMinutes", Text = "Minutes", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Name = "columnHeaderMatchVisitors", Text = "Visitors", TextAlign = HorizontalAlignment.Right, Width = 50 },
                new ColumnHeader() { Name = "columnHeaderMatchHatstats", Text = "Hatstats", TextAlign = HorizontalAlignment.Center, Width = 60 },
                new ColumnHeader() { Name = "columnHeaderMatchDefense", Text = "Defense", TextAlign = HorizontalAlignment.Center, Width = 60 },
                new ColumnHeader() { Name = "columnHeaderMatchMidfield", Text = "Midfield", TextAlign = HorizontalAlignment.Center, Width = 60 },
                new ColumnHeader() { Name = "columnHeaderMatchAttack", Text = "Attack", TextAlign = HorizontalAlignment.Center, Width = 60 },
                new ColumnHeader() { Name = "columnHeaderMatchOppHatstats", Text = "OppHatstats", TextAlign = HorizontalAlignment.Center, Width = 70 },
                new ColumnHeader() { Name = "columnHeaderMatchOppDefense", Text = "OppDefense", TextAlign = HorizontalAlignment.Center, Width = 60 },
                new ColumnHeader() { Name = "columnHeaderMatchOppMidfield", Text = "OppMidfield", TextAlign = HorizontalAlignment.Center, Width = 60 },
                new ColumnHeader() { Name = "columnHeaderMatchOppAttack", Text = "OppAttack", TextAlign = HorizontalAlignment.Center, Width = 60 },
            });

            sortableListViewMatches
                .SetSorter(0, UserControls.SortableListView.TagSorter<DateTime>())
                .SetSorter(1, UserControls.SortableListView.NullSorter)
                .SetSorter(5, UserControls.SortableListView.TagSorter<uint>())
                .SetSorter(6, UserControls.SortableListView.TagSorter<uint>())
                .SetSorter(7, UserControls.SortableListView.TagSorter<uint>())
                .SetSorter(8, UserControls.SortableListView.TagSorter<uint>())
                .SetSorter(9, UserControls.SortableListView.TagSorter<uint>())
                .SetSorter(10, UserControls.SortableListView.TagSorter<uint>())
                .SetSorter(11, UserControls.SortableListView.TagSorter<uint>())
                .SetSorter(12, UserControls.SortableListView.TagSorter<uint>())
                .SetSorter(13, UserControls.SortableListView.TagSorter<uint>())
                .SetSorter(14, UserControls.SortableListView.TagSorter<uint>())
                .SetSorter(15, UserControls.SortableListView.TagSorter<uint>())
                .SetSorter(16, UserControls.SortableListView.TagSorter<uint>());
        }

        public void ShowMatches(IEnumerable<MatchDetails> details, int teamId)
        {
            FillList(details, teamId);
			FillChart(details, teamId);
        }
		
        private void FillChart(IEnumerable<MatchDetails> details, int teamId)
        {
#if !MONO
            chartHatstats.Series.Clear();

            chartHatstats.SuspendLayout();

            //Series hatStats = new Series("Hatstats");
            Series defStats = new Series("Defense") { ChartType = SeriesChartType.StackedColumn };
            Series midStats = new Series("Midfield") { ChartType = SeriesChartType.StackedColumn };
            Series attStats = new Series("Attack") { ChartType = SeriesChartType.StackedColumn };
            foreach (MatchDetails d in details.SafeEnum().OrderBy(d => d.Date))
            {
                string htts = new HtTime(d.Date).ToString();
                
                HatStats hs = (teamId == d.HomeTeam.ID) ? (HatStats)d.HomeRatings : (HatStats)d.AwayRatings;
                
                string tooltip = new StringBuilder()
                    .AppendLine(htts)
                    .AppendLine(d.ToString())
                    .AppendLine(d.Type.ToString())
                    .Append("Hatstats: ").AppendLine(hs.Total.ToString())
                    .Append("Defense:  ").AppendLine(hs.Defense.ToString())
                    .Append("Midfield: ").AppendLine(hs.Midfield.ToString())
                    .Append("Attack:   ").AppendLine(hs.Attack.ToString())
                    .ToString();

                DataPoint point = defStats.Points.Add(hs.Defense);
                point.ToolTip = tooltip;
                point.AxisLabel = htts;
                midStats.Points.Add(hs.Midfield).ToolTip = tooltip;
                attStats.Points.Add(hs.Attack).ToolTip = tooltip;
            }

            chartHatstats.Series.Add(defStats);
            chartHatstats.Series.Add(midStats);
            chartHatstats.Series.Add(attStats);

            chartHatstats.ResumeLayout();
#endif
        }

        private void FillList(IEnumerable<MatchDetails> details, int teamId)
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

                    value = d.Minutes;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = (d.Visitors != null) ? d.Visitors.Total : null;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, (value != null) ? value.ToString() : "-") { Tag = value });

                    value = (teamId == d.HomeTeam.ID) ? ((HatStats)d.HomeRatings).Total : ((HatStats)d.AwayRatings).Total;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = (teamId == d.HomeTeam.ID) ? ((HatStats)d.HomeRatings).Defense : ((HatStats)d.AwayRatings).Defense;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = (teamId == d.HomeTeam.ID) ? ((HatStats)d.HomeRatings).Midfield : ((HatStats)d.AwayRatings).Midfield;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = (teamId == d.HomeTeam.ID) ? ((HatStats)d.HomeRatings).Attack : ((HatStats)d.AwayRatings).Attack;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });


                    value = (teamId != d.HomeTeam.ID) ? ((HatStats)d.HomeRatings).Total : ((HatStats)d.AwayRatings).Total;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = (teamId != d.HomeTeam.ID) ? ((HatStats)d.HomeRatings).Defense : ((HatStats)d.AwayRatings).Defense;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = (teamId != d.HomeTeam.ID) ? ((HatStats)d.HomeRatings).Midfield : ((HatStats)d.AwayRatings).Midfield;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = (teamId != d.HomeTeam.ID) ? ((HatStats)d.HomeRatings).Attack : ((HatStats)d.AwayRatings).Attack;
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
