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
#if !MONO
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            // 
            // chartHatstats
            // 
            this.chartHatstats = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartArea1.Name = "ChartArea1";
            this.chartHatstats.ChartAreas.Add(chartArea1);
            this.chartHatstats.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartHatstats.Legends.Add(legend1);
            this.chartHatstats.Location = new System.Drawing.Point(0, 0);
            this.chartHatstats.Name = "chartHatstats";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartHatstats.Series.Add(series1);
            this.chartHatstats.Size = new System.Drawing.Size(434, 128);
            this.chartHatstats.TabIndex = 0;
            this.chartHatstats.Text = "chart1";
#endif
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.sortableListViewMatches = new HtHistory.UserControls.SortableListView();

#if !MONO            
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
#endif            
			this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
#if !MONO
			((System.ComponentModel.ISupportInitialize)(this.chartHatstats)).BeginInit();
#endif
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
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chartHatstats);
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
            this.splitContainer1.Panel2.ResumeLayout(false);
#if !MONO
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
#endif
            this.splitContainer1.ResumeLayout(false);
#if !MONO
			((System.ComponentModel.ISupportInitialize)(this.chartHatstats)).EndInit();
#endif
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private UserControls.SortableListView sortableListViewMatches;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartHatstats;
    }
}
