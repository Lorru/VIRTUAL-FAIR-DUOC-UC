namespace VirtualFairProject.Profiles.ExternalCustomer
{
    partial class PurchaseRequestDetailsExternal
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
            this.lblNSolicitudCompra = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.dgvPurchaseRequestDetails = new System.Windows.Forms.DataGridView();
            this.lblDesiredDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRecibirEntrega = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseRequestDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNSolicitudCompra
            // 
            this.lblNSolicitudCompra.AutoSize = true;
            this.lblNSolicitudCompra.Location = new System.Drawing.Point(227, 62);
            this.lblNSolicitudCompra.Name = "lblNSolicitudCompra";
            this.lblNSolicitudCompra.Size = new System.Drawing.Size(46, 17);
            this.lblNSolicitudCompra.TabIndex = 3;
            this.lblNSolicitudCompra.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Solicitud de compra";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(754, 62);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(56, 17);
            this.lblEstado.TabIndex = 4;
            this.lblEstado.Text = "Estado:";
            // 
            // dgvPurchaseRequestDetails
            // 
            this.dgvPurchaseRequestDetails.AllowUserToAddRows = false;
            this.dgvPurchaseRequestDetails.AllowUserToDeleteRows = false;
            this.dgvPurchaseRequestDetails.AllowUserToOrderColumns = true;
            this.dgvPurchaseRequestDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchaseRequestDetails.Location = new System.Drawing.Point(73, 138);
            this.dgvPurchaseRequestDetails.Name = "dgvPurchaseRequestDetails";
            this.dgvPurchaseRequestDetails.ReadOnly = true;
            this.dgvPurchaseRequestDetails.RowHeadersWidth = 51;
            this.dgvPurchaseRequestDetails.RowTemplate.Height = 24;
            this.dgvPurchaseRequestDetails.Size = new System.Drawing.Size(797, 220);
            this.dgvPurchaseRequestDetails.TabIndex = 5;
            // 
            // lblDesiredDate
            // 
            this.lblDesiredDate.AutoSize = true;
            this.lblDesiredDate.Location = new System.Drawing.Point(70, 414);
            this.lblDesiredDate.Name = "lblDesiredDate";
            this.lblDesiredDate.Size = new System.Drawing.Size(167, 17);
            this.lblDesiredDate.TabIndex = 6;
            this.lblDesiredDate.Text = "Fecha desea de entrega:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(400, 414);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Fecha desea de entrega:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(726, 414);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Total a pagar: $";
            // 
            // btnRecibirEntrega
            // 
            this.btnRecibirEntrega.Location = new System.Drawing.Point(341, 465);
            this.btnRecibirEntrega.Name = "btnRecibirEntrega";
            this.btnRecibirEntrega.Size = new System.Drawing.Size(280, 29);
            this.btnRecibirEntrega.TabIndex = 9;
            this.btnRecibirEntrega.Text = "Recibir entrega y finalizar proceso";
            this.btnRecibirEntrega.UseVisualStyleBackColor = true;
            this.btnRecibirEntrega.Click += new System.EventHandler(this.btnRecibirEntrega_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(412, 513);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(122, 17);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Rechazar entrega";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // PurchaseRequestDetailsExternal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 571);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnRecibirEntrega);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblDesiredDate);
            this.Controls.Add(this.dgvPurchaseRequestDetails);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblNSolicitudCompra);
            this.Controls.Add(this.label1);
            this.Name = "PurchaseRequestDetailsExternal";
            this.Text = "PurchaseRequestDetailsExternal";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseRequestDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNSolicitudCompra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.DataGridView dgvPurchaseRequestDetails;
        private System.Windows.Forms.Label lblDesiredDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRecibirEntrega;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}