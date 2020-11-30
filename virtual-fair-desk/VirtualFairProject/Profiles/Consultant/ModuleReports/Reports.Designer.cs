namespace VirtualFairProject.Profiles.Consultant.ModuleReports
{
    partial class Reports
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerarReporte = new System.Windows.Forms.Button();
            this.lblLinea = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblCerrarSesion = new System.Windows.Forms.LinkLabel();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lblProductoMasPerdido = new System.Windows.Forms.Label();
            this.lblPesoTotalPerdidaKg = new System.Windows.Forms.Label();
            this.lblCostoTotalPerdida = new System.Windows.Forms.Label();
            this.btnDescargarReporte = new System.Windows.Forms.Button();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reportes pérdidas de frutas";
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.Location = new System.Drawing.Point(640, 86);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Size = new System.Drawing.Size(135, 25);
            this.btnGenerarReporte.TabIndex = 1;
            this.btnGenerarReporte.Text = "Generar Reporte";
            this.btnGenerarReporte.UseVisualStyleBackColor = true;
            this.btnGenerarReporte.Click += new System.EventHandler(this.btnGenerarReporte_Click);
            // 
            // lblLinea
            // 
            this.lblLinea.AutoSize = true;
            this.lblLinea.Location = new System.Drawing.Point(36, 114);
            this.lblLinea.Name = "lblLinea";
            this.lblLinea.Size = new System.Drawing.Size(742, 15);
            this.lblLinea.TabIndex = 2;
            this.lblLinea.Text = "_________________________________________________________________________________" +
    "________________________";
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(342, 399);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(94, 23);
            this.btnVolver.TabIndex = 3;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblCerrarSesion
            // 
            this.lblCerrarSesion.AutoSize = true;
            this.lblCerrarSesion.Location = new System.Drawing.Point(693, 9);
            this.lblCerrarSesion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCerrarSesion.Name = "lblCerrarSesion";
            this.lblCerrarSesion.Size = new System.Drawing.Size(82, 15);
            this.lblCerrarSesion.TabIndex = 22;
            this.lblCerrarSesion.TabStop = true;
            this.lblCerrarSesion.Text = "Cerrar Sesión";
            this.lblCerrarSesion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCerrarSesion_LinkClicked);
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(394, 91);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(200, 20);
            this.dtpHasta.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(334, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 25;
            this.label3.Text = "Hasta:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(105, 91);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(200, 20);
            this.dtpDesde.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 15);
            this.label2.TabIndex = 23;
            this.label2.Text = "Desde:";
            // 
            // lblProductoMasPerdido
            // 
            this.lblProductoMasPerdido.AutoSize = true;
            this.lblProductoMasPerdido.Location = new System.Drawing.Point(55, 163);
            this.lblProductoMasPerdido.Name = "lblProductoMasPerdido";
            this.lblProductoMasPerdido.Size = new System.Drawing.Size(14, 15);
            this.lblProductoMasPerdido.TabIndex = 27;
            this.lblProductoMasPerdido.Text = "<";
            // 
            // lblPesoTotalPerdidaKg
            // 
            this.lblPesoTotalPerdidaKg.AutoSize = true;
            this.lblPesoTotalPerdidaKg.Location = new System.Drawing.Point(309, 163);
            this.lblPesoTotalPerdidaKg.Name = "lblPesoTotalPerdidaKg";
            this.lblPesoTotalPerdidaKg.Size = new System.Drawing.Size(14, 15);
            this.lblPesoTotalPerdidaKg.TabIndex = 28;
            this.lblPesoTotalPerdidaKg.Text = "<";
            // 
            // lblCostoTotalPerdida
            // 
            this.lblCostoTotalPerdida.AutoSize = true;
            this.lblCostoTotalPerdida.Location = new System.Drawing.Point(515, 163);
            this.lblCostoTotalPerdida.Name = "lblCostoTotalPerdida";
            this.lblCostoTotalPerdida.Size = new System.Drawing.Size(14, 15);
            this.lblCostoTotalPerdida.TabIndex = 29;
            this.lblCostoTotalPerdida.Text = "<";
            // 
            // btnDescargarReporte
            // 
            this.btnDescargarReporte.Location = new System.Drawing.Point(640, 153);
            this.btnDescargarReporte.Name = "btnDescargarReporte";
            this.btnDescargarReporte.Size = new System.Drawing.Size(135, 25);
            this.btnDescargarReporte.TabIndex = 30;
            this.btnDescargarReporte.Text = "Descargar Reporte";
            this.btnDescargarReporte.UseVisualStyleBackColor = true;
            this.btnDescargarReporte.Click += new System.EventHandler(this.btnDescargarReporte_Click);
            // 
            // dgvReport
            // 
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(131, 208);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.RowHeadersWidth = 51;
            this.dgvReport.Size = new System.Drawing.Size(600, 150);
            this.dgvReport.TabIndex = 31;
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvReport);
            this.Controls.Add(this.btnDescargarReporte);
            this.Controls.Add(this.lblCostoTotalPerdida);
            this.Controls.Add(this.lblPesoTotalPerdidaKg);
            this.Controls.Add(this.lblProductoMasPerdido);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCerrarSesion);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.lblLinea);
            this.Controls.Add(this.btnGenerarReporte);
            this.Controls.Add(this.label1);
            this.Name = "Reports";
            this.Text = "Reports";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenerarReporte;
        private System.Windows.Forms.Label lblLinea;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.LinkLabel lblCerrarSesion;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblProductoMasPerdido;
        private System.Windows.Forms.Label lblPesoTotalPerdidaKg;
        private System.Windows.Forms.Label lblCostoTotalPerdida;
        private System.Windows.Forms.Button btnDescargarReporte;
        private System.Windows.Forms.DataGridView dgvReport;
    }
}