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
            this.chartBySeason = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelCurrency = new System.Windows.Forms.Label();
            this.comboBoxCurrency = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.sortableListViewTransfers = new HtHistory.UserControls.SortableListView();
            ((System.ComponentModel.ISupportInitialize)(this.chartBySeason)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
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
            this.chartBySeason.Size = new System.Drawing.Size(517, 82);
            this.chartBySeason.TabIndex = 0;
            this.chartBySeason.Text = "chart1";
            // 
            // labelCurrency
            // 
            this.labelCurrency.AutoSize = true;
            this.labelCurrency.Location = new System.Drawing.Point(3, 9);
            this.labelCurrency.Name = "labelCurrency";
            this.labelCurrency.Size = new System.Drawing.Size(52, 13);
            this.labelCurrency.TabIndex = 1;
            this.labelCurrency.Text = "Currency:";
            // 
            // comboBoxCurrency
            // 
            this.comboBoxCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCurrency.Location = new System.Drawing.Point(94, 6);
            this.comboBoxCurrency.Name = "comboBoxCurrency";
            this.comboBoxCurrency.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCurrency.TabIndex = 0;
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
            this.splitContainer1.Panel1.Controls.Add(this.labelCurrency);
            this.splitContainer1.Panel1.Controls.Add(this.comboBoxCurrency);
            this.splitContainer1.Panel1.Controls.Add(this.sortableListViewTransfers);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chartBySeason);
            this.splitContainer1.Size = new System.Drawing.Size(517, 315);
            this.splitContainer1.SplitterDistance = 229;
            this.splitContainer1.TabIndex = 0;
            // 
            // sortableListViewTransfers
            // 
            this.sortableListViewTransfers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sortableListViewTransfers.FullRowSelect = true;
            this.sortableListViewTransfers.Location = new System.Drawing.Point(0, 31);
            this.sortableListViewTransfers.Name = "sortableListViewTransfers";
            this.sortableListViewTransfers.Size = new System.Drawing.Size(517, 198);
            this.sortableListViewTransfers.TabIndex = 0;
            this.sortableListViewTransfers.UseCompatibleStateImageBehavior = false;
            this.sortableListViewTransfers.View = System.Windows.Forms.View.Details;
            // 
            // TransfersPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "TransfersPage";
            this.Size = new System.Drawing.Size(517, 315);
            ((System.ComponentModel.ISupportInitialize)(this.chartBySeason)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private UserControls.SortableListView sortableListViewTransfers;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBySeason;
        private System.Windows.Forms.ComboBox comboBoxCurrency;
		private System.Windows.Forms.Label labelCurrency;
    }
}
