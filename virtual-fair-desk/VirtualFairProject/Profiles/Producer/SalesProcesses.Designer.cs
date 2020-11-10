namespace VirtualFairProject.Profiles.Producer
{
    partial class SalesProcesses
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
            this.rbLocalProcesses = new System.Windows.Forms.RadioButton();
            this.rbForeignProcesses = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvSP = new System.Windows.Forms.DataGridView();
            this.dgvSalesProcesses1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesProcesses1)).BeginInit();
            this.SuspendLayout();
            // 
            // rbLocalProcesses
            // 
            this.rbLocalProcesses.AutoSize = true;
            this.rbLocalProcesses.Location = new System.Drawing.Point(301, 106);
            this.rbLocalProcesses.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbLocalProcesses.Name = "rbLocalProcesses";
            this.rbLocalProcesses.Size = new System.Drawing.Size(141, 21);
            this.rbLocalProcesses.TabIndex = 6;
            this.rbLocalProcesses.TabStop = true;
            this.rbLocalProcesses.Text = "Procesos Locales";
            this.rbLocalProcesses.UseVisualStyleBackColor = true;
            this.rbLocalProcesses.CheckedChanged += new System.EventHandler(this.rbLocalProcesses_CheckedChanged);
            // 
            // rbForeignProcesses
            // 
            this.rbForeignProcesses.AutoSize = true;
            this.rbForeignProcesses.Location = new System.Drawing.Point(104, 106);
            this.rbForeignProcesses.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbForeignProcesses.Name = "rbForeignProcesses";
            this.rbForeignProcesses.Size = new System.Drawing.Size(163, 21);
            this.rbForeignProcesses.TabIndex = 5;
            this.rbForeignProcesses.TabStop = true;
            this.rbForeignProcesses.Text = "Procesos Extranjeros";
            this.rbForeignProcesses.UseVisualStyleBackColor = true;
            this.rbForeignProcesses.CheckedChanged += new System.EventHandler(this.rbForeignProcesses_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Procesos de venta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 154);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Participando";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 434);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Todos";
            // 
            // dgvSP
            // 
            this.dgvSP.AllowUserToAddRows = false;
            this.dgvSP.AllowUserToDeleteRows = false;
            this.dgvSP.AllowUserToOrderColumns = true;
            this.dgvSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSP.Location = new System.Drawing.Point(104, 187);
            this.dgvSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvSP.Name = "dgvSP";
            this.dgvSP.ReadOnly = true;
            this.dgvSP.RowHeadersWidth = 51;
            this.dgvSP.RowTemplate.Height = 24;
            this.dgvSP.Size = new System.Drawing.Size(761, 177);
            this.dgvSP.TabIndex = 11;
            // 
            // dgvSalesProcesses1
            // 
            this.dgvSalesProcesses1.AllowUserToAddRows = false;
            this.dgvSalesProcesses1.AllowUserToDeleteRows = false;
            this.dgvSalesProcesses1.AllowUserToOrderColumns = true;
            this.dgvSalesProcesses1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesProcesses1.Location = new System.Drawing.Point(104, 470);
            this.dgvSalesProcesses1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvSalesProcesses1.Name = "dgvSalesProcesses1";
            this.dgvSalesProcesses1.ReadOnly = true;
            this.dgvSalesProcesses1.RowHeadersWidth = 51;
            this.dgvSalesProcesses1.RowTemplate.Height = 24;
            this.dgvSalesProcesses1.Size = new System.Drawing.Size(761, 177);
            this.dgvSalesProcesses1.TabIndex = 12;
            // 
            // SalesProcesses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 768);
            this.Controls.Add(this.dgvSalesProcesses1);
            this.Controls.Add(this.dgvSP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rbLocalProcesses);
            this.Controls.Add(this.rbForeignProcesses);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SalesProcesses";
            this.Text = "SalesProcesses";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesProcesses1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton rbLocalProcesses;
        private System.Windows.Forms.RadioButton rbForeignProcesses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvSP;
        private System.Windows.Forms.DataGridView dgvSalesProcesses1;
    }
}