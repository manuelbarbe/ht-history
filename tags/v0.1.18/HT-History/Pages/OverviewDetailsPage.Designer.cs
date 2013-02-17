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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.sortableListViewDetails1 = new HtHistory.UserControls.SortableListView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.sortableListViewDetails2 = new HtHistory.UserControls.SortableListView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.sortableListViewDetails3 = new HtHistory.UserControls.SortableListView();
#if !MONO 
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
#endif            
			this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
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
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(750, 231);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.sortableListViewDetails1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(742, 205);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.sortableListViewDetails2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(742, 205);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.sortableListViewDetails3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(742, 205);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
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
#if !MONO
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
#endif            
			this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected UserControls.SortableListView sortableListViewOverview;
        protected UserControls.SortableListView sortableListViewDetails1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        protected System.Windows.Forms.TabPage tabPage1;
        protected System.Windows.Forms.TabPage tabPage2;
        protected UserControls.SortableListView sortableListViewDetails2;
        protected System.Windows.Forms.TabPage tabPage3;
        protected UserControls.SortableListView sortableListViewDetails3;
        
    }
}
