namespace HtHistory.Pages
{
    partial class TransfersPage
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.sortableListViewTransfers = new HtHistory.UserControls.SortableListView();
            this.chartBySeason = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartBySeason)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.sortableListViewTransfers);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chartBySeason);
            this.splitContainer1.Size = new System.Drawing.Size(379, 173);
            this.splitContainer1.SplitterDistance = 126;
            this.splitContainer1.TabIndex = 0;
            // 
            // sortableListViewTransfers
            // 
            this.sortableListViewTransfers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sortableListViewTransfers.FullRowSelect = true;
            this.sortableListViewTransfers.Location = new System.Drawing.Point(0, 0);
            this.sortableListViewTransfers.Name = "sortableListViewTransfers";
            this.sortableListViewTransfers.Size = new System.Drawing.Size(379, 126);
            this.sortableListViewTransfers.TabIndex = 0;
            this.sortableListViewTransfers.UseCompatibleStateImageBehavior = false;
            this.sortableListViewTransfers.View = System.Windows.Forms.View.Details;
            // 
            // chartBySeason
            // 
            chartArea1.Name = "ChartArea1";
            this.chartBySeason.ChartAreas.Add(chartArea1);
            this.chartBySeason.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartBySeason.Legends.Add(legend1);
            this.chartBySeason.Location = new System.Drawing.Point(0, 0);
            this.chartBySeason.Name = "chartBySeason";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartBySeason.Series.Add(series1);
            this.chartBySeason.Size = new System.Drawing.Size(379, 43);
            this.chartBySeason.TabIndex = 0;
            this.chartBySeason.Text = "chart1";
            // 
            // TransfersPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "TransfersPage";
            this.Size = new System.Drawing.Size(379, 173);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartBySeason)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private UserControls.SortableListView sortableListViewTransfers;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBySeason;
    }
}
