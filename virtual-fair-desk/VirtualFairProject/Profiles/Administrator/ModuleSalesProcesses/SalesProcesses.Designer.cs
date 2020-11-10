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
            this.cmbEstados = new System.Windows.Forms.ComboBox();
            this.rbProcesosExtranjeros = new System.Windows.Forms.RadioButton();
            this.rbProcesosLocales = new System.Windows.Forms.RadioButton();
            this.btnAplicarFiltro = new System.Windows.Forms.Button();
            this.btnCrearProcesoVenta = new System.Windows.Forms.Button();
            this.dgvSalesProcesses = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesProcesses)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Procesos de venta";
            // 
            // cmbEstados
            // 
            this.cmbEstados.FormattingEnabled = true;
            this.cmbEstados.Location = new System.Drawing.Point(57, 108);
            this.cmbEstados.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbEstados.Name = "cmbEstados";
            this.cmbEstados.Size = new System.Drawing.Size(160, 24);
            this.cmbEstados.TabIndex = 1;
            // 
            // rbProcesosExtranjeros
            // 
            this.rbProcesosExtranjeros.AutoSize = true;
            this.rbProcesosExtranjeros.Location = new System.Drawing.Point(251, 112);
            this.rbProcesosExtranjeros.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbProcesosExtranjeros.Name = "rbProcesosExtranjeros";
            this.rbProcesosExtranjeros.Size = new System.Drawing.Size(162, 21);
            this.rbProcesosExtranjeros.TabIndex = 2;
            this.rbProcesosExtranjeros.TabStop = true;
            this.rbProcesosExtranjeros.Text = "Procesos extranjeros";
            this.rbProcesosExtranjeros.UseVisualStyleBackColor = true;
            // 
            // rbProcesosLocales
            // 
            this.rbProcesosLocales.AutoSize = true;
            this.rbProcesosLocales.Location = new System.Drawing.Point(423, 113);
            this.rbProcesosLocales.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbProcesosLocales.Name = "rbProcesosLocales";
            this.rbProcesosLocales.Size = new System.Drawing.Size(136, 21);
            this.rbProcesosLocales.TabIndex = 3;
            this.rbProcesosLocales.TabStop = true;
            this.rbProcesosLocales.Text = "Procesos locales";
            this.rbProcesosLocales.UseVisualStyleBackColor = true;
            // 
            // btnAplicarFiltro
            // 
            this.btnAplicarFiltro.Location = new System.Drawing.Point(591, 105);
            this.btnAplicarFiltro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAplicarFiltro.Name = "btnAplicarFiltro";
            this.btnAplicarFiltro.Size = new System.Drawing.Size(100, 28);
            this.btnAplicarFiltro.TabIndex = 4;
            this.btnAplicarFiltro.Text = "Aplicar Filtro";
            this.btnAplicarFiltro.UseVisualStyleBackColor = true;
            // 
            // btnCrearProcesoVenta
            // 
            this.btnCrearProcesoVenta.Location = new System.Drawing.Point(844, 105);
            this.btnCrearProcesoVenta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCrearProcesoVenta.Name = "btnCrearProcesoVenta";
            this.btnCrearProcesoVenta.Size = new System.Drawing.Size(187, 28);
            this.btnCrearProcesoVenta.TabIndex = 5;
            this.btnCrearProcesoVenta.Text = "Crear proceso de venta";
            this.btnCrearProcesoVenta.UseVisualStyleBackColor = true;
            this.btnCrearProcesoVenta.Click += new System.EventHandler(this.btnCrearProcesoVenta_Click);
            // 
            // dgvSalesProcesses
            // 
            this.dgvSalesProcesses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesProcesses.Location = new System.Drawing.Point(57, 199);
            this.dgvSalesProcesses.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvSalesProcesses.Name = "dgvSalesProcesses";
            this.dgvSalesProcesses.RowHeadersWidth = 51;
            this.dgvSalesProcesses.Size = new System.Drawing.Size(936, 313);
            this.dgvSalesProcesses.TabIndex = 6;
            // 
            // SalesProcesses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.dgvSalesProcesses);
            this.Controls.Add(this.btnCrearProcesoVenta);
            this.Controls.Add(this.btnAplicarFiltro);
            this.Controls.Add(this.rbProcesosLocales);
            this.Controls.Add(this.rbProcesosExtranjeros);
            this.Controls.Add(this.cmbEstados);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SalesProcesses";
            this.Text = "SalesProcesses";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesProcesses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbEstados;
        private System.Windows.Forms.RadioButton rbProcesosExtranjeros;
        private System.Windows.Forms.RadioButton rbProcesosLocales;
        private System.Windows.Forms.Button btnAplicarFiltro;
        private System.Windows.Forms.Button btnCrearProcesoVenta;
        private System.Windows.Forms.DataGridView dgvSalesProcesses;
    }
}