namespace VirtualFairProject.Profiles.Administrator.ModuleAuctions
{
    partial class Auctions
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnCrearSubasta = new System.Windows.Forms.Button();
            this.dgvAuctions = new System.Windows.Forms.DataGridView();
            this.btnBuscarSubasta = new System.Windows.Forms.Button();
            this.btnPublishAuctions = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblCerrarSesion = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuctions)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Subastas";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(40, 94);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(139, 20);
            this.textBox1.TabIndex = 1;
            // 
            // btnCrearSubasta
            // 
            this.btnCrearSubasta.Location = new System.Drawing.Point(633, 92);
            this.btnCrearSubasta.Name = "btnCrearSubasta";
            this.btnCrearSubasta.Size = new System.Drawing.Size(90, 23);
            this.btnCrearSubasta.TabIndex = 2;
            this.btnCrearSubasta.Text = "Crear Subasta";
            this.btnCrearSubasta.UseVisualStyleBackColor = true;
            this.btnCrearSubasta.Click += new System.EventHandler(this.btnCrearSubasta_Click);
            // 
            // dgvAuctions
            // 
            this.dgvAuctions.AllowUserToAddRows = false;
            this.dgvAuctions.AllowUserToDeleteRows = false;
            this.dgvAuctions.AllowUserToOrderColumns = true;
            this.dgvAuctions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAuctions.Location = new System.Drawing.Point(40, 156);
            this.dgvAuctions.Name = "dgvAuctions";
            this.dgvAuctions.ReadOnly = true;
            this.dgvAuctions.RowHeadersWidth = 51;
            this.dgvAuctions.Size = new System.Drawing.Size(683, 224);
            this.dgvAuctions.TabIndex = 3;
            // 
            // btnBuscarSubasta
            // 
            this.btnBuscarSubasta.Location = new System.Drawing.Point(210, 89);
            this.btnBuscarSubasta.Name = "btnBuscarSubasta";
            this.btnBuscarSubasta.Size = new System.Drawing.Size(90, 23);
            this.btnBuscarSubasta.TabIndex = 4;
            this.btnBuscarSubasta.Text = "Buscar Subasta";
            this.btnBuscarSubasta.UseVisualStyleBackColor = true;
            this.btnBuscarSubasta.Click += new System.EventHandler(this.btnBuscarSubasta_Click);
            // 
            // btnPublishAuctions
            // 
            this.btnPublishAuctions.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPublishAuctions.Location = new System.Drawing.Point(510, 92);
            this.btnPublishAuctions.Name = "btnPublishAuctions";
            this.btnPublishAuctions.Size = new System.Drawing.Size(104, 23);
            this.btnPublishAuctions.TabIndex = 5;
            this.btnPublishAuctions.Text = "Publicar Subastas";
            this.btnPublishAuctions.UseVisualStyleBackColor = true;
            this.btnPublishAuctions.Click += new System.EventHandler(this.btnPublishAuctions_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnVolver.Location = new System.Drawing.Point(333, 396);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(104, 23);
            this.btnVolver.TabIndex = 6;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblCerrarSesion
            // 
            this.lblCerrarSesion.AutoSize = true;
            this.lblCerrarSesion.Location = new System.Drawing.Point(653, 18);
            this.lblCerrarSesion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCerrarSesion.Name = "lblCerrarSesion";
            this.lblCerrarSesion.Size = new System.Drawing.Size(70, 13);
            this.lblCerrarSesion.TabIndex = 7;
            this.lblCerrarSesion.TabStop = true;
            this.lblCerrarSesion.Text = "Cerrar Sesión";
            this.lblCerrarSesion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCerrarSesion_LinkClicked);
            // 
            // Auctions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCerrarSesion);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnPublishAuctions);
            this.Controls.Add(this.btnBuscarSubasta);
            this.Controls.Add(this.dgvAuctions);
            this.Controls.Add(this.btnCrearSubasta);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Auctions";
            this.Text = "Auctions";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuctions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnCrearSubasta;
        private System.Windows.Forms.DataGridView dgvAuctions;
        private System.Windows.Forms.Button btnBuscarSubasta;
        private System.Windows.Forms.Button btnPublishAuctions;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.LinkLabel lblCerrarSesion;
    }
}