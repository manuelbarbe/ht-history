namespace HtHistory.Pages
{
    partial class OverviewDetailsPage
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.sortableListViewOverview = new HtHistory.UserControls.SortableListView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPagePlayerSeasons = new System.Windows.Forms.TabPage();
            this.sortableListViewDetails1 = new HtHistory.UserControls.SortableListView();
            this.tabPagePlayerMatches = new System.Windows.Forms.TabPage();
            this.sortableListViewDetails2 = new HtHistory.UserControls.SortableListView();
            this.tabPagePlayerGoals = new System.Windows.Forms.TabPage();
            this.sortableListViewDetails3 = new HtHistory.UserControls.SortableListView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPagePlayerSeasons.SuspendLayout();
            this.tabPagePlayerMatches.SuspendLayout();
            this.tabPagePlayerGoals.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 31);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.sortableListViewOverview);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(750, 469);
            this.splitContainer1.SplitterDistance = 234;
            this.splitContainer1.TabIndex = 1;
            // 
            // sortableListViewOverview
            // 
            this.sortableListViewOverview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sortableListViewOverview.FullRowSelect = true;
            this.sortableListViewOverview.HideSelection = false;
            this.sortableListViewOverview.Location = new System.Drawing.Point(0, 0);
            this.sortableListViewOverview.Name = "sortableListViewOverview";
            this.sortableListViewOverview.ShowItemToolTips = true;
            this.sortableListViewOverview.Size = new System.Drawing.Size(750, 234);
            this.sortableListViewOverview.TabIndex = 0;
            this.sortableListViewOverview.UseCompatibleStateImageBehavior = false;
            this.sortableListViewOverview.View = System.Windows.Forms.View.Details;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPagePlayerSeasons);
            this.tabControl1.Controls.Add(this.tabPagePlayerMatches);
            this.tabControl1.Controls.Add(this.tabPagePlayerGoals);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(750, 231);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPagePlayerSeasons
            // 
            this.tabPagePlayerSeasons.Controls.Add(this.sortableListViewDetails1);
            this.tabPagePlayerSeasons.Location = new System.Drawing.Point(4, 22);
            this.tabPagePlayerSeasons.Name = "tabPagePlayerSeasons";
            this.tabPagePlayerSeasons.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePlayerSeasons.Size = new System.Drawing.Size(742, 205);
            this.tabPagePlayerSeasons.TabIndex = 0;
            this.tabPagePlayerSeasons.Text = "tabPage1";
            this.tabPagePlayerSeasons.UseVisualStyleBackColor = true;
            // 
            // sortableListViewDetails1
            // 
            this.sortableListViewDetails1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sortableListViewDetails1.FullRowSelect = true;
            this.sortableListViewDetails1.Location = new System.Drawing.Point(3, 3);
            this.sortableListViewDetails1.Name = "sortableListViewDetails1";
            this.sortableListViewDetails1.Size = new System.Drawing.Size(736, 199);
            this.sortableListViewDetails1.TabIndex = 0;
            this.sortableListViewDetails1.UseCompatibleStateImageBehavior = false;
            this.sortableListViewDetails1.View = System.Windows.Forms.View.Details;
            // 
            // tabPagePlayerMatches
            // 
            this.tabPagePlayerMatches.Controls.Add(this.sortableListViewDetails2);
            this.tabPagePlayerMatches.Location = new System.Drawing.Point(4, 22);
            this.tabPagePlayerMatches.Name = "tabPagePlayerMatches";
            this.tabPagePlayerMatches.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePlayerMatches.Size = new System.Drawing.Size(742, 205);
            this.tabPagePlayerMatches.TabIndex = 1;
            this.tabPagePlayerMatches.Text = "tabPage2";
            this.tabPagePlayerMatches.UseVisualStyleBackColor = true;
            // 
            // sortableListViewDetails2
            // 
            this.sortableListViewDetails2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sortableListViewDetails2.FullRowSelect = true;
            this.sortableListViewDetails2.Location = new System.Drawing.Point(3, 3);
            this.sortableListViewDetails2.Name = "sortableListViewDetails2";
            this.sortableListViewDetails2.Size = new System.Drawing.Size(736, 199);
            this.sortableListViewDetails2.TabIndex = 1;
            this.sortableListViewDetails2.UseCompatibleStateImageBehavior = false;
            this.sortableListViewDetails2.View = System.Windows.Forms.View.Details;
            // 
            // tabPagePlayerGoals
            // 
            this.tabPagePlayerGoals.Controls.Add(this.sortableListViewDetails3);
            this.tabPagePlayerGoals.Location = new System.Drawing.Point(4, 22);
            this.tabPagePlayerGoals.Name = "tabPagePlayerGoals";
            this.tabPagePlayerGoals.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePlayerGoals.Size = new System.Drawing.Size(742, 205);
            this.tabPagePlayerGoals.TabIndex = 2;
            this.tabPagePlayerGoals.Text = "tabPage3";
            this.tabPagePlayerGoals.UseVisualStyleBackColor = true;
            // 
            // sortableListViewDetails3
            // 
            this.sortableListViewDetails3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sortableListViewDetails3.FullRowSelect = true;
            this.sortableListViewDetails3.Location = new System.Drawing.Point(3, 3);
            this.sortableListViewDetails3.Name = "sortableListViewDetails3";
            this.sortableListViewDetails3.Size = new System.Drawing.Size(736, 199);
            this.sortableListViewDetails3.TabIndex = 1;
            this.sortableListViewDetails3.UseCompatibleStateImageBehavior = false;
            this.sortableListViewDetails3.View = System.Windows.Forms.View.Details;
            // 
            // OverviewDetailsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "OverviewDetailsPage";
            this.Size = new System.Drawing.Size(750, 500);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPagePlayerSeasons.ResumeLayout(false);
            this.tabPagePlayerMatches.ResumeLayout(false);
            this.tabPagePlayerGoals.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected UserControls.SortableListView sortableListViewOverview;
        protected UserControls.SortableListView sortableListViewDetails1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        protected System.Windows.Forms.TabPage tabPagePlayerSeasons;
        protected System.Windows.Forms.TabPage tabPagePlayerMatches;
        protected UserControls.SortableListView sortableListViewDetails2;
        protected System.Windows.Forms.TabPage tabPagePlayerGoals;
        protected UserControls.SortableListView sortableListViewDetails3;
        
    }
}
