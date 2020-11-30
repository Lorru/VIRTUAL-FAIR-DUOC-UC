namespace VirtualFairProject.Profiles.Administrator.ModuleContracts
{
    partial class SaveContract
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
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaExpiracion = new System.Windows.Forms.DateTimePicker();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.cmbUsers = new System.Windows.Forms.ComboBox();
            this.lblCerrarSesion = new System.Windows.Forms.LinkLabel();
            this.ofdContract = new System.Windows.Forms.OpenFileDialog();
            this.btnSearchContract = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(240, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha de expiración:";
            // 
            // dtpFechaExpiracion
            // 
            this.dtpFechaExpiracion.Location = new System.Drawing.Point(314, 274);
            this.dtpFechaExpiracion.Name = "dtpFechaExpiracion";
            this.dtpFechaExpiracion.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaExpiracion.TabIndex = 2;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(344, 339);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(439, 339);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cmbUsers
            // 
            this.cmbUsers.FormattingEnabled = true;
            this.cmbUsers.Location = new System.Drawing.Point(314, 226);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.Size = new System.Drawing.Size(200, 21);
            this.cmbUsers.TabIndex = 5;
            // 
            // lblCerrarSesion
            // 
            this.lblCerrarSesion.AutoSize = true;
            this.lblCerrarSesion.Location = new System.Drawing.Point(641, 39);
            this.lblCerrarSesion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCerrarSesion.Name = "lblCerrarSesion";
            this.lblCerrarSesion.Size = new System.Drawing.Size(82, 15);
            this.lblCerrarSesion.TabIndex = 11;
            this.lblCerrarSesion.TabStop = true;
            this.lblCerrarSesion.Text = "Cerrar Sesión";
            this.lblCerrarSesion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCerrarSesion_LinkClicked);
            // 
            // ofdContract
            // 
            this.ofdContract.FileName = "ofdContractFileName";
            // 
            // btnSearchContract
            // 
            this.btnSearchContract.Location = new System.Drawing.Point(302, 157);
            this.btnSearchContract.Name = "btnSearchContract";
            this.btnSearchContract.Size = new System.Drawing.Size(158, 23);
            this.btnSearchContract.TabIndex = 12;
            this.btnSearchContract.Text = "Buscar contrato";
            this.btnSearchContract.UseVisualStyleBackColor = true;
            this.btnSearchContract.Click += new System.EventHandler(this.btnSearchContract_Click);
            // 
            // SaveContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 486);
            this.Controls.Add(this.btnSearchContract);
            this.Controls.Add(this.lblCerrarSesion);
            this.Controls.Add(this.cmbUsers);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.dtpFechaExpiracion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SaveContract";
            this.Text = "SaveContract";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaExpiracion;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ComboBox cmbUsers;
        private System.Windows.Forms.LinkLabel lblCerrarSesion;
        private System.Windows.Forms.OpenFileDialog ofdContract;
        private System.Windows.Forms.Button btnSearchContract;
    }
}