namespace VirtualFairProject.Profiles.Carrier
{
    partial class CarrierAuctions
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvAuctions = new System.Windows.Forms.DataGridView();
            this.dgvAllAuctions = new System.Windows.Forms.DataGridView();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblCerrarSesion = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuctions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllAuctions)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Subastas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Subastas Participando:";
            // 
            // dgvAuctions
            // 
            this.dgvAuctions.AllowUserToAddRows = false;
            this.dgvAuctions.AllowUserToDeleteRows = false;
            this.dgvAuctions.AllowUserToOrderColumns = true;
            this.dgvAuctions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAuctions.Location = new System.Drawing.Point(79, 54);
            this.dgvAuctions.Margin = new System.Windows.Forms.Padding(2);
            this.dgvAuctions.Name = "dgvAuctions";
            this.dgvAuctions.ReadOnly = true;
            this.dgvAuctions.RowHeadersWidth = 51;
            this.dgvAuctions.RowTemplate.Height = 24;
            this.dgvAuctions.Size = new System.Drawing.Size(655, 154);
            this.dgvAuctions.TabIndex = 8;
            // 
            // dgvAllAuctions
            // 
            this.dgvAllAuctions.AllowUserToAddRows = false;
            this.dgvAllAuctions.AllowUserToDeleteRows = false;
            this.dgvAllAuctions.AllowUserToOrderColumns = true;
            this.dgvAllAuctions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllAuctions.Location = new System.Drawing.Point(79, 265);
            this.dgvAllAuctions.Margin = new System.Windows.Forms.Padding(2);
            this.dgvAllAuctions.Name = "dgvAllAuctions";
            this.dgvAllAuctions.ReadOnly = true;
            this.dgvAllAuctions.RowHeadersWidth = 51;
            this.dgvAllAuctions.RowTemplate.Height = 24;
            this.dgvAllAuctions.Size = new System.Drawing.Size(655, 154);
            this.dgvAllAuctions.TabIndex = 9;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(350, 429);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 10;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblCerrarSesion
            // 
            this.lblCerrarSesion.AutoSize = true;
            this.lblCerrarSesion.Location = new System.Drawing.Point(664, 9);
            this.lblCerrarSesion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCerrarSesion.Name = "lblCerrarSesion";
            this.lblCerrarSesion.Size = new System.Drawing.Size(70, 13);
            this.lblCerrarSesion.TabIndex = 19;
            this.lblCerrarSesion.TabStop = true;
            this.lblCerrarSesion.Text = "Cerrar Sesión";
            this.lblCerrarSesion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCerrarSesion_LinkClicked);
            // 
            // CarrierAuctions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 464);
            this.Controls.Add(this.lblCerrarSesion);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.dgvAllAuctions);
            this.Controls.Add(this.dgvAuctions);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CarrierAuctions";
            this.Text = "CarrierAuctions";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuctions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllAuctions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvAuctions;
        private System.Windows.Forms.DataGridView dgvAllAuctions;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.LinkLabel lblCerrarSesion;
    }
}