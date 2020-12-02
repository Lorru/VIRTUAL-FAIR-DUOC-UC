namespace VirtualFairProject.Profiles.ExternalCustomer
{
    partial class PurchaseRequestExternal
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
            this.dgvPurchaseRequest = new System.Windows.Forms.DataGridView();
            this.btnNewRequest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblCerrarSesion = new System.Windows.Forms.LinkLabel();
            this.btnComprarSaldo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseRequest)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPurchaseRequest
            // 
            this.dgvPurchaseRequest.AllowUserToAddRows = false;
            this.dgvPurchaseRequest.AllowUserToDeleteRows = false;
            this.dgvPurchaseRequest.AllowUserToOrderColumns = true;
            this.dgvPurchaseRequest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchaseRequest.Location = new System.Drawing.Point(31, 165);
            this.dgvPurchaseRequest.Name = "dgvPurchaseRequest";
            this.dgvPurchaseRequest.ReadOnly = true;
            this.dgvPurchaseRequest.RowHeadersWidth = 51;
            this.dgvPurchaseRequest.Size = new System.Drawing.Size(694, 232);
            this.dgvPurchaseRequest.TabIndex = 9;
            this.dgvPurchaseRequest.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPurchaseRequest_CellContentClick);
            // 
            // btnNewRequest
            // 
            this.btnNewRequest.Location = new System.Drawing.Point(431, 111);
            this.btnNewRequest.Name = "btnNewRequest";
            this.btnNewRequest.Size = new System.Drawing.Size(116, 32);
            this.btnNewRequest.TabIndex = 10;
            this.btnNewRequest.Text = "Nueva Solicitud";
            this.btnNewRequest.UseVisualStyleBackColor = true;
            this.btnNewRequest.Click += new System.EventHandler(this.btnNewRequest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Solicitudes de compras";
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(333, 418);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 12;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblCerrarSesion
            // 
            this.lblCerrarSesion.AutoSize = true;
            this.lblCerrarSesion.Location = new System.Drawing.Point(655, 30);
            this.lblCerrarSesion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCerrarSesion.Name = "lblCerrarSesion";
            this.lblCerrarSesion.Size = new System.Drawing.Size(70, 13);
            this.lblCerrarSesion.TabIndex = 25;
            this.lblCerrarSesion.TabStop = true;
            this.lblCerrarSesion.Text = "Cerrar Sesión";
            this.lblCerrarSesion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCerrarSesion_LinkClicked);
            // 
            // btnComprarSaldo
            // 
            this.btnComprarSaldo.Location = new System.Drawing.Point(272, 111);
            this.btnComprarSaldo.Name = "btnComprarSaldo";
            this.btnComprarSaldo.Size = new System.Drawing.Size(116, 32);
            this.btnComprarSaldo.TabIndex = 29;
            this.btnComprarSaldo.Text = "Comprar Saldo";
            this.btnComprarSaldo.UseVisualStyleBackColor = true;
            this.btnComprarSaldo.Click += new System.EventHandler(this.btnComprarSaldo_Click);
            // 
            // PurchaseRequestExternal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 453);
            this.Controls.Add(this.btnComprarSaldo);
            this.Controls.Add(this.lblCerrarSesion);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNewRequest);
            this.Controls.Add(this.dgvPurchaseRequest);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PurchaseRequestExternal";
            this.Text = "PurchaseRequestExternal";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseRequest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPurchaseRequest;
        private System.Windows.Forms.Button btnNewRequest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.LinkLabel lblCerrarSesion;
        private System.Windows.Forms.Button btnComprarSaldo;
    }
}