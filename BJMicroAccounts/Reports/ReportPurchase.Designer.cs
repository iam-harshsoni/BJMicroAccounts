namespace BJMicroAccounts.Reports
{
    partial class ReportPurchase
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PurchaseMasterVMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PurchaseDetailsVMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseMasterVMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseDetailsVMBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.PurchaseMasterVMBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.PurchaseDetailsVMBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "BJMicroAccounts.Reports.PurchaseReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(620, 528);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // PurchaseMasterVMBindingSource
            // 
            this.PurchaseMasterVMBindingSource.DataMember = "PurchaseMasterVM";
            // 
            // PurchaseDetailsVMBindingSource
            // 
            this.PurchaseDetailsVMBindingSource.DataSource = typeof(MicroAccounts.ViewModel.PurchaseDetailsVM);
            // 
            // ReportPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 528);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReportPurchase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportPurchase";
            this.Load += new System.EventHandler(this.ReportPurchase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseMasterVMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseDetailsVMBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PurchaseMasterVMBindingSource;
        private System.Windows.Forms.BindingSource PurchaseDetailsVMBindingSource;
    }
}