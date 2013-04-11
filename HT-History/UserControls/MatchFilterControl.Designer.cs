namespace HtHistory.UserControls
{
    partial class MatchFilterControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTeamId = new System.Windows.Forms.Label();
            this.labelOppId = new System.Windows.Forms.Label();
            this.textBoxTeamId = new System.Windows.Forms.TextBox();
            this.textBoxOpponentId = new System.Windows.Forms.TextBox();
            this.labelVenue = new System.Windows.Forms.Label();
            this.listBoxVenue = new System.Windows.Forms.ListBox();
            this.labelSeason = new System.Windows.Forms.Label();
            this.listBoxSeason = new System.Windows.Forms.ListBox();
            this.labelForfaits = new System.Windows.Forms.Label();
            this.checkBoxForfait = new System.Windows.Forms.CheckBox();
            this.labelType = new System.Windows.Forms.Label();
            this.listBoxType = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // labelTeamId
            // 
            this.labelTeamId.AutoSize = true;
            this.labelTeamId.Location = new System.Drawing.Point(3, 10);
            this.labelTeamId.Name = "labelTeamId";
            this.labelTeamId.Size = new System.Drawing.Size(51, 13);
            this.labelTeamId.TabIndex = 0;
            this.labelTeamId.Text = "Team ID:\r\n";
            // 
            // labelOppId
            // 
            this.labelOppId.AutoSize = true;
            this.labelOppId.Location = new System.Drawing.Point(3, 45);
            this.labelOppId.Name = "labelOppId";
            this.labelOppId.Size = new System.Drawing.Size(71, 26);
            this.labelOppId.TabIndex = 1;
            this.labelOppId.Text = "Opponent ID:\r\n( 0 = all )";
            // 
            // textBoxTeamId
            // 
            this.textBoxTeamId.Enabled = false;
            this.textBoxTeamId.Location = new System.Drawing.Point(80, 7);
            this.textBoxTeamId.Name = "textBoxTeamId";
            this.textBoxTeamId.Size = new System.Drawing.Size(104, 20);
            this.textBoxTeamId.TabIndex = 2;
            this.textBoxTeamId.Text = "0";
            // 
            // textBoxOpponentId
            // 
            this.textBoxOpponentId.Enabled = false;
            this.textBoxOpponentId.Location = new System.Drawing.Point(80, 51);
            this.textBoxOpponentId.Name = "textBoxOpponentId";
            this.textBoxOpponentId.Size = new System.Drawing.Size(104, 20);
            this.textBoxOpponentId.TabIndex = 2;
            this.textBoxOpponentId.Text = "0";
            this.textBoxOpponentId.TextChanged += new System.EventHandler(this.RaiseFilterChanged);
            // 
            // labelVenue
            // 
            this.labelVenue.AutoSize = true;
            this.labelVenue.Location = new System.Drawing.Point(382, 10);
            this.labelVenue.Name = "labelVenue";
            this.labelVenue.Size = new System.Drawing.Size(41, 13);
            this.labelVenue.TabIndex = 3;
            this.labelVenue.Text = "Venue:";
            // 
            // listBoxVenue
            // 
            this.listBoxVenue.BackColor = System.Drawing.Color.White;
            this.listBoxVenue.Enabled = false;
            this.listBoxVenue.ForeColor = System.Drawing.Color.Black;
            this.listBoxVenue.FormattingEnabled = true;
            this.listBoxVenue.Items.AddRange(new object[] {
            "All",
            "Home",
            "Away",
            "Neutral"});
            this.listBoxVenue.Location = new System.Drawing.Point(429, 7);
            this.listBoxVenue.Name = "listBoxVenue";
            this.listBoxVenue.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxVenue.Size = new System.Drawing.Size(120, 56);
            this.listBoxVenue.TabIndex = 4;
            this.listBoxVenue.SelectedIndexChanged += new System.EventHandler(this.RaiseFilterChanged);
            // 
            // labelSeason
            // 
            this.labelSeason.AutoSize = true;
            this.labelSeason.Location = new System.Drawing.Point(569, 10);
            this.labelSeason.Name = "labelSeason";
            this.labelSeason.Size = new System.Drawing.Size(46, 13);
            this.labelSeason.TabIndex = 5;
            this.labelSeason.Text = "Season:";
            // 
            // listBoxSeason
            // 
            this.listBoxSeason.BackColor = System.Drawing.Color.White;
            this.listBoxSeason.Enabled = false;
            this.listBoxSeason.ForeColor = System.Drawing.Color.Black;
            this.listBoxSeason.FormattingEnabled = true;
            this.listBoxSeason.Location = new System.Drawing.Point(621, 7);
            this.listBoxSeason.Name = "listBoxSeason";
            this.listBoxSeason.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxSeason.Size = new System.Drawing.Size(144, 95);
            this.listBoxSeason.TabIndex = 6;
            this.listBoxSeason.SelectedIndexChanged += new System.EventHandler(this.RaiseFilterChanged);
            // 
            // labelForfaits
            // 
            this.labelForfaits.AutoSize = true;
            this.labelForfaits.Location = new System.Drawing.Point(382, 82);
            this.labelForfaits.Name = "labelForfaits";
            this.labelForfaits.Size = new System.Drawing.Size(44, 13);
            this.labelForfaits.TabIndex = 7;
            this.labelForfaits.Text = "Forfaits:";
            // 
            // checkBoxForfait
            // 
            this.checkBoxForfait.AutoSize = true;
            this.checkBoxForfait.Enabled = false;
            this.checkBoxForfait.Location = new System.Drawing.Point(432, 81);
            this.checkBoxForfait.Name = "checkBoxForfait";
            this.checkBoxForfait.Size = new System.Drawing.Size(69, 17);
            this.checkBoxForfait.TabIndex = 8;
            this.checkBoxForfait.Text = "excluded";
            this.checkBoxForfait.UseVisualStyleBackColor = true;
            this.checkBoxForfait.CheckedChanged += new System.EventHandler(this.RaiseFilterChanged);
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(202, 10);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(34, 13);
            this.labelType.TabIndex = 9;
            this.labelType.Text = "Type:";
            // 
            // listBoxType
            // 
            this.listBoxType.BackColor = System.Drawing.Color.White;
            this.listBoxType.Enabled = false;
            this.listBoxType.ForeColor = System.Drawing.Color.Black;
            this.listBoxType.FormattingEnabled = true;
            this.listBoxType.Items.AddRange(new object[] {
            "All",
            "Competitive",
            "League",
            "Cup",
            "Qualifier",
            "Masters / Other",
            "Friendly"});
            this.listBoxType.Location = new System.Drawing.Point(242, 7);
            this.listBoxType.Name = "listBoxType";
            this.listBoxType.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxType.Size = new System.Drawing.Size(120, 95);
            this.listBoxType.TabIndex = 10;
            this.listBoxType.SelectedIndexChanged += new System.EventHandler(this.RaiseFilterChanged);
            // 
            // MatchFilterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBoxType);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.checkBoxForfait);
            this.Controls.Add(this.labelForfaits);
            this.Controls.Add(this.listBoxSeason);
            this.Controls.Add(this.labelSeason);
            this.Controls.Add(this.listBoxVenue);
            this.Controls.Add(this.labelVenue);
            this.Controls.Add(this.textBoxOpponentId);
            this.Controls.Add(this.textBoxTeamId);
            this.Controls.Add(this.labelOppId);
            this.Controls.Add(this.labelTeamId);
            this.Name = "MatchFilterControl";
            this.Size = new System.Drawing.Size(777, 113);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTeamId;
        private System.Windows.Forms.Label labelOppId;
        private System.Windows.Forms.TextBox textBoxTeamId;
        private System.Windows.Forms.TextBox textBoxOpponentId;
        private System.Windows.Forms.Label labelVenue;
        private System.Windows.Forms.ListBox listBoxVenue;
        private System.Windows.Forms.Label labelSeason;
        private System.Windows.Forms.ListBox listBoxSeason;
        private System.Windows.Forms.Label labelForfaits;
        private System.Windows.Forms.CheckBox checkBoxForfait;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.ListBox listBoxType;
    }
}
