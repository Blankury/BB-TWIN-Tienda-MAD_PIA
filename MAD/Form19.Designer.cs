namespace MAD
{
    partial class Form19
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form19));
            this.SUCURSALES_DISPONIBLESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DATA_SUCURSALES = new MAD.DATA_SUCURSALES();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SUCURSALES_DISPONIBLESTableAdapter = new MAD.DATA_SUCURSALESTableAdapters.SUCURSALES_DISPONIBLESTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.SUCURSALES_DISPONIBLESBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATA_SUCURSALES)).BeginInit();
            this.SuspendLayout();
            // 
            // SUCURSALES_DISPONIBLESBindingSource
            // 
            this.SUCURSALES_DISPONIBLESBindingSource.DataMember = "SUCURSALES_DISPONIBLES";
            this.SUCURSALES_DISPONIBLESBindingSource.DataSource = this.DATA_SUCURSALES;
            // 
            // DATA_SUCURSALES
            // 
            this.DATA_SUCURSALES.DataSetName = "DATA_SUCURSALES";
            this.DATA_SUCURSALES.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "SUCURSALES";
            reportDataSource1.Value = this.SUCURSALES_DISPONIBLESBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MAD.Reporte_Sucursales.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(603, 450);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // SUCURSALES_DISPONIBLESTableAdapter
            // 
            this.SUCURSALES_DISPONIBLESTableAdapter.ClearBeforeFill = true;
            // 
            // Form19
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 450);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form19";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form19";
            this.Load += new System.EventHandler(this.Form19_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SUCURSALES_DISPONIBLESBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATA_SUCURSALES)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SUCURSALES_DISPONIBLESBindingSource;
        private DATA_SUCURSALES DATA_SUCURSALES;
        private DATA_SUCURSALESTableAdapters.SUCURSALES_DISPONIBLESTableAdapter SUCURSALES_DISPONIBLESTableAdapter;
    }
}