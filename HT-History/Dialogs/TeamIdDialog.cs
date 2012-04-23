using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HtHistory.Dialogs
{
    public partial class TeamIdDialog : Form
    {
        public TeamIdDialog(uint teamId = 0)
        {
            InitializeComponent();
            textBoxTeamId.Text = teamId.ToString();
        }

        private uint _teamId = 0;

        public uint TeamId
        {
            get
            {
                return _teamId;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                _teamId = uint.Parse(textBoxTeamId.Text);
            }
            catch
            {
                MessageBox.Show("Cannot parse value. Defaulting to 0.");
                _teamId = 0;
            }
        }
    }
}
