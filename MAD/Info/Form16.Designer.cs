namespace MAD
{
    partial class Form16
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
            this.PRODUCTOS_CARRITO1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetRecibo = new MAD.DataSetRecibo();
            this.PRODUCTOS_CARRITO1TableAdapter = new MAD.DataSetReciboTableAdapters.PRODUCTOS_CARRITO1TableAdapter();
            this.RECIBOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RECIBOTableAdapter = new MAD.DataSetReciboTableAdapters.RECIBOTableAdapter();
            this.dataSetReciboBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pRODUCTOSCARRITO1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PRODUCTOS_CARRITO1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetRecibo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RECIBOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetReciboBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRODUCTOSCARRITO1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Productos";
            reportDataSource1.Value = this.pRODUCTOSCARRITO1BindingSource;
            reportDataSource2.Name = "Recibo";
            reportDataSource2.Value = this.RECIBOBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MAD.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 514);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // PRODUCTOS_CARRITO1BindingSource
            // 
            this.PRODUCTOS_CARRITO1BindingSource.DataMember = "PRODUCTOS_CARRITO1";
            this.PRODUCTOS_CARRITO1BindingSource.DataSource = this.DataSetRecibo;
            // 
            // DataSetRecibo
            // 
            this.DataSetRecibo.DataSetName = "DataSetRecibo";
            this.DataSetRecibo.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PRODUCTOS_CARRITO1TableAdapter
            // 
            this.PRODUCTOS_CARRITO1TableAdapter.ClearBeforeFill = true;
            // 
            // RECIBOBindingSource
            // 
            this.RECIBOBindingSource.DataMember = "RECIBO";
            this.RECIBOBindingSource.DataSource = this.DataSetRecibo;
            // 
            // RECIBOTableAdapter
            // 
            this.RECIBOTableAdapter.ClearBeforeFill = true;
            // 
            // dataSetReciboBindingSource
            // 
            this.dataSetReciboBindingSource.DataSource = this.DataSetRecibo;
            this.dataSetReciboBindingSource.Position = 0;
            // 
            // pRODUCTOSCARRITO1BindingSource
            // 
            this.pRODUCTOSCARRITO1BindingSource.DataMember = "PRODUCTOS_CARRITO1";
            this.pRODUCTOSCARRITO1BindingSource.DataSource = this.DataSetRecibo;
            // 
            // Form16
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 514);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form16";
            this.Text = "Form16";
            this.Load += new System.EventHandler(this.Form16_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PRODUCTOS_CARRITO1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetRecibo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RECIBOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetReciboBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRODUCTOSCARRITO1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PRODUCTOS_CARRITO1BindingSource;
        private DataSetRecibo DataSetRecibo;
        private DataSetReciboTableAdapters.PRODUCTOS_CARRITO1TableAdapter PRODUCTOS_CARRITO1TableAdapter;
        private System.Windows.Forms.BindingSource RECIBOBindingSource;
        private DataSetReciboTableAdapters.RECIBOTableAdapter RECIBOTableAdapter;
        private System.Windows.Forms.BindingSource dataSetReciboBindingSource;
        private System.Windows.Forms.BindingSource pRODUCTOSCARRITO1BindingSource;
    }
}