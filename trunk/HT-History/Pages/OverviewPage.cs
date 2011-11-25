using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.DataContainers;
using HtHistory.Statistics;
using HtHistory.Statistics.Players;
using System.Windows.Forms;
using System.ComponentModel;
using HtHistory.Core;
using System.Drawing;
using HtHistory.Core.ExtensionMethods;
using HtHistory.Export;
using System.IO;
using System.Collections;
using HtHistory.UserControls;


namespace HtHistory.Pages
{
    public class OverviewPage : OverviewDetailsPage
    {

        private class ResultData
        {
            public IDictionary<Player, IList<MatchAppearance>> Infos { get; set; }
            public IEnumerable<Player> CurrentPlayers { get; set; }
            public IEnumerable<MatchDetails> Matches { get; set; }
        }

        public OverviewPage()
        {
            InitializeComponent();
        }

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToCSVToolStripMenuItem;

        private IList<IPlayerStatisticCalculator<IList<MatchAppearance>>> _stats = new List<IPlayerStatisticCalculator<IList<MatchAppearance>>>();

        private void InitializeComponent()
        {
            _stats.Add(new PlayerStatisticsCalculatorPlayerName());
            _stats.Add(new PlayerStatisticsCalculatorPlayerId());
            _stats.Add(new PlayerStatisticsCalculatorTotalMatches());
            _stats.Add(new PlayerStatisticsCalculatorTotalGoals());
            _stats.Add(new PlayerStatisticsCalculatorTotalMinutes());
            _stats.Add(new PlayerStatisticsCalculatorCompetitiveMatches());
            _stats.Add(new PlayerStatisticsCalculatorCompetitiveGoals());
            _stats.Add(new PlayerStatisticsCalculatorCompetitiveMinutes());
            _stats.Add(new PlayerStatisticsCalculatorLeagueMatches());
            _stats.Add(new PlayerStatisticsCalculatorLeagueGoals());
            _stats.Add(new PlayerStatisticsCalculatorLeagueMinutes());
            _stats.Add(new PlayerStatisticsCalculatorCupMatches());
            _stats.Add(new PlayerStatisticsCalculatorCupGoals());
            _stats.Add(new PlayerStatisticsCalculatorCupMinutes());
            _stats.Add(new PlayerStatisticsCalculatorQualifierMatches());
            _stats.Add(new PlayerStatisticsCalculatorQualifierGoals());
            _stats.Add(new PlayerStatisticsCalculatorQualifierMinutes());
            _stats.Add(new PlayerStatisticsCalculatorFriendlyMatches());
            _stats.Add(new PlayerStatisticsCalculatorFriendlyGoals());
            _stats.Add(new PlayerStatisticsCalculatorFriendlyMinutes());
            _stats.Add(new PlayerStatisticsCalculatorOtherMatches());
            _stats.Add(new PlayerStatisticsCalculatorOtherGoals());
            _stats.Add(new PlayerStatisticsCalculatorOtherMinutes());
            _stats.Add(new PlayerStatisticsCalculatorFirstMatch());
            _stats.Add(new PlayerStatisticsCalculatorLastMatch());

            InitializeContextMenu();
            InitializeTabs();
            InitializeOverviewList();
            InitializeDetailsLists();

            this.comboBoxFilter.SelectedIndexChanged += new System.EventHandler(this.comboBoxFilter_SelectedIndexChanged);
        }

        private void InitializeDetailsLists()
        {

            this.sortableListViewDetails1.Columns.AddRange(new ColumnHeader[] {
                new ColumnHeader() { Text = "Name", TextAlign = HorizontalAlignment.Left, Width = 225 },
                new ColumnHeader() { Text = "TotMa", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "TotGo", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "ComMa", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "ComGo", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "LeaMa", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "LeaGo", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "CupMa", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "CupGo", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "QuaMa", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "QuaGo", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "FriMa", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "FriGo", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "OthMa", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "OthGo", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "First", TextAlign = HorizontalAlignment.Left, Width = 80 },
                new ColumnHeader() { Text = "Last", TextAlign = HorizontalAlignment.Left, Width = 80 },
                new ColumnHeader() { Text = "TotMin", TextAlign = HorizontalAlignment.Center, Width = 55 },
                new ColumnHeader() { Text = "ComMin", TextAlign = HorizontalAlignment.Center, Width = 55 },
                new ColumnHeader() { Text = "LeaMin", TextAlign = HorizontalAlignment.Center, Width = 55 },
                new ColumnHeader() { Text = "CupMin", TextAlign = HorizontalAlignment.Center, Width = 55 },
                new ColumnHeader() { Text = "QuaMin", TextAlign = HorizontalAlignment.Center, Width = 55 },
                new ColumnHeader() { Text = "FriMin", TextAlign = HorizontalAlignment.Center, Width = 55 },
                new ColumnHeader() { Text = "OthMin", TextAlign = HorizontalAlignment.Center, Width = 55 }
            });

            sortableListViewDetails1
                .SetSorter(1, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(2, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(3, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(4, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(5, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(6, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(7, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(8, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(9, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(10, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(11, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(12, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(13, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(14, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(15, UserControls.SortableListView.TagSorter<DateTime>())
                .SetSorter(16, UserControls.SortableListView.TagSorter<DateTime>())
                .SetSorter(17, UserControls.SortableListView.TagSorter<long>())
                .SetSorter(18, UserControls.SortableListView.TagSorter<long>())
                .SetSorter(19, UserControls.SortableListView.TagSorter<long>())
                .SetSorter(20, UserControls.SortableListView.TagSorter<long>())
                .SetSorter(21, UserControls.SortableListView.TagSorter<long>())
                .SetSorter(22, UserControls.SortableListView.TagSorter<long>())
                .SetSorter(23, UserControls.SortableListView.TagSorter<long>());

            this.sortableListViewDetails2.Columns.AddRange(new ColumnHeader[] {
                new ColumnHeader() { Text = "Date", TextAlign = HorizontalAlignment.Left, Width = 80 },
                new ColumnHeader() { Text = "Week", TextAlign = HorizontalAlignment.Left, Width = 50 },
                new ColumnHeader() { Text = "Type", TextAlign = HorizontalAlignment.Left, Width = 150 },  
                new ColumnHeader() { Text = "Match", TextAlign = HorizontalAlignment.Left, Width = 220 },
                new ColumnHeader() { Text = "Position", TextAlign = HorizontalAlignment.Left, Width = 50 },
                new ColumnHeader() { Text = "Minutes", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "In", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "Out", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "RedCard", TextAlign = HorizontalAlignment.Center, Width = 50 },
            });

            sortableListViewDetails2
                .SetSorter(0, UserControls.SortableListView.TagSorter<DateTime>())
                .SetSorter(1, UserControls.SortableListView.NullSorter)
                .SetSorter(5, UserControls.SortableListView.TagSorter<uint>())
                .SetSorter(6, UserControls.SortableListView.TagSorter<uint>())
                .SetSorter(7, UserControls.SortableListView.TagSorter<uint>())
                .SetSorter(8, UserControls.SortableListView.TagSorter<uint>());

            this.sortableListViewDetails3.Columns.AddRange(new ColumnHeader[] {
                new ColumnHeader() { Text = "Date", TextAlign = HorizontalAlignment.Left, Width = 80 },
                new ColumnHeader() { Text = "Week", TextAlign = HorizontalAlignment.Left, Width = 50 },
                new ColumnHeader() { Text = "Type", TextAlign = HorizontalAlignment.Left, Width = 150 },  
                new ColumnHeader() { Text = "Match", TextAlign = HorizontalAlignment.Left, Width = 220 },
                new ColumnHeader() { Text = "Scored", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "Minute", TextAlign = HorizontalAlignment.Center, Width = 50 }});

            sortableListViewDetails3
                .SetSorter(0, UserControls.SortableListView.TagSorter<DateTime>())
                .SetSorter(1, UserControls.SortableListView.NullSorter)
                .SetSorter(5, UserControls.SortableListView.TagSorter<uint>());
        }

        private void InitializeOverviewList()
        {
            sortableListViewOverview.Columns.Clear();

            foreach (var s in _stats)
            {
                var ch = new ColumnHeader() { Text = s.Abbreviation, TextAlign = HorizontalAlignment.Left, Width = 60, Tag = s };
                sortableListViewOverview.Columns.Add(ch);
                sortableListViewOverview.SetSorter(ch.Index, SortableListView.TagSorter(s.GetComparer()));
            }

/*
            this.sortableListViewOverview.Columns.AddRange(new ColumnHeader[] {
                new ColumnHeader() { Text = "Name", TextAlign = HorizontalAlignment.Left, Width = 225 },
                new ColumnHeader() { Text = "TotMa", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "TotGo", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "ComMa", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "ComGo", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "LeaMa", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "LeaGo", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "CupMa", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "CupGo", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "QuaMa", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "QuaGo", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "FriMa", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "FriGo", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "OthMa", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "OthGo", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "First", TextAlign = HorizontalAlignment.Left, Width = 80 },
                new ColumnHeader() { Text = "Last", TextAlign = HorizontalAlignment.Left, Width = 80 },
                new ColumnHeader() { Text = "TotMin", TextAlign = HorizontalAlignment.Center, Width = 55 },
                new ColumnHeader() { Text = "ComMin", TextAlign = HorizontalAlignment.Center, Width = 55 },
                new ColumnHeader() { Text = "LeaMin", TextAlign = HorizontalAlignment.Center, Width = 55 },
                new ColumnHeader() { Text = "CupMin", TextAlign = HorizontalAlignment.Center, Width = 55 },
                new ColumnHeader() { Text = "QuaMin", TextAlign = HorizontalAlignment.Center, Width = 55 },
                new ColumnHeader() { Text = "FriMin", TextAlign = HorizontalAlignment.Center, Width = 55 },
                new ColumnHeader() { Text = "OthMin", TextAlign = HorizontalAlignment.Center, Width = 55 } 
            });

            sortableListViewOverview
                .SetSorter(1, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(2, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(3, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(4, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(5, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(6, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(7, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(8, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(9, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(10, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(11, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(12, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(13, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(14, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(15, UserControls.SortableListView.TagSorter<DateTime>())
                .SetSorter(16, UserControls.SortableListView.TagSorter<DateTime>())
                .SetSorter(17, UserControls.SortableListView.TagSorter<long>())
                .SetSorter(18, UserControls.SortableListView.TagSorter<long>())
                .SetSorter(19, UserControls.SortableListView.TagSorter<long>())
                .SetSorter(20, UserControls.SortableListView.TagSorter<long>())
                .SetSorter(21, UserControls.SortableListView.TagSorter<long>())
                .SetSorter(22, UserControls.SortableListView.TagSorter<long>())
                .SetSorter(23, UserControls.SortableListView.TagSorter<long>());
            */

            this.sortableListViewOverview.SelectedIndexChanged += OverviewSelectedIndexChanged;
            this.sortableListViewOverview.ContextMenuStrip = contextMenuStrip1;
        }

        private void InitializeTabs()
        {
            tabPage1.Text = "Seasons";
            tabPage2.Text = "Matches";
            tabPage3.Text = "Goals";
        }

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
        }

        public void OverviewSelectedIndexChanged(object sender, EventArgs e)
        {
            FillDetailsSeason();
            FillDetailsMatches();
            FillDetailsGoals();
        }

        private void FillDetailsGoals()
        {
            /*
            try
            {
                sortableListViewDetails3.Items.Clear();

                sortableListViewDetails3.SuspendLayout();

                if (sortableListViewOverview.SelectedItems.Count == 0) return;

                PlayerData sitem = sortableListViewOverview.SelectedItems[0].Tag as PlayerData;

                if (sitem == null) return;

                foreach (var v in sitem.TotalItems.SafeEnum())
                {
                    foreach (Goal g in v.Goals.SafeEnum())
                    {
                        ListViewItem item = new ListViewItem(g.Match.Date.ToShortDateString());
                        item.Tag = g.Match.Date;
                        item.SubItems[0].Tag = item.Tag;

                        object value = 0;

                        value = new HtTime(g.Match.Date);
                        item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                        value = g.Match.Type;
                        item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                        value = g.Match;
                        item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                        value = g.Score;
                        item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                        value = g.Minute;
                        item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                        sortableListViewDetails3.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sortableListViewDetails3.ResumeLayout();
            }
             * */
        }

        private void FillDetailsMatches()
        {
            /*
            try
            {
                sortableListViewDetails2.Items.Clear();

                sortableListViewDetails2.SuspendLayout();

                if (sortableListViewOverview.SelectedItems.Count == 0) return;

                PlayerData sitem = sortableListViewOverview.SelectedItems[0].Tag as PlayerData;

                if (sitem == null) return;

                foreach (MatchAppearance d in sitem.TotalItems)
                {
                    ListViewItem item = new ListViewItem(d.Match.Date.ToShortDateString());
                    item.Tag = d.Match.Date;
                    item.SubItems[0].Tag = item.Tag;

                    object value = 0;

                    value = new HtTime(d.Match.Date);
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = d.Match.Type;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = d.Match;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = d.Role;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = d.Minutes;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = d.SubstituteIn;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, (value != null) ? value.ToString() : "-" ) { Tag = value });

                    value = d.SubstituteOut;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, (value != null) ? value.ToString() : "-") { Tag = value });

                    value = d.RedCarded;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, (value != null) ? value.ToString() : "-") { Tag = value });

                    sortableListViewDetails2.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sortableListViewDetails2.ResumeLayout();
            }
             * */
        }

        private void FillDetailsSeason()
        {
            /*
            try
            {
                sortableListViewDetails1.Items.Clear();

                if (sortableListViewOverview.SelectedItems.Count == 0) return;

                PlayerData sitem = sortableListViewOverview.SelectedItems[0].Tag as PlayerData;

                if (sitem == null) return;

                IDictionary<int, PlayerData> appearancesBySeason = new Dictionary<int, PlayerData>(); ;

                foreach (MatchAppearance d in sitem.TotalItems)
                {
                    int season = new HtTime(d.Match.Date).Season;

                    if (!appearancesBySeason.ContainsKey(season))
                    {
                        appearancesBySeason.Add(season, new PlayerStatisticItem<MatchAppearance>(d.Player));
                    }

                    appearancesBySeason[season].Add(d, d.Match.Date, d.Match.Type);
                }


                foreach (var v in appearancesBySeason)
                {
                    var m = v.Value;

                    ListViewItem item = new ListViewItem(string.Format("Season {0,02}", v.Key));
                    item.Tag = m;
                    item.SubItems[0].Tag = item.Tag;

                    object value = 0;

                    value = m.TotalItems.Count;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });
                    value = m.TotalItems.Sum(ma => ma.Goals.Count);
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    // competitive items
                    value = m.LeagueItems.Count + m.CupItems.Count + m.QualifierItems.Count;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });
                    value = m.LeagueItems.Sum(ma => ma.Goals.Count) + m.CupItems.Sum(ma => ma.Goals.Count) + m.QualifierItems.Sum(ma => ma.Goals.Count);
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = m.LeagueItems.Count;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });
                    value = m.LeagueItems.Sum(ma => ma.Goals.Count);
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = m.CupItems.Count;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });
                    value = m.CupItems.Sum(ma => ma.Goals.Count);
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = m.QualifierItems.Count;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });
                    value = m.QualifierItems.Sum(ma => ma.Goals.Count);
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = m.FriendlyItems.Count;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });
                    value = m.FriendlyItems.Sum(ma => ma.Goals.Count);
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = m.OtherItems.Count;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });
                    value = m.OtherItems.Sum(ma => ma.Goals.Count);
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = m.First;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, ((DateTime)value).ToShortDateString()) { Tag = value });

                    value = m.Last;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, ((DateTime)value).ToShortDateString()) { Tag = value });

                    value = m.TotalItems.Sum(ma => ma.Minutes);
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });
                    value = m.LeagueItems.Sum(ma => ma.Minutes) + m.CupItems.Sum(ma => ma.Minutes) + m.QualifierItems.Sum(ma => ma.Minutes);
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });
                    value = m.LeagueItems.Sum(ma => ma.Minutes);
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });
                    value = m.CupItems.Sum(ma => ma.Minutes);
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });
                    value = m.QualifierItems.Sum(ma => ma.Minutes);
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });
                    value = m.FriendlyItems.Sum(ma => ma.Minutes);
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });
                    value = m.OtherItems.Sum(ma => ma.Minutes);
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    sortableListViewDetails1.Items.Add(item);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
             * */
        }

        IDictionary<Player, IList<MatchAppearance>> GetForMatches(IEnumerable<MatchDetails> matches)
        {
            StandardPlayerStatistics ts = new StandardPlayerStatistics(matches);
            return ts.GetMatchesOfPlayers(Environment.Team == null ? 0 : Environment.Team.ID, true);
        }

        protected override void DoWork(object sender, DoWorkEventArgs e)
        {
            IEnumerable<MatchDetails> matches = new MatchGetter(
                                Environment.Team == null ? 0 : Environment.Team.ID,
                                Environment.Opponent == null ? 0 : Environment.Opponent.ID,
                                Environment.DataBridgeFactory.TeamDetailsBridge,
                                Environment.DataBridgeFactory.MatchArchiveBridge,
                                Environment.DataBridgeFactory.MatchDetailsBridge);
       
            IEnumerable<Player> currentPlayers = new List<Player>();
            try
            {
                currentPlayers = Environment.DataBridgeFactory.PlayersBridge.GetPlayers(Environment.Team.ID);
            }
            catch (Exception ex)
            {
                HtLog.Warn("Cannot get current players ({0})", ex.ToString());
            }

            e.Result = new ResultData()
            {
                Infos = GetForMatches(matches),
                CurrentPlayers = currentPlayers,
                Matches = matches 
            };
        }

        protected override void ShowResult(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.ToString());
                return;
            }

            sortableListViewDetails1.Items.Clear();
            sortableListViewDetails2.Items.Clear();
            sortableListViewDetails3.Items.Clear();

            comboBoxFilter.Items.Clear();
          
            ResultData data = (ResultData)e.Result;

            comboBoxFilter.Items.Add(new TaggedObject("all seasons"));
            foreach (int season in data.Matches.Select(m => new HtTime(m.Date).Season).Distinct().OrderBy( i => i))
            {
                comboBoxFilter.Items.Add(new TaggedObject(String.Format("Season {0}", season), season));
            }

            ListView listView = sortableListViewOverview;
            FillListView(data, listView);  
        }

        private void FillListView(ResultData data, ListView listView)
        {
            listView.Tag = data;
            listView.Items.Clear();

            foreach (var pmd in data.Infos)
            {
                Player player = pmd.Key;
                if (player == null) continue;

                ListViewItem item = new ListViewItem("manuhell") { Tag = player };

                // highlight current players
                if (data.CurrentPlayers.FirstOrDefault(p => (p.ID == player.ID)) != null)
                {
                    item.Font = new Font(item.Font, FontStyle.Bold);
                }

                // team dummy player
                if (player.ID == 0)
                {
                    item.BackColor = Color.Gray;
                }

                bool firstCol = true;
                foreach (ColumnHeader ch in listView.Columns)
                {
                    IPlayerStatisticCalculator<IList<MatchAppearance>> psc = ch.Tag as IPlayerStatisticCalculator<IList<MatchAppearance>>;
                    object value = (psc == null) ? "(invalid)" : psc.Calculate(pmd.Value);

                    if (firstCol)
                    {
                        item.Text = value.ToString();
                        item.SubItems[0].Tag = value;
                        firstCol = false;
                    }
                    else
                    {
                        item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });
                    }
                }

                listView.Items.Add(item);
            }
        }

        private void copyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Table table = TableFromListView(sortableListViewOverview);

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
                    Table table = TableFromListView(sortableListViewOverview);
                    using (Stream stream = File.OpenWrite(safeFileDialog.FileName))
                    {
                        using (StreamWriter wr = new StreamWriter(stream, Encoding.ASCII))
                        {
                            new TableExporterCSV(",").Export(table, wr);
                        }
                    }
                }
            });
        }

        private Table TableFromListView(ListView view)
        {
            Table table = new Table();
            IEnumerable<ColumnHeader> headers = view.Columns.Cast<ColumnHeader>();
            table.ColumHeaders = headers.Select((ch) => ch.Text).ToArray();

            ICollection items = (view.SelectedItems.Count > 1) ? (ICollection)view.SelectedItems : view.Items;

            table.Data =
            items.Cast<ListViewItem>().Select(
                (lvi) => lvi.SubItems.Cast<ListViewItem.ListViewSubItem>().Select(
                    (lvsi) => lvsi.Text).ToArray()).ToArray();

            return table;
        }

        private void comboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxFilter.SelectedItem == null) return;

            ResultData data = sortableListViewOverview.Tag as ResultData;
            TaggedObject to = comboBoxFilter.SelectedItem as TaggedObject;

            if (data != null && to != null)
            {
                sortableListViewDetails1.Items.Clear();
                sortableListViewDetails2.Items.Clear();
                sortableListViewDetails3.Items.Clear();

                IEnumerable<MatchDetails> md = to.Tag == null ? data.Matches : data.Matches.Where(m => new HtTime(m.Date).Season == (int)to.Tag);

                IDictionary<Player, IList<MatchAppearance>> listData = GetForMatches(md);
                ListView listView = sortableListViewOverview;

                FillListView(new ResultData() { Infos = listData, CurrentPlayers = data.CurrentPlayers, Matches = data.Matches }, listView);
            }
        }
   }
}
