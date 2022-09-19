namespace MAD
{
    partial class Form18
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form18));
            this.PRODUCTOS_DISPONIBLESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DATA_PRODUCTOS_CARGADOS = new MAD.DATA_PRODUCTOS_CARGADOS();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PRODUCTOS_DISPONIBLESTableAdapter = new MAD.DATA_PRODUCTOS_CARGADOSTableAdapters.PRODUCTOS_DISPONIBLESTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.PRODUCTOS_DISPONIBLESBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATA_PRODUCTOS_CARGADOS)).BeginInit();
            this.SuspendLayout();
            // 
            // PRODUCTOS_DISPONIBLESBindingSource
            // 
            this.PRODUCTOS_DISPONIBLESBindingSource.DataMember = "PRODUCTOS_DISPONIBLES";
            this.PRODUCTOS_DISPONIBLESBindingSource.DataSource = this.DATA_PRODUCTOS_CARGADOS;
            // 
            // DATA_PRODUCTOS_CARGADOS
            // 
            this.DATA_PRODUCTOS_CARGADOS.DataSetName = "DATA_PRODUCTOS_CARGADOS";
            this.DATA_PRODUCTOS_CARGADOS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "PRODUCTOS";
            reportDataSource1.Value = this.PRODUCTOS_DISPONIBLESBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MAD.Reporte_Productos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(634, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // PRODUCTOS_DISPONIBLESTableAdapter
            // 
            this.PRODUCTOS_DISPONIBLESTableAdapter.ClearBeforeFill = true;
            // 
            // Form18
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 450);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form18";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form18";
            this.Load += new System.EventHandler(this.Form18_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PRODUCTOS_DISPONIBLESBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATA_PRODUCTOS_CARGADOS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PRODUCTOS_DISPONIBLESBindingSource;
        private DATA_PRODUCTOS_CARGADOS DATA_PRODUCTOS_CARGADOS;
        private DATA_PRODUCTOS_CARGADOSTableAdapters.PRODUCTOS_DISPONIBLESTableAdapter PRODUCTOS_DISPONIBLESTableAdapter;
    }
}