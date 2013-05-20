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
using HtHistory.Core;
using HtHistory.Dialogs;
using HtHistory.Core.DataBridges.ProxyBridges;
using HtHistory.Core.DataBridges.DatabaseBridges;
using HtHistory.Translation;
using HtHistory.UserControls;

namespace HtHistory
{
    public partial class Form1 : Form
    {
        private ITranslator _translator;

        private ComfortSettings _settings = new ComfortSettings();
        private static readonly string BaseDirectory;
        private static readonly string DataDirectory;
        private static readonly string SettingsFile;
        private static readonly string UpdateDirectory;

        private uint _teamId = 0;
        IEnumerable<MatchDetails> _matches = new List<MatchDetails>();
        IEnumerable<Player> _players = new List<Player>();
        TransferHistory _transfers = null;

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
            string version = GetVersionString();
            this.Text = String.Format("HT-History by manuhell, {0}", version);
        }

        private static string GetVersionString()
        {
            Version v = Assembly.GetExecutingAssembly().GetName().Version;
            string version = String.Format("v{0}.{1}.{2}", v.Major, v.Minor, v.Build);
            return version;
        }

        public void OnLanguageChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null)
            {
                ITranslator t = item.Tag as ITranslator;
                if (t != null)
                {
                    _translator = t;
                    _settings["language"] = t.ToString();
                    _settings.Save(SettingsFile);
                    this.Translate(t);
                    //this.menuStrip.Translate(t);
                }
            }
        }

        private void SetTranslator()
        {
            _translator = GetTranslatorFromSettings();

            if (_translator == null)
            {
                _translator = GetTranslatorFromDialog() ?? TranslatorFactory.GetDefaultTranslator();
                _settings["language"] = _translator.ToString();
                _settings.Save(SettingsFile);
            }
        }

        private ITranslator GetTranslatorFromSettings()
        {
            ITranslator t = null;
            string strTranslator;
            if (_settings.TryGetValue("language", out strTranslator))
            {
                t = TranslatorFactory.FindTranslator(strTranslator); // null if not found
            }
            return t;
        }

        private static ITranslator GetTranslatorFromDialog()
        {
            ITranslator t2 = null;
            ChooseItemBox chooseLanguageBox = new ChooseItemBox(TranslatorFactory.Translators.Select(t3 => new TaggedObject(t3.ToString(), t3)));
            if (chooseLanguageBox.ShowDialog() == DialogResult.OK)
            {
                TaggedObject to = chooseLanguageBox.Item as TaggedObject;
                if (to != null)
                {
                    t2 = to.Tag as ITranslator;
                }
            }
            return t2;
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

                SetTranslator();
                this.Translate(_translator);
                //menuStrip.Translate(_translator);

                languageToolStripMenuItem.DropDownItems.Clear();
                foreach (ITranslator translator in Translation.TranslatorFactory.Translators.SafeEnum())
                {
                    ToolStripMenuItem item = new ToolStripMenuItem(translator.ToString(), null, OnLanguageChanged);
                    item.Tag = translator;
                    item.Name = "noTr_" + Guid.NewGuid().ToString();
                    languageToolStripMenuItem.DropDownItems.Add(item);
                }

                SetOnlineMode();

                SetColumns(_settings.ActiveColumnSet);

                RefreshColumnSetComboBox();

                ThreadPool.QueueUserWorkItem(this.DoUpdateStartCallback);


                try
                {
                    string team;
                    _settings.TryGetValue("team", out team);
                    if (!string.IsNullOrEmpty(team)) _teamId = uint.Parse(team);
                }
                catch
                {
                    HtLog.Error("Cannot parse team id");
                }
                ChangeTeam(ref _teamId);
				
                matchFilterControl.FilterChanged += UpdateAll;


                
                string lastVersion;
                if (!_settings.TryGetValue("lastVersion", out lastVersion) || lastVersion != GetVersionString())
                {
                    ShowWhatsNewBox();
                    _settings["lastVersion"] = GetVersionString();
                }

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
                    authDlg.Translate(_translator);
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
            dbf.MatchDetailsBridge =    new BridgeChain<MatchDetails>(
                                            new CacheBridge<MatchDetails>(),
                                            //new BridgeChain<MatchDetails>(
                                                //new DatabaseMatchDetailsBridge(),
                                                new ChppMatchDetailsBridge(accessor));
            dbf.TeamDetailsBridge = new ChppTeamDetailsBridge(accessor);
            dbf.PlayersBridge = new ChppPlayersBridge(accessor);
            dbf.TransfersBridge = new ChppTransferHistoryBridge(accessor);
            Environment.DataBridgeFactory = dbf;
        }

        private void SetOfflineMode()
        {
            IChppAccessor accessor = new ChppFilesystemAccessor(DataDirectory);
            DataBridgeFactory dbf = new DataBridgeFactory();
            dbf.MatchArchiveBridge = new ChppMatchArchiveBridge(accessor);
            dbf.MatchDetailsBridge = new BridgeChain<MatchDetails>(
                                            new CacheBridge<MatchDetails>(),
                                            //new BridgeChain<MatchDetails>(
                                                //new DatabaseMatchDetailsBridge(),
                                                new ChppMatchDetailsBridge(accessor));
			dbf.TeamDetailsBridge = new ChppTeamDetailsBridge(accessor);
            dbf.PlayersBridge = new ChppPlayersBridge(accessor);
            dbf.TransfersBridge = new ChppTransferHistoryBridge(accessor);
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
                    diag.Translate(_translator);
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
                _settings["team"] = _teamId.ToString();
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
            SaveDo(() =>
            {
                System.Diagnostics.Process.Start("http://code.google.com/p/ht-history/wiki/Main");
            });
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

        private TaggedObject CalculatorToTaggedObject(IPlayerStatisticCalculator<IEnumerable<MatchAppearance>> calculator)
        {
            string first = _translator.Translate("playerStatLong_" + calculator.Identifier);
            string second = _translator.Translate("playerStatShort_" + calculator.Identifier);
            return new TaggedObject(string.Format("{0} ({1})", first, second), calculator);
        }

        private void columnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDo(() =>
                {
                    var shownRawColumns = _settings.ActiveColumnSet.Columns;
                    Dialogs.ChooseColumnsDialog ccd =
                        new Dialogs.ChooseColumnsDialog(
                            CalculatorFactory.GetAllCalulators().Except(shownRawColumns).Select( calc => CalculatorToTaggedObject(calc) ),
                            shownRawColumns.Select(calc => CalculatorToTaggedObject(calc)),
                            _settings.ActiveColumnSet.Name);
                    ccd.Translate(_translator);
                    if (ccd.ShowDialog() == DialogResult.OK)
                    {
                        IList<IPlayerStatisticCalculator<IEnumerable<MatchAppearance>>> myList = GetCalculatorsListFromDialog(ccd);
                        _settings.ActiveColumnSet.Name = ccd.MyName;
                        _settings.ActiveColumnSet.Columns = myList;
                        _settings.ColumnSets = _settings.ColumnSets; // TODO: force save another way
                        _settings.ActiveColumnSet = _settings.ActiveColumnSet; // TODO: force save another way

                        RefreshColumnSetComboBox();

                        SetColumns(_settings.ActiveColumnSet);
                    }
                });
        }

        private void CreateNewColumnSet()
        {
            SaveDo(() =>
                {
                    Dialogs.ChooseColumnsDialog ccd = new Dialogs.ChooseColumnsDialog(
                        CalculatorFactory.GetAllCalulators().Select ( calc => CalculatorToTaggedObject(calc) ),
                        null,
                        String.Format("Custom set #{0}", comboBoxColumnSets.Items.Count + 1));
                    ccd.Translate(_translator);
                    if (ccd.ShowDialog() == DialogResult.OK)
                    {
                        IList<IPlayerStatisticCalculator<IEnumerable<MatchAppearance>>> myList = GetCalculatorsListFromDialog(ccd);

                        ColumnSet set = new ColumnSet(ccd.MyName, myList);
                        _settings.ColumnSets.Add(set);
                        _settings.ActiveColumnSet = set;

                        RefreshColumnSetComboBox();

                        SetColumns(_settings.ActiveColumnSet);
                    }
                });
        }

        private static IList<IPlayerStatisticCalculator<IEnumerable<MatchAppearance>>> GetCalculatorsListFromDialog(Dialogs.ChooseColumnsDialog ccd)
        {
            IList<IPlayerStatisticCalculator<IEnumerable<MatchAppearance>>> myList = new List<IPlayerStatisticCalculator<IEnumerable<MatchAppearance>>>();
            foreach (object o in ccd.Right.SafeEnum())
            {
                TaggedObject to = o as TaggedObject;
                if (to != null)
                {
                    IPlayerStatisticCalculator<IEnumerable<MatchAppearance>> c = to.Tag as IPlayerStatisticCalculator<IEnumerable<MatchAppearance>>;
                    if (c != null)
                    {
                        myList.Add(c);
                    }
                }
            }
            return myList;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            columnsToolStripMenuItem_Click(sender, e);
        }

        private void SetColumns(ColumnSet set)
        {
            overviewPage1.Stats = set.Columns;
            overviewPage1.Translate(_translator);
        }

        private void comboBoxColumnSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            ColumnSet cs = comboBoxColumnSets.SelectedItem as ColumnSet;
            if (cs != null)
            {
                SetColumns((_settings.ActiveColumnSet = cs));
                columnsToolStripMenuItem.Enabled = buttonColumns.Enabled = cs.Name != "Default";
            }

            TaggedObject to = comboBoxColumnSets.SelectedItem as TaggedObject;
            if (to != null)
            {
                Action a = to.Tag as Action;
                if (a != null) a();
            }
        }

        private void UpdateAll(object sender, EventArgs e)
        {
            IEnumerable<MatchDetails> matches = matchFilterControl.GetFilter().Filter(_matches);

            overviewPage1.ShowResult(this, new RunWorkerCompletedEventArgs(
                                                                   new OverviewPage.ResultData()
                                                                   {
                                                                       TeamId = _teamId,
                                                                       Matches = matches,
                                                                       CurrentPlayers = _players,

                                                                   }, null, false));

            matchesPage1.ShowMatches(matches, _teamId);

            transfersPage1.ShowTransfers(_transfers);
        }

        private void UpdateTeam(ref uint teamId, DateTime? startDate, DateTime? endDate)
        {
            //ugly hack ahead
            if (startDate == null || endDate == null)
            { // get data from CHPP
                TeamDetails td = Environment.DataBridgeFactory.TeamDetailsBridge.GetTeamDetails(teamId);
                matchFilterControl.Prepare(td.ID, td.Owner.JoinDate.Value, DateTime.Now.ToHtTime(), _translator);
                teamId = td.ID;
            }
            else
            { // use date specified by user input
                matchFilterControl.Prepare(teamId, startDate.Value, endDate.Value, _translator);
            }
        }

        private void UpdateMatches(uint teamId, DateTime? startDate, DateTime? endDate)
        {
            //_pwd.Show();

            BackgroundWorker bgw = new BackgroundWorker();

            ITask getMatchesTask;

            if (startDate != null && endDate != null)
            {
                getMatchesTask = new PleaseWaitTaskDecorator(
                                        new GetMatchesTask(teamId,
                                                            startDate,
                                                            endDate,
                                                            Environment.DataBridgeFactory.MatchArchiveBridge,
                                                            Environment.DataBridgeFactory.MatchDetailsBridge));
            }
            else
            {
                getMatchesTask = new PleaseWaitTaskDecorator(
                                        new GetMatchesTask(teamId,
                                                            Environment.DataBridgeFactory.TeamDetailsBridge,
                                                            Environment.DataBridgeFactory.MatchArchiveBridge,
                                                            Environment.DataBridgeFactory.MatchDetailsBridge));
            }

            ITask getPlayersTask = new PleaseWaitTaskDecorator(
                                        new GetPlayersTask(teamId,
                                                            Environment.DataBridgeFactory.PlayersBridge));

            ITask getTransfersTask = new PleaseWaitTaskDecorator(
                                        new GetTransfersTask(teamId,
                                                              Environment.DataBridgeFactory.TransfersBridge));

            bgw.DoWork += (s, e1) =>
            {
                getMatchesTask.Do();
                getPlayersTask.Do();
                getTransfersTask.Do();
            };

            bgw.RunWorkerCompleted += (s, e2) =>
            {
                //_pwd.Hide();
                if (e2.Error != null)
                {
                    MessageBox.Show(e2.Error.ToString());
                }
                else
                {
                    SaveDo(() =>
                    {
                        _matches = (IEnumerable<MatchDetails>)getMatchesTask.Result;
                        _players = (IEnumerable<Player>)getPlayersTask.Result;
                        _transfers = (TransferHistory)getTransfersTask.Result;
                        UpdateAll(this, new EventArgs());
                    });
                }
            };

            bgw.RunWorkerAsync();
        }

        private void ChangeTeam(ref uint teamId)
        {
            TeamIdDialog tid = new TeamIdDialog(teamId);
            tid.Translate(_translator, true);
            if (DialogResult.OK == tid.ShowDialog())
            {
                teamId = tid.TeamId;
                UpdateTeam(ref teamId, tid.StartDate, tid.EndDate);
                UpdateMatches(teamId, tid.StartDate, tid.EndDate);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveDo(() =>
            {
                ChangeTeam(ref _teamId); // TODO: error handling
            });
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox box = new AboutBox();
            box.Translate(_translator);
            box.ShowDialog();
        }

        private void toolStripMenuItemWhatsNew_Click(object sender, EventArgs e)
        {
            ShowWhatsNewBox();
        }

        private void ShowWhatsNewBox()
        {
            WhatsNewBox box = new WhatsNewBox();
            box.Translate(_translator);
            box.ShowDialog();
        }
    }
}
