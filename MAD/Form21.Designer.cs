namespace MAD
{
    partial class Form21
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form21));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.HORAS_TRABAJADASBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Data_horas = new MAD.Data_horas();
            this.HORAS_TRABAJADASTableAdapter = new MAD.Data_horasTableAdapters.HORAS_TRABAJADASTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.HORAS_TRABAJADASBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Data_horas)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "REPORTE_DE_HORAS";
            reportDataSource1.Value = this.HORAS_TRABAJADASBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MAD.Reporte_Horas_Trabajadas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(526, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // HORAS_TRABAJADASBindingSource
            // 
            this.HORAS_TRABAJADASBindingSource.DataMember = "HORAS_TRABAJADAS";
            this.HORAS_TRABAJADASBindingSource.DataSource = this.Data_horas;
            // 
            // Data_horas
            // 
            this.Data_horas.DataSetName = "Data_horas";
            this.Data_horas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // HORAS_TRABAJADASTableAdapter
            // 
            this.HORAS_TRABAJADASTableAdapter.ClearBeforeFill = true;
            // 
            // Form21
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 450);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form21";
            this.Text = "Form21";
            this.Load += new System.EventHandler(this.Form21_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HORAS_TRABAJADASBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Data_horas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource HORAS_TRABAJADASBindingSource;
        private Data_horas Data_horas;
        private Data_horasTableAdapters.HORAS_TRABAJADASTableAdapter HORAS_TRABAJADASTableAdapter;
    }
}