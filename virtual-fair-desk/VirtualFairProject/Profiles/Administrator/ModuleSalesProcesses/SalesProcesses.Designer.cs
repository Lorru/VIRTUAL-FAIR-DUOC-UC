namespace VirtualFairProject.Profiles.Administrator.ModuleSalesProcesses
{
    partial class SalesProcesses
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
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.rbProcesosExtranjeros = new System.Windows.Forms.RadioButton();
            this.rbProcesosLocales = new System.Windows.Forms.RadioButton();
            this.btnAplicarFiltro = new System.Windows.Forms.Button();
            this.btnCrearProcesoVenta = new System.Windows.Forms.Button();
            this.dgvSalesProcesses = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblCerrarSesion = new System.Windows.Forms.LinkLabel();
            this.lblBienvenido = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesProcesses)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Procesos de venta";
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(43, 88);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(169, 21);
            this.cmbStatus.TabIndex = 1;
            // 
            // rbProcesosExtranjeros
            // 
            this.rbProcesosExtranjeros.AutoSize = true;
            this.rbProcesosExtranjeros.Location = new System.Drawing.Point(218, 92);
            this.rbProcesosExtranjeros.Name = "rbProcesosExtranjeros";
            this.rbProcesosExtranjeros.Size = new System.Drawing.Size(123, 17);
            this.rbProcesosExtranjeros.TabIndex = 2;
            this.rbProcesosExtranjeros.TabStop = true;
            this.rbProcesosExtranjeros.Text = "Procesos extranjeros";
            this.rbProcesosExtranjeros.UseVisualStyleBackColor = true;
            // 
            // rbProcesosLocales
            // 
            this.rbProcesosLocales.AutoSize = true;
            this.rbProcesosLocales.Location = new System.Drawing.Point(358, 92);
            this.rbProcesosLocales.Name = "rbProcesosLocales";
            this.rbProcesosLocales.Size = new System.Drawing.Size(105, 17);
            this.rbProcesosLocales.TabIndex = 3;
            this.rbProcesosLocales.TabStop = true;
            this.rbProcesosLocales.Text = "Procesos locales";
            this.rbProcesosLocales.UseVisualStyleBackColor = true;
            // 
            // btnAplicarFiltro
            // 
            this.btnAplicarFiltro.Location = new System.Drawing.Point(487, 85);
            this.btnAplicarFiltro.Name = "btnAplicarFiltro";
            this.btnAplicarFiltro.Size = new System.Drawing.Size(75, 23);
            this.btnAplicarFiltro.TabIndex = 4;
            this.btnAplicarFiltro.Text = "Aplicar Filtro";
            this.btnAplicarFiltro.UseVisualStyleBackColor = true;
            this.btnAplicarFiltro.Click += new System.EventHandler(this.btnAplicarFiltro_Click);
            // 
            // btnCrearProcesoVenta
            // 
            this.btnCrearProcesoVenta.Location = new System.Drawing.Point(605, 128);
            this.btnCrearProcesoVenta.Name = "btnCrearProcesoVenta";
            this.btnCrearProcesoVenta.Size = new System.Drawing.Size(140, 23);
            this.btnCrearProcesoVenta.TabIndex = 5;
            this.btnCrearProcesoVenta.Text = "Publicar proceso de venta";
            this.btnCrearProcesoVenta.UseVisualStyleBackColor = true;
            this.btnCrearProcesoVenta.Click += new System.EventHandler(this.btnCrearProcesoVenta_Click);
            // 
            // dgvSalesProcesses
            // 
            this.dgvSalesProcesses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesProcesses.Location = new System.Drawing.Point(43, 162);
            this.dgvSalesProcesses.Name = "dgvSalesProcesses";
            this.dgvSalesProcesses.RowHeadersWidth = 51;
            this.dgvSalesProcesses.Size = new System.Drawing.Size(702, 254);
            this.dgvSalesProcesses.TabIndex = 6;
            this.dgvSalesProcesses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesProcesses_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Lista de todos los procesos de venta";
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(332, 434);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(140, 23);
            this.btnVolver.TabIndex = 8;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblCerrarSesion
            // 
            this.lblCerrarSesion.AutoSize = true;
            this.lblCerrarSesion.Location = new System.Drawing.Point(675, 34);
            this.lblCerrarSesion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCerrarSesion.Name = "lblCerrarSesion";
            this.lblCerrarSesion.Size = new System.Drawing.Size(70, 13);
            this.lblCerrarSesion.TabIndex = 14;
            this.lblCerrarSesion.TabStop = true;
            this.lblCerrarSesion.Text = "Cerrar Sesión";
            this.lblCerrarSesion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCerrarSesion_LinkClicked);
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.Location = new System.Drawing.Point(626, 9);
            this.lblBienvenido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(35, 13);
            this.lblBienvenido.TabIndex = 54;
            this.lblBienvenido.Text = "label2";
            // 
            // SalesProcesses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 469);
            this.Controls.Add(this.lblBienvenido);
            this.Controls.Add(this.lblCerrarSesion);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvSalesProcesses);
            this.Controls.Add(this.btnCrearProcesoVenta);
            this.Controls.Add(this.btnAplicarFiltro);
            this.Controls.Add(this.rbProcesosLocales);
            this.Controls.Add(this.rbProcesosExtranjeros);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label1);
            this.Name = "SalesProcesses";
            this.Text = "SalesProcesses";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesProcesses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.RadioButton rbProcesosExtranjeros;
        private System.Windows.Forms.RadioButton rbProcesosLocales;
        private System.Windows.Forms.Button btnAplicarFiltro;
        private System.Windows.Forms.Button btnCrearProcesoVenta;
        private System.Windows.Forms.DataGridView dgvSalesProcesses;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.LinkLabel lblCerrarSesion;
        private System.Windows.Forms.Label lblBienvenido;
    }
}