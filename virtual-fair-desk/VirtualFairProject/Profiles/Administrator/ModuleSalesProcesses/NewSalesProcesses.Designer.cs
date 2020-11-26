namespace VirtualFairProject.Profiles.Administrator.ModuleSalesProcesses
{
    partial class NewSalesProcesses
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
            this.btnCerrar = new System.Windows.Forms.Button();
            this.dgvSalesProcessesPublic = new System.Windows.Forms.DataGridView();
            this.lblCerrarSesion = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesProcessesPublic)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Publicar proceso de venta";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(343, 414);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(56, 19);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // dgvSalesProcessesPublic
            // 
            this.dgvSalesProcessesPublic.AllowUserToAddRows = false;
            this.dgvSalesProcessesPublic.AllowUserToDeleteRows = false;
            this.dgvSalesProcessesPublic.AllowUserToOrderColumns = true;
            this.dgvSalesProcessesPublic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesProcessesPublic.Location = new System.Drawing.Point(44, 102);
            this.dgvSalesProcessesPublic.Name = "dgvSalesProcessesPublic";
            this.dgvSalesProcessesPublic.ReadOnly = true;
            this.dgvSalesProcessesPublic.RowHeadersWidth = 51;
            this.dgvSalesProcessesPublic.Size = new System.Drawing.Size(702, 254);
            this.dgvSalesProcessesPublic.TabIndex = 7;
            this.dgvSalesProcessesPublic.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesProcessesPublic_CellContentClick);
            // 
            // lblCerrarSesion
            // 
            this.lblCerrarSesion.AutoSize = true;
            this.lblCerrarSesion.Location = new System.Drawing.Point(676, 20);
            this.lblCerrarSesion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCerrarSesion.Name = "lblCerrarSesion";
            this.lblCerrarSesion.Size = new System.Drawing.Size(70, 13);
            this.lblCerrarSesion.TabIndex = 13;
            this.lblCerrarSesion.TabStop = true;
            this.lblCerrarSesion.Text = "Cerrar Sesión";
            this.lblCerrarSesion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCerrarSesion_LinkClicked);
            // 
            // NewSalesProcesses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 525);
            this.Controls.Add(this.lblCerrarSesion);
            this.Controls.Add(this.dgvSalesProcessesPublic);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "NewSalesProcesses";
            this.Text = "NewSalesProcesses";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesProcessesPublic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridView dgvSalesProcessesPublic;
        private System.Windows.Forms.LinkLabel lblCerrarSesion;
    }
}