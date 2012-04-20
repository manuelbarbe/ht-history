using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HtHistory.Core.DataContainers;
using HtHistory.Core.DataBridges;
using HtHistory.Core.DataBridges.ChppBridges;
using HtHistory.Core.DataBridges.ChppBridges.ChppFileAccessors;
using System.Reflection;
using System.IO;
using HtHistory.Core.DataBridges.CacheBridges;
using HtHistory.Update;
using System.Threading;
using HtHistory.Statistics.Players;
using HtHistory.Core.ExtensionMethods;
using HtHistory.Settings;

using Columns = System.Collections.Generic.IEnumerable<HtHistory.Statistics.Players.IPlayerStatisticCalculator<System.Collections.Generic.IEnumerable<HtHistory.Statistics.Players.MatchAppearance>>>;
using HtHistory.Tasks;
using HtHistory.Pages;

namespace HtHistory
{
    public partial class Form1 : Form
    {
        private ComfortSettings _settings = new ComfortSettings();
        private static readonly string BaseDirectory;
        private static readonly string DataDirectory;
        private static readonly string SettingsFile;
        private static readonly string UpdateDirectory;

        PleaseWaitDialog _pwd = new PleaseWaitDialog();

        static Form1()
        {
            BaseDirectory = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData), "HT-History");
            DataDirectory = Path.Combine(BaseDirectory, "data");
            UpdateDirectory = Path.Combine(BaseDirectory, "update");
            SettingsFile = Path.Combine(BaseDirectory, "settings.xml");
        }

        public Form1()
        {
            InitializeComponent();
            Version v = Assembly.GetExecutingAssembly().GetName().Version;
            string version = String.Format("v{0}.{1}.{2}", v.Major, v.Minor, v.Build);
            this.Text = String.Format("HT-History by manuhell, {0}", version);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //if (File.Exists(SettingsFile))
                {
                    SaveDo(() =>
                    {
                        _settings.Load(SettingsFile);
                    });
                }

                SetOnlineMode();

                string team;
                _settings.TryGetValue("team", out team);
                if (!string.IsNullOrEmpty(team)) textBoxTeamId.Text = team;

                excludeForfaitsToolStripMenuItem.Checked = _settings.ExcludeForfaits;
                SetColumns(_settings.ActiveColumnSet, _settings.ExcludeForfaits);

                RefreshColumnSetComboBox();

                ThreadPool.QueueUserWorkItem(this.DoUpdateStartCallback);

                //UpdateTeam();
                //UpdateOpponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RefreshColumnSetComboBox()
        {
            comboBoxColumnSets.Items.Clear();
            foreach (var v in _settings.ColumnSets)
            {
                comboBoxColumnSets.Items.Add(v);
            }
            if (comboBoxColumnSets.Items.Count > 0)
            {
                comboBoxColumnSets.SelectedItem = _settings.ActiveColumnSet;
            }

            comboBoxColumnSets.Items.Add(new TaggedObject("<<create new>>", (Action)delegate() { CreateNewColumnSet(); }));
        }

        private void SetOnlineMode()
        {
            string token, tokenSecret, proxy;

            _settings.TryGetValue("accessToken", out token);
            _settings.TryGetValue("accessTokenSecret", out tokenSecret);

            if (token == null || tokenSecret == null)
            {
                using (AuthorizeDialog authDlg = new AuthorizeDialog())
                {
                    DialogResult res = authDlg.ShowDialog();
                    if (res != DialogResult.OK)
                    {
                        Application.Exit();
                    }
                    else
                    {
                        _settings["accessToken"] = token = authDlg.AccessToken;
                        _settings["accessTokenSecret"] = tokenSecret = authDlg.AccessTokenSecret;
                        _settings.Save(SettingsFile);
                    }
                }
            }

            _settings.TryGetValue("proxy", out proxy);

            IChppAccessor accessor = new ChppFilesystemAccessor(DataDirectory, new ChppOnlineAccessor(token, tokenSecret, proxy));
            DataBridgeFactory dbf = new DataBridgeFactory();
            dbf.MatchArchiveBridge = new ChppMatchArchiveBridge(accessor);
            dbf.MatchDetailsBridge = new CacheMatchDetailsBridge(new ChppMatchDetailsBridge(accessor));
            dbf.TeamDetailsBridge = new ChppTeamDetailsBridge(accessor);
            dbf.PlayersBridge = new ChppPlayersBridge(accessor);
            Environment.DataBridgeFactory = dbf;
        }

        private void SetOfflineMode()
        {
            IChppAccessor accessor = new ChppFilesystemAccessor(DataDirectory);
            DataBridgeFactory dbf = new DataBridgeFactory();
            dbf.MatchArchiveBridge = new ChppMatchArchiveBridge(accessor);
            dbf.MatchDetailsBridge = new CacheMatchDetailsBridge(new ChppMatchDetailsBridge(accessor));
            dbf.TeamDetailsBridge = new ChppTeamDetailsBridge(accessor);
            dbf.PlayersBridge = new ChppPlayersBridge(accessor);
            Environment.DataBridgeFactory = dbf;
        }

        private void clearCacheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDo(() =>
            {
                if (DialogResult.OK ==
                    MessageBox.Show("Do you really want to delete all cached data?", "Please confirm", MessageBoxButtons.OKCancel))
                {
                    // delete files from filesystem
                    //TODO: remove this hardcoded crap
                    Directory.Delete(DataDirectory, true);

                    // re-create bridges, this will delete memory caches
                    if (offlineModeToolStripMenuItem.Checked) SetOfflineMode();
                    else SetOnlineMode();
                }
            });
        }

        private void UpdateTeam()
        {
            SaveDo(() =>
            {
                Environment.Team = Environment.DataBridgeFactory.TeamDetailsBridge.GetTeamDetails(uint.Parse(textBoxTeamId.Text));
                labelTeamInfo.BeginInvoke((Action)delegate
                {
                    labelTeamInfo.Text = Environment.Team.ToString();
                });
            });
        }

        private void UpdateOpponent()
        {
            SaveDo(() =>
            {
                if (textBoxOppId.Text == string.Empty)
                {
                    Environment.Opponent = null;
                }
                else
                {
                    uint oppId = uint.Parse(textBoxOppId.Text);
                    if (oppId <= 0) Environment.Opponent = null;
                    else Environment.Opponent = Environment.DataBridgeFactory.TeamDetailsBridge.GetTeamDetails(oppId);
                }

                labelOpponentInfo.BeginInvoke((Action)delegate
                {
                    labelOpponentInfo.Text = Environment.Opponent != null ? Environment.Opponent.ToString() : "all teams";
                });
            });
        }

        private void textBoxTeamId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void textBoxTeamId_Leave(object sender, EventArgs e)
        {
            //UpdateTeam();
        }

        private void textBoxOppId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void textBoxOppId_Leave(object sender, EventArgs e)
        {
            //UpdateOpponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveDo(() =>
                {
                    _pwd.Show();

                    BackgroundWorker bgw = new BackgroundWorker();
                    
                    uint teamId = Convert.ToUInt32(textBoxTeamId.Text);

                    ITask getMatchesTask = new PleaseWaitTaskDecorator(
                                                new GetMatchesTask( teamId,
                                                                    Environment.DataBridgeFactory.TeamDetailsBridge,
                                                                    Environment.DataBridgeFactory.MatchArchiveBridge,
                                                                    Environment.DataBridgeFactory.MatchDetailsBridge));

                    ITask getPlayersTask = new PleaseWaitTaskDecorator(
                                                new GetPlayersTask( teamId,
                                                                    Environment.DataBridgeFactory.PlayersBridge));

                    bgw.DoWork += (s, e1) =>
                        {
                            UpdateTeam();
                            UpdateOpponent();
                            getMatchesTask.Do();
                            getPlayersTask.Do();
                        };

                    bgw.RunWorkerCompleted += (s, e2) =>
                        {
                            _pwd.Hide();
                            if (e2.Error != null)
                            {
                                MessageBox.Show(e2.Error.ToString());
                            }
                            else
                            {
                                SaveDo(() =>
                                {
                                    overviewPage1.ShowResult(this, new RunWorkerCompletedEventArgs(
                                                                    new OverviewPage.ResultData()
                                                                    {
                                                                        Matches = (IEnumerable<MatchDetails>)getMatchesTask.Result,
                                                                        CurrentPlayers = (IEnumerable<Player>)getPlayersTask.Result

                                                                    }, null, false));

                                    matchesPage1.ShowMatches((IEnumerable<MatchDetails>)getMatchesTask.Result, teamId);
                                });
                            }
                        };

                    bgw.RunWorkerAsync();
                });
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void offlineModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDo(() =>
            {
                if (offlineModeToolStripMenuItem.Checked)
                {
                    SetOnlineMode();
                    offlineModeToolStripMenuItem.Checked = false;
                }
                else
                {
                    SetOfflineMode();
                    offlineModeToolStripMenuItem.Checked = true;
                }
            });
        }

        private void proxyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDo(() =>
            {
                using (WebProxyDialog diag = new WebProxyDialog())
                {
                    string proxy;
                    _settings.TryGetValue("proxy", out proxy);
                    diag.WebProxyUri = proxy ?? string.Empty;

                    if (diag.ShowDialog() == DialogResult.OK)
                    {
                        _settings["proxy"] = diag.WebProxyUri;
                        _settings.Save(SettingsFile);

                        // update proxy
                        if (offlineModeToolStripMenuItem.Enabled == false) SetOnlineMode();
                    }
                }
            });
        }

        private void SaveDo(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _settings["team"] = textBoxTeamId.Text;
                _settings.Save(SettingsFile);
            }
            catch
            {
                ; // suppress all errors
            }
        }

        private void splashScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SplashScreen ss = new SplashScreen();
            ss.ShowDialog();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder()
                .AppendLine("What you should do:")
                .AppendLine()
                .AppendLine("- enter your team id")
                .AppendLine("- opt. enter an opponent team id (only matches against that team included)")
                .AppendLine("- opt. select columns by clicking Settings->Columns...")
                .AppendLine("- click refresh")
                .AppendLine("- be patient, HT-History is downloading data from hattrick now")
                .AppendLine("- browse your player list")
                .AppendLine("\t Tot: total")
                .AppendLine("\t Com: competitive (Lea + Cup + Qua + Oth)")
                .AppendLine("\t Lea: league")
                .AppendLine("\t Cup: cup")
                .AppendLine("\t Qua: qualifier")
                .AppendLine("\t Fri: friendly")
                .AppendLine("\t Oth: other match types")
                .AppendLine("\t Ma: matches")
                .AppendLine("\t Go: goals")
                .AppendLine("\t Min: minutes")
                .AppendLine("\t MotM: Man of the match")
                .AppendLine("\t Yellow: yellow cards")
                .AppendLine("\t Red: red cards")
                .AppendLine("\t Win: matches won")
                .AppendLine("\t Draw: matches drawn")
                .AppendLine("\t Lost: matches lost")
                .AppendLine("- sort by clicking column headers")
                .AppendLine("- select player and look at individual stats on the 3 tables at the bottom")
                .AppendLine("- opt. select multiple players, right click and choose 'copy to clipboard'")
                .AppendLine("- opt. select one player, right click and choose 'export to CSV'");

            MessageBox.Show(builder.ToString(), "Short help");

        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(this.DoUpdateClickCallback);
        }

        private void DoUpdateStartCallback(object threadContext)
        {
            IUpdater u = new UpdaterHttpFile(UpdateDirectory);

            Version v = null;

            try
            {
                v = u.GetAvailableUpdateVersion(Assembly.GetExecutingAssembly().GetName().Version);
            }
            catch { /* suppress */ }

            if (v != null)
            {
                if (DialogResult.Yes ==
                    MessageBox.Show(String.Format("An update version {0} is available. Do you want to update now?", v),
                                        "Confirm update",
                                        MessageBoxButtons.YesNo))
                {
                    SaveDo(() => u.ApplyUpdate());
                }
            }
        }

        private void DoUpdateClickCallback(object threadContext)
        {
            SaveDo(() =>
            {
                IUpdater u = new UpdaterHttpFile(UpdateDirectory);

                Version v = u.GetAvailableUpdateVersion(Assembly.GetExecutingAssembly().GetName().Version);
                if (v == null)
                {
                    MessageBox.Show("no update available");
                }
                else
                {
                    if (DialogResult.Yes ==
                        MessageBox.Show(String.Format("An update version {0} is available. Do you want to update now?", v),
                                            "Confirm update",
                                            MessageBoxButtons.YesNo))
                    {
                        u.ApplyUpdate();
                    }
                }
            });
        }

        private void columnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDo(() =>
                {
                    var shownRawColumns = _settings.ActiveColumnSet.Columns;
                    Dialogs.ChooseColumnsDialog ccd = new Dialogs.ChooseColumnsDialog(CalculatorFactory.GetAllCalulators().Except(shownRawColumns), shownRawColumns, _settings.ActiveColumnSet.Name);
                    if (ccd.ShowDialog() == DialogResult.OK)
                    {
                        IList<IPlayerStatisticCalculator<IEnumerable<MatchAppearance>>> myList = new List<IPlayerStatisticCalculator<IEnumerable<MatchAppearance>>>();
                        foreach (object o in ccd.Right.SafeEnum())
                        {
                            if (o is IPlayerStatisticCalculator<IEnumerable<MatchAppearance>>)
                            {
                                myList.Add((IPlayerStatisticCalculator<IEnumerable<MatchAppearance>>)o);
                            }
                        }

                        _settings.ActiveColumnSet.Name = ccd.MyName;
                        _settings.ActiveColumnSet.Columns = myList;
                        _settings.ColumnSets = _settings.ColumnSets; // TODO: force save another way
                        _settings.ActiveColumnSet = _settings.ActiveColumnSet; // TODO: force save another way

                        RefreshColumnSetComboBox();

                        SetColumns(_settings.ActiveColumnSet, _settings.ExcludeForfaits);
                    }
                });
        }

        private void CreateNewColumnSet()
        {
            SaveDo(() =>
                {
                    Dialogs.ChooseColumnsDialog ccd = new Dialogs.ChooseColumnsDialog(CalculatorFactory.GetAllCalulators(), null, String.Format("Custom set #{0}", comboBoxColumnSets.Items.Count + 1));
                    if (ccd.ShowDialog() == DialogResult.OK)
                    {
                        IList<IPlayerStatisticCalculator<IEnumerable<MatchAppearance>>> myList = new List<IPlayerStatisticCalculator<IEnumerable<MatchAppearance>>>();
                        foreach (object o in ccd.Right.SafeEnum())
                        {
                            if (o is IPlayerStatisticCalculator<IEnumerable<MatchAppearance>>)
                            {
                                myList.Add((IPlayerStatisticCalculator<IEnumerable<MatchAppearance>>)o);
                            }
                        }

                        ColumnSet set = new ColumnSet(ccd.MyName, myList);
                        _settings.ColumnSets.Add(set);
                        _settings.ActiveColumnSet = set;

                        RefreshColumnSetComboBox();

                        SetColumns(_settings.ActiveColumnSet, _settings.ExcludeForfaits);
                    }
                });
        }

        private void excludeForfaitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDo(() =>
                {
                    bool excluded = excludeForfaitsToolStripMenuItem.Checked = !excludeForfaitsToolStripMenuItem.Checked;
                    SetColumns(_settings.ActiveColumnSet, (_settings.ExcludeForfaits = excluded)); // TODO: remove this Load()
                });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            columnsToolStripMenuItem_Click(sender, e);
        }

        private void SetColumns(ColumnSet set, bool excludeForfeits)
        {
            if (excludeForfeits)
            {
                overviewPage1.Stats = set.Columns.Select(rc => new MatchFilterNoForfaits(rc)).ToArray();
            }
            else
            {
                overviewPage1.Stats = set.Columns;
            }
        }

        private void comboBoxColumnSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            ColumnSet cs = comboBoxColumnSets.SelectedItem as ColumnSet;
            if (cs != null)
            {
                SetColumns((_settings.ActiveColumnSet = cs), _settings.ExcludeForfaits);
                columnsToolStripMenuItem.Enabled = button2.Enabled = cs.Name != "Default";
            }

            TaggedObject to = comboBoxColumnSets.SelectedItem as TaggedObject;
            if (to != null)
            {
                Action a = to.Tag as Action;
                if (a != null) a();
            }
        }
    }
}
