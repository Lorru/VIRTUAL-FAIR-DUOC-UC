namespace VirtualFairProject.Profiles.ExternalCustomer
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
            ((System.ComponentModel.ISupportInitialize)(this.nudPesoKg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbProducts
            // 
            this.cmbProducts.FormattingEnabled = true;
            this.cmbProducts.Location = new System.Drawing.Point(93, 134);
            this.cmbProducts.Margin = new System.Windows.Forms.Padding(4);
            this.cmbProducts.Name = "cmbProducts";
            this.cmbProducts.Size = new System.Drawing.Size(160, 24);
            this.cmbProducts.TabIndex = 11;
            // 
            // lblNuevaSolicituCompra
            // 
            this.lblNuevaSolicituCompra.AutoSize = true;
            this.lblNuevaSolicituCompra.Location = new System.Drawing.Point(90, 48);
            this.lblNuevaSolicituCompra.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNuevaSolicituCompra.Name = "lblNuevaSolicituCompra";
            this.lblNuevaSolicituCompra.Size = new System.Drawing.Size(179, 17);
            this.lblNuevaSolicituCompra.TabIndex = 12;
            this.lblNuevaSolicituCompra.Text = "Nueva Solicitud de Compra";
            // 
            // nudPesoKg
            // 
            this.nudPesoKg.Location = new System.Drawing.Point(328, 136);
            this.nudPesoKg.Margin = new System.Windows.Forms.Padding(4);
            this.nudPesoKg.Name = "nudPesoKg";
            this.nudPesoKg.Size = new System.Drawing.Size(72, 22);
            this.nudPesoKg.TabIndex = 13;
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(472, 136);
            this.txtComentario.Margin = new System.Windows.Forms.Padding(4);
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(132, 22);
            this.txtComentario.TabIndex = 14;
            this.txtComentario.Text = "Comentario";
            // 
            // chkRequiereRefrigeracion
            // 
            this.chkRequiereRefrigeracion.AutoSize = true;
            this.chkRequiereRefrigeracion.Location = new System.Drawing.Point(661, 138);
            this.chkRequiereRefrigeracion.Margin = new System.Windows.Forms.Padding(4);
            this.chkRequiereRefrigeracion.Name = "chkRequiereRefrigeracion";
            this.chkRequiereRefrigeracion.Size = new System.Drawing.Size(172, 21);
            this.chkRequiereRefrigeracion.TabIndex = 15;
            this.chkRequiereRefrigeracion.Text = "Requiere refrigeración";
            this.chkRequiereRefrigeracion.UseVisualStyleBackColor = true;
            // 
            // btnAgregarSolicitud
            // 
            this.btnAgregarSolicitud.Location = new System.Drawing.Point(879, 130);
            this.btnAgregarSolicitud.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregarSolicitud.Name = "btnAgregarSolicitud";
            this.btnAgregarSolicitud.Size = new System.Drawing.Size(100, 28);
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
            this.dgvProducts1.Location = new System.Drawing.Point(96, 192);
            this.dgvProducts1.Name = "dgvProducts1";
            this.dgvProducts1.ReadOnly = true;
            this.dgvProducts1.RowHeadersWidth = 51;
            this.dgvProducts1.RowTemplate.Height = 24;
            this.dgvProducts1.Size = new System.Drawing.Size(862, 171);
            this.dgvProducts1.TabIndex = 17;
            this.dgvProducts1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(340, 395);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "* Fecha deseada de entrega:";
            // 
            // dtpFechaDeseadaEntrega
            // 
            this.dtpFechaDeseadaEntrega.Location = new System.Drawing.Point(540, 390);
            this.dtpFechaDeseadaEntrega.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFechaDeseadaEntrega.Name = "dtpFechaDeseadaEntrega";
            this.dtpFechaDeseadaEntrega.Size = new System.Drawing.Size(265, 22);
            this.dtpFechaDeseadaEntrega.TabIndex = 19;
            // 
            // btnRegistrarSolicitudCompra
            // 
            this.btnRegistrarSolicitudCompra.Location = new System.Drawing.Point(417, 454);
            this.btnRegistrarSolicitudCompra.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegistrarSolicitudCompra.Name = "btnRegistrarSolicitudCompra";
            this.btnRegistrarSolicitudCompra.Size = new System.Drawing.Size(245, 28);
            this.btnRegistrarSolicitudCompra.TabIndex = 20;
            this.btnRegistrarSolicitudCompra.Text = "Registrar solicitud de compra";
            this.btnRegistrarSolicitudCompra.UseVisualStyleBackColor = true;
            this.btnRegistrarSolicitudCompra.Click += new System.EventHandler(this.btnRegistrarSolicitudCompra_Click);
            // 
            // NewPurchaseRequestExternal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 555);
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
    }
}