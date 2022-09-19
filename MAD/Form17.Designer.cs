namespace MAD
{
    partial class Form17
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form17));
            this.PRODUCTOS_CARRITOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DATA_CARRITO = new MAD.DATA_CARRITO();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PRODUCTOS_CARRITOTableAdapter = new MAD.DATA_CARRITOTableAdapters.PRODUCTOS_CARRITOTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.PRODUCTOS_CARRITOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATA_CARRITO)).BeginInit();
            this.SuspendLayout();
            // 
            // PRODUCTOS_CARRITOBindingSource
            // 
            this.PRODUCTOS_CARRITOBindingSource.DataMember = "PRODUCTOS_CARRITO";
            this.PRODUCTOS_CARRITOBindingSource.DataSource = this.DATA_CARRITO;
            // 
            // DATA_CARRITO
            // 
            this.DATA_CARRITO.DataSetName = "DATA_CARRITO";
            this.DATA_CARRITO.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "PRODUCTOS";
            reportDataSource1.Value = this.PRODUCTOS_CARRITOBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MAD.Report_Carrito.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(617, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // PRODUCTOS_CARRITOTableAdapter
            // 
            this.PRODUCTOS_CARRITOTableAdapter.ClearBeforeFill = true;
            // 
            // Form17
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 450);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form17";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form17";
            this.Load += new System.EventHandler(this.Form17_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PRODUCTOS_CARRITOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATA_CARRITO)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PRODUCTOS_CARRITOBindingSource;
        private DATA_CARRITO DATA_CARRITO;
        private DATA_CARRITOTableAdapters.PRODUCTOS_CARRITOTableAdapter PRODUCTOS_CARRITOTableAdapter;
    }
}