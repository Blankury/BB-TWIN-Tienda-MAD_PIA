namespace MAD
{
    partial class Form20
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DATA_HISTORIAL_RECIBOS = new MAD.DATA_HISTORIAL_RECIBOS();
            this.RECIBOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RECIBOTableAdapter = new MAD.DATA_HISTORIAL_RECIBOSTableAdapters.RECIBOTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DATA_HISTORIAL_RECIBOS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RECIBOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "HISTORIAL";
            reportDataSource1.Value = this.RECIBOBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MAD.Reporte_Historial_Recibos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(639, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // DATA_HISTORIAL_RECIBOS
            // 
            this.DATA_HISTORIAL_RECIBOS.DataSetName = "DATA_HISTORIAL_RECIBOS";
            this.DATA_HISTORIAL_RECIBOS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // RECIBOBindingSource
            // 
            this.RECIBOBindingSource.DataMember = "RECIBO";
            this.RECIBOBindingSource.DataSource = this.DATA_HISTORIAL_RECIBOS;
            // 
            // RECIBOTableAdapter
            // 
            this.RECIBOTableAdapter.ClearBeforeFill = true;
            // 
            // Form20
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form20";
            this.Text = "Form20";
            this.Load += new System.EventHandler(this.Form20_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DATA_HISTORIAL_RECIBOS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RECIBOBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource RECIBOBindingSource;
        private DATA_HISTORIAL_RECIBOS DATA_HISTORIAL_RECIBOS;
        private DATA_HISTORIAL_RECIBOSTableAdapters.RECIBOTableAdapter RECIBOTableAdapter;
    }
}