﻿using System;
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

namespace HtHistory
{
    public partial class Form1 : Form
    {
        private Settings _settings = new Settings();
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
                if (File.Exists(SettingsFile))
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

                overviewPage1.Stats = LoadColumns();

                ThreadPool.QueueUserWorkItem(this.DoUpdateStartCallback);

                //UpdateTeam();
                //UpdateOpponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
                    bgw.DoWork += (s, e1) => { UpdateTeam(); UpdateOpponent(); };
                    bgw.RunWorkerCompleted += (s, e2) =>
                        {
                            _pwd.Hide();
                            if (e2.Error != null)
                            {
                                MessageBox.Show(e2.Error.ToString());
                            }
                            else
                            {
                                if (overviewPage1.Visible)
                                    overviewPage1.StartWorking();
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

        private IEnumerable<IPlayerStatisticCalculator<IEnumerable<MatchAppearance>>> LoadColumns()
        {   
            string columnString;
            if (_settings.ContainsKey("columns"))
            {
                columnString = _settings["columns"];
            }
            else
            {
                columnString = "Name;TotMat;TotGoa;TotWin;TotDraw;TotLost;TotMotM;TotRed;ComMat;ComGoa;LeaMat;LeaGoa;CupMat;CupGoa;QuaMat;QuaGoa;FriMat;FriGoa;TotFirst;TotLast";
            }

            foreach (string column in columnString.Split(';'))
            {
                foreach (var v in CalculatorFactory.GetAllCalulators())
                {
                    if (column == v.Identifier)
                    {
                        yield return v;
                    }
                }
            }
        }

        private void SaveColumns(IEnumerable<IPlayerStatisticCalculator<IEnumerable<MatchAppearance>>> columns)
        {
            StringBuilder b = new StringBuilder();

            foreach (var v in columns)
            {
                b.Append(v.Identifier).Append(";");
            }

            _settings["columns"] = b.ToString();
        }

        private void columnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dialogs.ChooseColumnsDialog ccd = new Dialogs.ChooseColumnsDialog(CalculatorFactory.GetAllCalulators().Except(overviewPage1.Stats), overviewPage1.Stats);
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
                
                overviewPage1.Stats = myList;
                SaveColumns(myList);
            }
        }
    }
}