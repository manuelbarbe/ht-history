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
            this.sortableListViewDetails = new HtHistory.UserControls.SortableListView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.sortableListViewOverview);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.sortableListViewDetails);
            this.splitContainer1.Size = new System.Drawing.Size(750, 500);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.TabIndex = 1;
            // 
            // sortableListViewOverview
            // 
            this.sortableListViewOverview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sortableListViewOverview.FullRowSelect = true;
            this.sortableListViewOverview.HideSelection = false;
            this.sortableListViewOverview.Location = new System.Drawing.Point(0, 0);
            this.sortableListViewOverview.MultiSelect = false;
            this.sortableListViewOverview.Name = "sortableListViewOverview";
            this.sortableListViewOverview.Size = new System.Drawing.Size(750, 250);
            this.sortableListViewOverview.TabIndex = 0;
            this.sortableListViewOverview.UseCompatibleStateImageBehavior = false;
            this.sortableListViewOverview.View = System.Windows.Forms.View.Details;
            // 
            // sortableListViewDetails
            // 
            this.sortableListViewDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sortableListViewDetails.FullRowSelect = true;
            this.sortableListViewDetails.Location = new System.Drawing.Point(0, 0);
            this.sortableListViewDetails.MultiSelect = false;
            this.sortableListViewDetails.Name = "sortableListViewDetails";
            this.sortableListViewDetails.Size = new System.Drawing.Size(750, 246);
            this.sortableListViewDetails.TabIndex = 0;
            this.sortableListViewDetails.UseCompatibleStateImageBehavior = false;
            this.sortableListViewDetails.View = System.Windows.Forms.View.Details;
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
            this.ResumeLayout(false);

        }

        #endregion

        protected UserControls.SortableListView sortableListViewOverview;
        protected UserControls.SortableListView sortableListViewDetails;
        private System.Windows.Forms.SplitContainer splitContainer1;
        
    }
}
