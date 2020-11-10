namespace VirtualFairProject.Profiles.Client
{
    partial class PurchaseRequest
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
            this.btnNewRequest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPurchaseRequest = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseRequest)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNewRequest
            // 
            this.btnNewRequest.Location = new System.Drawing.Point(420, 120);
            this.btnNewRequest.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewRequest.Name = "btnNewRequest";
            this.btnNewRequest.Size = new System.Drawing.Size(155, 39);
            this.btnNewRequest.TabIndex = 6;
            this.btnNewRequest.Text = "Nueva Solicitud";
            this.btnNewRequest.UseVisualStyleBackColor = true;
            this.btnNewRequest.Click += new System.EventHandler(this.btnNewRequest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Solicitudes de compras";
            // 
            // dgvPurchaseRequest
            // 
            this.dgvPurchaseRequest.AllowUserToAddRows = false;
            this.dgvPurchaseRequest.AllowUserToDeleteRows = false;
            this.dgvPurchaseRequest.AllowUserToOrderColumns = true;
            this.dgvPurchaseRequest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchaseRequest.Location = new System.Drawing.Point(40, 192);
            this.dgvPurchaseRequest.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPurchaseRequest.Name = "dgvPurchaseRequest";
            this.dgvPurchaseRequest.ReadOnly = true;
            this.dgvPurchaseRequest.RowHeadersWidth = 51;
            this.dgvPurchaseRequest.Size = new System.Drawing.Size(926, 286);
            this.dgvPurchaseRequest.TabIndex = 8;
            this.dgvPurchaseRequest.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPurchaseRequest_CellContentClick);
            // 
            // PurchaseRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.dgvPurchaseRequest);
            this.Controls.Add(this.btnNewRequest);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PurchaseRequest";
            this.Text = "PurchaseRequest";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseRequest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnNewRequest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPurchaseRequest;
    }
}