﻿namespace VirtualFairProject.Profiles.ExternalCustomer
{
    partial class NewPurchaseRequestExternal
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
            this.cmbProducts = new System.Windows.Forms.ComboBox();
            this.lblNuevaSolicituCompra = new System.Windows.Forms.Label();
            this.nudPesoKg = new System.Windows.Forms.NumericUpDown();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.chkRequiereRefrigeracion = new System.Windows.Forms.CheckBox();
            this.btnAgregarSolicitud = new System.Windows.Forms.Button();
            this.dgvProducts1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaDeseadaEntrega = new System.Windows.Forms.DateTimePicker();
            this.btnRegistrarSolicitudCompra = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblCerrarSesion = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.nudPesoKg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbProducts
            // 
            this.cmbProducts.FormattingEnabled = true;
            this.cmbProducts.Location = new System.Drawing.Point(70, 109);
            this.cmbProducts.Name = "cmbProducts";
            this.cmbProducts.Size = new System.Drawing.Size(121, 21);
            this.cmbProducts.TabIndex = 11;
            // 
            // lblNuevaSolicituCompra
            // 
            this.lblNuevaSolicituCompra.AutoSize = true;
            this.lblNuevaSolicituCompra.Location = new System.Drawing.Point(68, 39);
            this.lblNuevaSolicituCompra.Name = "lblNuevaSolicituCompra";
            this.lblNuevaSolicituCompra.Size = new System.Drawing.Size(136, 13);
            this.lblNuevaSolicituCompra.TabIndex = 12;
            this.lblNuevaSolicituCompra.Text = "Nueva Solicitud de Compra";
            // 
            // nudPesoKg
            // 
            this.nudPesoKg.Location = new System.Drawing.Point(246, 110);
            this.nudPesoKg.Name = "nudPesoKg";
            this.nudPesoKg.Size = new System.Drawing.Size(54, 20);
            this.nudPesoKg.TabIndex = 13;
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(354, 110);
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(100, 20);
            this.txtComentario.TabIndex = 14;
            this.txtComentario.Text = "Comentario";
            // 
            // chkRequiereRefrigeracion
            // 
            this.chkRequiereRefrigeracion.AutoSize = true;
            this.chkRequiereRefrigeracion.Location = new System.Drawing.Point(496, 112);
            this.chkRequiereRefrigeracion.Name = "chkRequiereRefrigeracion";
            this.chkRequiereRefrigeracion.Size = new System.Drawing.Size(130, 17);
            this.chkRequiereRefrigeracion.TabIndex = 15;
            this.chkRequiereRefrigeracion.Text = "Requiere refrigeración";
            this.chkRequiereRefrigeracion.UseVisualStyleBackColor = true;
            // 
            // btnAgregarSolicitud
            // 
            this.btnAgregarSolicitud.Location = new System.Drawing.Point(659, 106);
            this.btnAgregarSolicitud.Name = "btnAgregarSolicitud";
            this.btnAgregarSolicitud.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarSolicitud.TabIndex = 16;
            this.btnAgregarSolicitud.Text = "Agregar";
            this.btnAgregarSolicitud.UseVisualStyleBackColor = true;
            this.btnAgregarSolicitud.Click += new System.EventHandler(this.btnAgregarSolicitud_Click);
            // 
            // dgvProducts1
            // 
            this.dgvProducts1.AllowUserToAddRows = false;
            this.dgvProducts1.AllowUserToDeleteRows = false;
            this.dgvProducts1.AllowUserToOrderColumns = true;
            this.dgvProducts1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts1.Location = new System.Drawing.Point(72, 156);
            this.dgvProducts1.Margin = new System.Windows.Forms.Padding(2);
            this.dgvProducts1.Name = "dgvProducts1";
            this.dgvProducts1.ReadOnly = true;
            this.dgvProducts1.RowHeadersWidth = 51;
            this.dgvProducts1.RowTemplate.Height = 24;
            this.dgvProducts1.Size = new System.Drawing.Size(646, 139);
            this.dgvProducts1.TabIndex = 17;
            this.dgvProducts1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(255, 321);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "* Fecha deseada de entrega:";
            // 
            // dtpFechaDeseadaEntrega
            // 
            this.dtpFechaDeseadaEntrega.Location = new System.Drawing.Point(405, 317);
            this.dtpFechaDeseadaEntrega.Name = "dtpFechaDeseadaEntrega";
            this.dtpFechaDeseadaEntrega.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaDeseadaEntrega.TabIndex = 19;
            // 
            // btnRegistrarSolicitudCompra
            // 
            this.btnRegistrarSolicitudCompra.Location = new System.Drawing.Point(313, 369);
            this.btnRegistrarSolicitudCompra.Name = "btnRegistrarSolicitudCompra";
            this.btnRegistrarSolicitudCompra.Size = new System.Drawing.Size(184, 23);
            this.btnRegistrarSolicitudCompra.TabIndex = 20;
            this.btnRegistrarSolicitudCompra.Text = "Registrar solicitud de compra";
            this.btnRegistrarSolicitudCompra.UseVisualStyleBackColor = true;
            this.btnRegistrarSolicitudCompra.Click += new System.EventHandler(this.btnRegistrarSolicitudCompra_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(370, 416);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 21;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblCerrarSesion
            // 
            this.lblCerrarSesion.AutoSize = true;
            this.lblCerrarSesion.Location = new System.Drawing.Point(648, 23);
            this.lblCerrarSesion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCerrarSesion.Name = "lblCerrarSesion";
            this.lblCerrarSesion.Size = new System.Drawing.Size(70, 13);
            this.lblCerrarSesion.TabIndex = 23;
            this.lblCerrarSesion.TabStop = true;
            this.lblCerrarSesion.Text = "Cerrar Sesión";
            this.lblCerrarSesion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCerrarSesion_LinkClicked);
            // 
            // NewPurchaseRequestExternal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 451);
            this.Controls.Add(this.lblCerrarSesion);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnRegistrarSolicitudCompra);
            this.Controls.Add(this.dtpFechaDeseadaEntrega);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvProducts1);
            this.Controls.Add(this.btnAgregarSolicitud);
            this.Controls.Add(this.chkRequiereRefrigeracion);
            this.Controls.Add(this.txtComentario);
            this.Controls.Add(this.nudPesoKg);
            this.Controls.Add(this.lblNuevaSolicituCompra);
            this.Controls.Add(this.cmbProducts);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "NewPurchaseRequestExternal";
            this.Text = "NewPurchaseRequestExternal";
            ((System.ComponentModel.ISupportInitialize)(this.nudPesoKg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbProducts;
        private System.Windows.Forms.Label lblNuevaSolicituCompra;
        private System.Windows.Forms.NumericUpDown nudPesoKg;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.CheckBox chkRequiereRefrigeracion;
        private System.Windows.Forms.Button btnAgregarSolicitud;
        private System.Windows.Forms.DataGridView dgvProducts1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaDeseadaEntrega;
        private System.Windows.Forms.Button btnRegistrarSolicitudCompra;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.LinkLabel lblCerrarSesion;
    }
}