namespace HtHistory.Pages
{
    partial class MatchesPage
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
            this.sortableListViewMatches = new HtHistory.UserControls.SortableListView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.sortableListViewMatches);
            this.splitContainer1.Size = new System.Drawing.Size(434, 276);
            this.splitContainer1.SplitterDistance = 144;
            this.splitContainer1.TabIndex = 0;
            // 
            // sortableListViewMatches
            // 
            this.sortableListViewMatches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sortableListViewMatches.FullRowSelect = true;
            this.sortableListViewMatches.Location = new System.Drawing.Point(0, 0);
            this.sortableListViewMatches.Name = "sortableListViewMatches";
            this.sortableListViewMatches.Size = new System.Drawing.Size(434, 144);
            this.sortableListViewMatches.TabIndex = 0;
            this.sortableListViewMatches.UseCompatibleStateImageBehavior = false;
            this.sortableListViewMatches.View = System.Windows.Forms.View.Details;
            // 
            // MatchesPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "MatchesPage";
            this.Size = new System.Drawing.Size(434, 276);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private UserControls.SortableListView sortableListViewMatches;
    }
}
