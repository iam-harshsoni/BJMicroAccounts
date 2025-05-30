﻿namespace BJMicroAccounts.Reports
{
    partial class ReportSales
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
            this.SalesMasterVMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SalesDetailsVMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.SalesMasterVMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesDetailsVMBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.SalesMasterVMBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.SalesDetailsVMBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "BJMicroAccounts.Reports.SalesReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(620, 528);
            this.reportViewer1.TabIndex = 0;
            // 
            // SalesMasterVMBindingSource
            // 
            this.SalesMasterVMBindingSource.DataSource = typeof(MicroAccounts.ViewModel.SalesMasterVM);
            // 
            // SalesDetailsVMBindingSource
            // 
            this.SalesDetailsVMBindingSource.DataSource = typeof(MicroAccounts.ViewModel.SalesDetailsVM);
            // 
            // ReportSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 528);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReportSales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportSales";
            this.Load += new System.EventHandler(this.ReportSales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SalesMasterVMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesDetailsVMBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SalesMasterVMBindingSource;
        private System.Windows.Forms.BindingSource SalesDetailsVMBindingSource;
    }
}