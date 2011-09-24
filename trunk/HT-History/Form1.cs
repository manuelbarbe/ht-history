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

namespace HtHistory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = String.Format("HT-History by manuhell, v{0}", Assembly.GetExecutingAssembly().GetName().Version);   
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                SetOnlineMode();
                UpdateTeam();
                UpdateOpponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void SetOnlineMode()
        {
            string token = null, tokenSecret = null;

            string fullAuthDirectoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "auth");
            string filepath = Path.Combine(fullAuthDirectoryPath, "accesstoken");

            if (File.Exists(filepath))
            {
                using (Stream file = File.OpenRead(filepath))
                {
                    TextReader r = new StreamReader(file, Encoding.UTF8);
                    token = r.ReadLine();
                    tokenSecret = r.ReadLine();
                }
            }
            else
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
                        token = authDlg.AccessToken;
                        tokenSecret = authDlg.AccessTokenSecret;
                        if (!Directory.Exists(fullAuthDirectoryPath))
                        {
                            Directory.CreateDirectory(fullAuthDirectoryPath);
                        }
                        File.WriteAllLines(filepath, new[] { token, tokenSecret }, Encoding.UTF8);
                    }
                }
            }

            IChppAccessor accessor = new ChppFilesystemAccessor(new ChppOnlineAccessor(token, tokenSecret));
            DataBridgeFactory dbf = new DataBridgeFactory();
            dbf.MatchArchiveBridge = new ChppMatchArchiveBridge(accessor);
            dbf.MatchDetailsBridge = new CacheMatchDetailsBridge(new ChppMatchDetailsBridge(accessor));
            dbf.TeamDetailsBridge = new ChppTeamDetailsBridge(accessor);
            dbf.PlayersBridge = new ChppPlayersBridge(accessor);
            Environment.DataBridgeFactory = dbf;
        }

        private void SetOfflineMode()
        {
            IChppAccessor accessor = new ChppFilesystemAccessor();
            DataBridgeFactory dbf = new DataBridgeFactory();
            dbf.MatchArchiveBridge = new ChppMatchArchiveBridge(accessor);
            dbf.MatchDetailsBridge = new CacheMatchDetailsBridge(new ChppMatchDetailsBridge(accessor));
            dbf.TeamDetailsBridge = new ChppTeamDetailsBridge(accessor);
            dbf.PlayersBridge = new ChppPlayersBridge(accessor);
            Environment.DataBridgeFactory = dbf;
        }

        private void clearCacheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //TODO: remove this hardcoded crap
                Directory.Delete(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data"), true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void UpdateTeam()
        {
            try
            {
                Environment.Team = Environment.DataBridgeFactory.TeamDetailsBridge.GetTeamDetails(uint.Parse(textBoxTeamId.Text));
                labelTeamInfo.Text = Environment.Team.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void UpdateOpponent()
        {
            try
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

                labelOpponentInfo.Text = Environment.Opponent != null ? Environment.Opponent.ToString() : "all teams";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void textBoxTeamId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateTeam();
            } 
        }

        private void textBoxTeamId_Leave(object sender, EventArgs e)
        {
            UpdateTeam();
        }

        private void textBoxOppId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateOpponent();
            }
        }

        private void textBoxOppId_Leave(object sender, EventArgs e)
        {
            UpdateOpponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (overviewPage1.Visible)
                overviewPage1.StartWorking();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void offlineModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void proxyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (WebProxyDialog diag = new WebProxyDialog())
            {
                if (diag.ShowDialog() == DialogResult.OK)
                {
                    string fullAuthDirectoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "auth");
                    string filepath = Path.Combine(fullAuthDirectoryPath, "proxy");

                    if (!Directory.Exists(fullAuthDirectoryPath))
                    {
                        Directory.CreateDirectory(fullAuthDirectoryPath);
                    }

                    File.WriteAllLines(filepath, new[] { diag.WebProxyUri }, Encoding.UTF8);
                }
            }
        }

    }
}
