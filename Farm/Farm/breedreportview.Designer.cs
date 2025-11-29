namespace Farm
{
    partial class breedreportview
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.reportview = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportview
            // 
            this.reportview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportview.Location = new System.Drawing.Point(0, 0);
            this.reportview.Name = "reportview";
            this.reportview.ServerReport.BearerToken = null;
            this.reportview.ShowBackButton = false;
            this.reportview.ShowContextMenu = false;
            this.reportview.ShowCredentialPrompts = false;
            this.reportview.ShowDocumentMapButton = false;
            this.reportview.ShowExportButton = false;
            this.reportview.ShowFindControls = false;
            this.reportview.ShowPageNavigationControls = false;
            this.reportview.ShowParameterPrompts = false;
            this.reportview.ShowPrintButton = false;
            this.reportview.ShowProgress = false;
            this.reportview.ShowPromptAreaButton = false;
            this.reportview.ShowRefreshButton = false;
            this.reportview.ShowStopButton = false;
            this.reportview.ShowToolBar = false;
            this.reportview.ShowZoomControl = false;
            this.reportview.Size = new System.Drawing.Size(1084, 376);
            this.reportview.TabIndex = 0;
            // 
            // breedreportview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 376);
            this.Controls.Add(this.reportview);
            this.Name = "breedreportview";
            this.Text = "breedreportview";
            this.Load += new System.EventHandler(this.breedreportview_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer reportview;
    }
}