namespace VirtualFairProject.Profiles.Administrator.ModuleAuctions
{
    partial class AuctionsDetails
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
            this.btnVolver = new System.Windows.Forms.Button();
            this.dgvCarrierWinnerAuctions = new System.Windows.Forms.DataGridView();
            this.lblWinners = new System.Windows.Forms.Label();
            this.lblCerrarSesion = new System.Windows.Forms.LinkLabel();
            this.lblBienvenido = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrierWinnerAuctions)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(325, 285);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 2;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // dgvCarrierWinnerAuctions
            // 
            this.dgvCarrierWinnerAuctions.AllowUserToAddRows = false;
            this.dgvCarrierWinnerAuctions.AllowUserToDeleteRows = false;
            this.dgvCarrierWinnerAuctions.AllowUserToOrderColumns = true;
            this.dgvCarrierWinnerAuctions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarrierWinnerAuctions.Location = new System.Drawing.Point(79, 114);
            this.dgvCarrierWinnerAuctions.Name = "dgvCarrierWinnerAuctions";
            this.dgvCarrierWinnerAuctions.ReadOnly = true;
            this.dgvCarrierWinnerAuctions.Size = new System.Drawing.Size(599, 150);
            this.dgvCarrierWinnerAuctions.TabIndex = 4;
            // 
            // lblWinners
            // 
            this.lblWinners.AutoSize = true;
            this.lblWinners.Location = new System.Drawing.Point(76, 71);
            this.lblWinners.Name = "lblWinners";
            this.lblWinners.Size = new System.Drawing.Size(170, 13);
            this.lblWinners.TabIndex = 3;
            this.lblWinners.Text = "Transportistas Ganadores Subasta";
            // 
            // lblCerrarSesion
            // 
            this.lblCerrarSesion.AutoSize = true;
            this.lblCerrarSesion.Location = new System.Drawing.Point(608, 59);
            this.lblCerrarSesion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCerrarSesion.Name = "lblCerrarSesion";
            this.lblCerrarSesion.Size = new System.Drawing.Size(70, 13);
            this.lblCerrarSesion.TabIndex = 8;
            this.lblCerrarSesion.TabStop = true;
            this.lblCerrarSesion.Text = "Cerrar Sesión";
            this.lblCerrarSesion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCerrarSesion_LinkClicked);
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.Location = new System.Drawing.Point(581, 18);
            this.lblBienvenido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(35, 13);
            this.lblBienvenido.TabIndex = 54;
            this.lblBienvenido.Text = "label2";
            // 
            // AuctionsDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 618);
            this.Controls.Add(this.lblBienvenido);
            this.Controls.Add(this.lblCerrarSesion);
            this.Controls.Add(this.dgvCarrierWinnerAuctions);
            this.Controls.Add(this.lblWinners);
            this.Controls.Add(this.btnVolver);
            this.Name = "AuctionsDetails";
            this.Text = "AuctionsDetails";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrierWinnerAuctions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DataGridView dgvCarrierWinnerAuctions;
        private System.Windows.Forms.Label lblWinners;
        private System.Windows.Forms.LinkLabel lblCerrarSesion;
        private System.Windows.Forms.Label lblBienvenido;
    }
}