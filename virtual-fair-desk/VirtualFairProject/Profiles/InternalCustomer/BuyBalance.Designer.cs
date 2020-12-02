namespace VirtualFairProject.Profiles.InternalCustomer
{
    partial class BuyBalance
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
            this.lblCerrarSesion = new System.Windows.Forms.LinkLabel();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.cmbProducts = new System.Windows.Forms.ComboBox();
            this.btnRegistrarSolicitudCompra = new System.Windows.Forms.Button();
            this.dtpFechaDeseadaEntrega = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAgregarSolicitud = new System.Windows.Forms.Button();
            this.chkRequiereRefrigeracion = new System.Windows.Forms.CheckBox();
            this.nudPesoKg = new System.Windows.Forms.NumericUpDown();
            this.lblNuevaSolicituCompra = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblBienvenido = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPesoKg)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCerrarSesion
            // 
            this.lblCerrarSesion.AutoSize = true;
            this.lblCerrarSesion.Location = new System.Drawing.Point(755, 62);
            this.lblCerrarSesion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCerrarSesion.Name = "lblCerrarSesion";
            this.lblCerrarSesion.Size = new System.Drawing.Size(70, 13);
            this.lblCerrarSesion.TabIndex = 27;
            this.lblCerrarSesion.TabStop = true;
            this.lblCerrarSesion.Text = "Cerrar Sesión";
            this.lblCerrarSesion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCerrarSesion_LinkClicked);
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AllowUserToOrderColumns = true;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(125, 228);
            this.dgvProducts.Margin = new System.Windows.Forms.Padding(2);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersWidth = 51;
            this.dgvProducts.RowTemplate.Height = 24;
            this.dgvProducts.Size = new System.Drawing.Size(646, 139);
            this.dgvProducts.TabIndex = 37;
            this.dgvProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellContentClick);
            // 
            // cmbProducts
            // 
            this.cmbProducts.FormattingEnabled = true;
            this.cmbProducts.Location = new System.Drawing.Point(125, 183);
            this.cmbProducts.Name = "cmbProducts";
            this.cmbProducts.Size = new System.Drawing.Size(185, 21);
            this.cmbProducts.TabIndex = 36;
            // 
            // btnRegistrarSolicitudCompra
            // 
            this.btnRegistrarSolicitudCompra.Location = new System.Drawing.Point(401, 476);
            this.btnRegistrarSolicitudCompra.Name = "btnRegistrarSolicitudCompra";
            this.btnRegistrarSolicitudCompra.Size = new System.Drawing.Size(184, 23);
            this.btnRegistrarSolicitudCompra.TabIndex = 35;
            this.btnRegistrarSolicitudCompra.Text = "Enviar solicitud de compra";
            this.btnRegistrarSolicitudCompra.UseVisualStyleBackColor = true;
            this.btnRegistrarSolicitudCompra.Click += new System.EventHandler(this.btnRegistrarSolicitudCompra_Click);
            // 
            // dtpFechaDeseadaEntrega
            // 
            this.dtpFechaDeseadaEntrega.Location = new System.Drawing.Point(456, 428);
            this.dtpFechaDeseadaEntrega.Name = "dtpFechaDeseadaEntrega";
            this.dtpFechaDeseadaEntrega.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaDeseadaEntrega.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(291, 434);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "* Fecha deseada de entrega:";
            // 
            // btnAgregarSolicitud
            // 
            this.btnAgregarSolicitud.Location = new System.Drawing.Point(696, 185);
            this.btnAgregarSolicitud.Name = "btnAgregarSolicitud";
            this.btnAgregarSolicitud.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarSolicitud.TabIndex = 32;
            this.btnAgregarSolicitud.Text = "Agregar";
            this.btnAgregarSolicitud.UseVisualStyleBackColor = true;
            this.btnAgregarSolicitud.Click += new System.EventHandler(this.btnAgregarSolicitud_Click);
            // 
            // chkRequiereRefrigeracion
            // 
            this.chkRequiereRefrigeracion.AutoSize = true;
            this.chkRequiereRefrigeracion.Location = new System.Drawing.Point(516, 186);
            this.chkRequiereRefrigeracion.Name = "chkRequiereRefrigeracion";
            this.chkRequiereRefrigeracion.Size = new System.Drawing.Size(130, 17);
            this.chkRequiereRefrigeracion.TabIndex = 31;
            this.chkRequiereRefrigeracion.Text = "Requiere refrigeración";
            this.chkRequiereRefrigeracion.UseVisualStyleBackColor = true;
            // 
            // nudPesoKg
            // 
            this.nudPesoKg.Location = new System.Drawing.Point(401, 185);
            this.nudPesoKg.Name = "nudPesoKg";
            this.nudPesoKg.Size = new System.Drawing.Size(54, 20);
            this.nudPesoKg.TabIndex = 29;
            // 
            // lblNuevaSolicituCompra
            // 
            this.lblNuevaSolicituCompra.AutoSize = true;
            this.lblNuevaSolicituCompra.Location = new System.Drawing.Point(122, 108);
            this.lblNuevaSolicituCompra.Name = "lblNuevaSolicituCompra";
            this.lblNuevaSolicituCompra.Size = new System.Drawing.Size(76, 13);
            this.lblNuevaSolicituCompra.TabIndex = 28;
            this.lblNuevaSolicituCompra.Text = "Comprar Saldo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Producto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(418, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Kg";
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(401, 544);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(95, 23);
            this.btnVolver.TabIndex = 40;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.Location = new System.Drawing.Point(693, 25);
            this.lblBienvenido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(35, 13);
            this.lblBienvenido.TabIndex = 54;
            this.lblBienvenido.Text = "label2";
            // 
            // BuyBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 618);
            this.Controls.Add(this.lblBienvenido);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.cmbProducts);
            this.Controls.Add(this.btnRegistrarSolicitudCompra);
            this.Controls.Add(this.dtpFechaDeseadaEntrega);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAgregarSolicitud);
            this.Controls.Add(this.chkRequiereRefrigeracion);
            this.Controls.Add(this.nudPesoKg);
            this.Controls.Add(this.lblNuevaSolicituCompra);
            this.Controls.Add(this.lblCerrarSesion);
            this.Name = "BuyBalance";
            this.Text = "BuyBalance";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPesoKg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lblCerrarSesion;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.ComboBox cmbProducts;
        private System.Windows.Forms.Button btnRegistrarSolicitudCompra;
        private System.Windows.Forms.DateTimePicker dtpFechaDeseadaEntrega;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAgregarSolicitud;
        private System.Windows.Forms.CheckBox chkRequiereRefrigeracion;
        private System.Windows.Forms.NumericUpDown nudPesoKg;
        private System.Windows.Forms.Label lblNuevaSolicituCompra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblBienvenido;
    }
}