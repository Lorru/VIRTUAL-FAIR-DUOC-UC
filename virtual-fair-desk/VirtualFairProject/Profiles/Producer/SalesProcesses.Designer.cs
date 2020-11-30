namespace VirtualFairProject.Profiles.Producer
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
            this.rbLocalProcesses = new System.Windows.Forms.RadioButton();
            this.rbForeignProcesses = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvSP = new System.Windows.Forms.DataGridView();
            this.dgvAllSalesProcesses = new System.Windows.Forms.DataGridView();
            this.lblCerrarSesion = new System.Windows.Forms.LinkLabel();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllSalesProcesses)).BeginInit();
            this.SuspendLayout();
            // 
            // rbLocalProcesses
            // 
            this.rbLocalProcesses.AutoSize = true;
            this.rbLocalProcesses.Location = new System.Drawing.Point(78, 84);
            this.rbLocalProcesses.Name = "rbLocalProcesses";
            this.rbLocalProcesses.Size = new System.Drawing.Size(109, 17);
            this.rbLocalProcesses.TabIndex = 6;
            this.rbLocalProcesses.TabStop = true;
            this.rbLocalProcesses.Text = "Procesos Locales";
            this.rbLocalProcesses.UseVisualStyleBackColor = true;
            this.rbLocalProcesses.CheckedChanged += new System.EventHandler(this.rbLocalProcesses_CheckedChanged);
            // 
            // rbForeignProcesses
            // 
            this.rbForeignProcesses.AutoSize = true;
            this.rbForeignProcesses.Location = new System.Drawing.Point(209, 84);
            this.rbForeignProcesses.Name = "rbForeignProcesses";
            this.rbForeignProcesses.Size = new System.Drawing.Size(124, 17);
            this.rbForeignProcesses.TabIndex = 5;
            this.rbForeignProcesses.TabStop = true;
            this.rbForeignProcesses.Text = "Procesos Extranjeros";
            this.rbForeignProcesses.UseVisualStyleBackColor = true;
            this.rbForeignProcesses.CheckedChanged += new System.EventHandler(this.rbForeignProcesses_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Procesos de venta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Participando";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 353);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Todos";
            // 
            // dgvSP
            // 
            this.dgvSP.AllowUserToAddRows = false;
            this.dgvSP.AllowUserToDeleteRows = false;
            this.dgvSP.AllowUserToOrderColumns = true;
            this.dgvSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSP.Location = new System.Drawing.Point(78, 152);
            this.dgvSP.Margin = new System.Windows.Forms.Padding(2);
            this.dgvSP.Name = "dgvSP";
            this.dgvSP.ReadOnly = true;
            this.dgvSP.RowHeadersWidth = 51;
            this.dgvSP.RowTemplate.Height = 24;
            this.dgvSP.Size = new System.Drawing.Size(571, 144);
            this.dgvSP.TabIndex = 11;
            this.dgvSP.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSP_CellContentClick);
            // 
            // dgvAllSalesProcesses
            // 
            this.dgvAllSalesProcesses.AllowUserToAddRows = false;
            this.dgvAllSalesProcesses.AllowUserToDeleteRows = false;
            this.dgvAllSalesProcesses.AllowUserToOrderColumns = true;
            this.dgvAllSalesProcesses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllSalesProcesses.Location = new System.Drawing.Point(78, 382);
            this.dgvAllSalesProcesses.Margin = new System.Windows.Forms.Padding(2);
            this.dgvAllSalesProcesses.Name = "dgvAllSalesProcesses";
            this.dgvAllSalesProcesses.ReadOnly = true;
            this.dgvAllSalesProcesses.RowHeadersWidth = 51;
            this.dgvAllSalesProcesses.RowTemplate.Height = 24;
            this.dgvAllSalesProcesses.Size = new System.Drawing.Size(571, 144);
            this.dgvAllSalesProcesses.TabIndex = 12;
            this.dgvAllSalesProcesses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesProcesses1_CellContentClick);
            // 
            // lblCerrarSesion
            // 
            this.lblCerrarSesion.AutoSize = true;
            this.lblCerrarSesion.Location = new System.Drawing.Point(658, 18);
            this.lblCerrarSesion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCerrarSesion.Name = "lblCerrarSesion";
            this.lblCerrarSesion.Size = new System.Drawing.Size(70, 13);
            this.lblCerrarSesion.TabIndex = 29;
            this.lblCerrarSesion.TabStop = true;
            this.lblCerrarSesion.Text = "Cerrar Sesión";
            this.lblCerrarSesion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCerrarSesion_LinkClicked);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(372, 80);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 30;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(307, 550);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 31;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // SalesProcesses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 624);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.lblCerrarSesion);
            this.Controls.Add(this.dgvAllSalesProcesses);
            this.Controls.Add(this.dgvSP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rbLocalProcesses);
            this.Controls.Add(this.rbForeignProcesses);
            this.Controls.Add(this.label1);
            this.Name = "SalesProcesses";
            this.Text = "SalesProcesses";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllSalesProcesses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton rbLocalProcesses;
        private System.Windows.Forms.RadioButton rbForeignProcesses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvSP;
        private System.Windows.Forms.DataGridView dgvAllSalesProcesses;
        private System.Windows.Forms.LinkLabel lblCerrarSesion;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnVolver;
    }
}