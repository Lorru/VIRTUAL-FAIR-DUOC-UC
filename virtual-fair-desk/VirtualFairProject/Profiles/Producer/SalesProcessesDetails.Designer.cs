﻿namespace VirtualFairProject.Profiles.Producer
{
    partial class SalesProcessesDetails
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
            this.label3 = new System.Windows.Forms.Label();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.btnDiscardParticipation = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dgParticipants = new System.Windows.Forms.DataGridView();
            this.lblCerrarSesion = new System.Windows.Forms.LinkLabel();
            this.btnVolver = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblFechaDecision = new System.Windows.Forms.Label();
            this.lblBienvenido = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgParticipants)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proceso de venta";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(441, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha decision:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 89);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Detalles";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.AllowUserToOrderColumns = true;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Location = new System.Drawing.Point(39, 127);
            this.dgvDetails.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowHeadersWidth = 51;
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.Size = new System.Drawing.Size(238, 170);
            this.dgvDetails.TabIndex = 3;
            this.dgvDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellContentClick);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(278, 343);
            this.btnSaveChanges.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(100, 24);
            this.btnSaveChanges.TabIndex = 5;
            this.btnSaveChanges.Text = "Guardar cambios";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // btnDiscardParticipation
            // 
            this.btnDiscardParticipation.Location = new System.Drawing.Point(495, 313);
            this.btnDiscardParticipation.Margin = new System.Windows.Forms.Padding(2);
            this.btnDiscardParticipation.Name = "btnDiscardParticipation";
            this.btnDiscardParticipation.Size = new System.Drawing.Size(127, 24);
            this.btnDiscardParticipation.TabIndex = 6;
            this.btnDiscardParticipation.Text = "Descartar participacion";
            this.btnDiscardParticipation.UseVisualStyleBackColor = true;
            this.btnDiscardParticipation.Click += new System.EventHandler(this.btnDiscardParticipation_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(291, 414);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Participantes";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // dgParticipants
            // 
            this.dgParticipants.AllowUserToAddRows = false;
            this.dgParticipants.AllowUserToDeleteRows = false;
            this.dgParticipants.AllowUserToOrderColumns = true;
            this.dgParticipants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgParticipants.Location = new System.Drawing.Point(140, 440);
            this.dgParticipants.Margin = new System.Windows.Forms.Padding(2);
            this.dgParticipants.Name = "dgParticipants";
            this.dgParticipants.ReadOnly = true;
            this.dgParticipants.RowHeadersWidth = 51;
            this.dgParticipants.RowTemplate.Height = 24;
            this.dgParticipants.Size = new System.Drawing.Size(383, 159);
            this.dgParticipants.TabIndex = 9;
            this.dgParticipants.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgParticipants_CellContentClick);
            // 
            // lblCerrarSesion
            // 
            this.lblCerrarSesion.AutoSize = true;
            this.lblCerrarSesion.Location = new System.Drawing.Point(552, 36);
            this.lblCerrarSesion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCerrarSesion.Name = "lblCerrarSesion";
            this.lblCerrarSesion.Size = new System.Drawing.Size(70, 13);
            this.lblCerrarSesion.TabIndex = 30;
            this.lblCerrarSesion.TabStop = true;
            this.lblCerrarSesion.Text = "Cerrar Sesión";
            this.lblCerrarSesion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCerrarSesion_LinkClicked);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(294, 617);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 31;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(359, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 208);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Participar";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(144, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "$ Valor por Kg";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Peso ofrecido Kg";
            // 
            // lblFechaDecision
            // 
            this.lblFechaDecision.AutoSize = true;
            this.lblFechaDecision.Location = new System.Drawing.Point(529, 54);
            this.lblFechaDecision.Name = "lblFechaDecision";
            this.lblFechaDecision.Size = new System.Drawing.Size(19, 13);
            this.lblFechaDecision.TabIndex = 33;
            this.lblFechaDecision.Text = "<>";
            this.lblFechaDecision.Click += new System.EventHandler(this.lblFechaDecision_Click);
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.Location = new System.Drawing.Point(488, 9);
            this.lblBienvenido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(35, 13);
            this.lblBienvenido.TabIndex = 54;
            this.lblBienvenido.Text = "label2";
            // 
            // SalesProcessesDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 652);
            this.Controls.Add(this.lblBienvenido);
            this.Controls.Add(this.lblFechaDecision);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.lblCerrarSesion);
            this.Controls.Add(this.dgParticipants);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnDiscardParticipation);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SalesProcessesDetails";
            this.Text = "Detalle Proceso de Venta";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgParticipants)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Button btnDiscardParticipation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgParticipants;
        private System.Windows.Forms.LinkLabel lblCerrarSesion;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblFechaDecision;
        private System.Windows.Forms.Label lblBienvenido;
    }
}