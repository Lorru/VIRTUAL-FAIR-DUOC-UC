namespace VirtualFairProject.Profiles.Producer
{
    partial class SalesProcessesParticipatingDetails
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
            this.lblFechaDecision = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblCerrarSesion = new System.Windows.Forms.LinkLabel();
            this.dgvParticipants = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDiscardParticipation = new System.Windows.Forms.Button();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvParticipating = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParticipants)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParticipating)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFechaDecision
            // 
            this.lblFechaDecision.AutoSize = true;
            this.lblFechaDecision.Location = new System.Drawing.Point(596, 64);
            this.lblFechaDecision.Name = "lblFechaDecision";
            this.lblFechaDecision.Size = new System.Drawing.Size(21, 15);
            this.lblFechaDecision.TabIndex = 45;
            this.lblFechaDecision.Text = "<>";
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(359, 645);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 43;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblCerrarSesion
            // 
            this.lblCerrarSesion.AutoSize = true;
            this.lblCerrarSesion.Location = new System.Drawing.Point(617, 37);
            this.lblCerrarSesion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCerrarSesion.Name = "lblCerrarSesion";
            this.lblCerrarSesion.Size = new System.Drawing.Size(82, 15);
            this.lblCerrarSesion.TabIndex = 42;
            this.lblCerrarSesion.TabStop = true;
            this.lblCerrarSesion.Text = "Cerrar Sesión";
            // 
            // dgvParticipants
            // 
            this.dgvParticipants.AllowUserToAddRows = false;
            this.dgvParticipants.AllowUserToDeleteRows = false;
            this.dgvParticipants.AllowUserToOrderColumns = true;
            this.dgvParticipants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParticipants.Location = new System.Drawing.Point(265, 459);
            this.dgvParticipants.Margin = new System.Windows.Forms.Padding(2);
            this.dgvParticipants.Name = "dgvParticipants";
            this.dgvParticipants.ReadOnly = true;
            this.dgvParticipants.RowHeadersWidth = 51;
            this.dgvParticipants.RowTemplate.Height = 24;
            this.dgvParticipants.Size = new System.Drawing.Size(253, 159);
            this.dgvParticipants.TabIndex = 41;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(356, 432);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 15);
            this.label5.TabIndex = 40;
            this.label5.Text = "Participantes";
            // 
            // btnDiscardParticipation
            // 
            this.btnDiscardParticipation.Location = new System.Drawing.Point(521, 341);
            this.btnDiscardParticipation.Margin = new System.Windows.Forms.Padding(2);
            this.btnDiscardParticipation.Name = "btnDiscardParticipation";
            this.btnDiscardParticipation.Size = new System.Drawing.Size(127, 24);
            this.btnDiscardParticipation.TabIndex = 39;
            this.btnDiscardParticipation.Text = "Descartar participacion";
            this.btnDiscardParticipation.UseVisualStyleBackColor = true;
            this.btnDiscardParticipation.Click += new System.EventHandler(this.btnDiscardParticipation_Click);
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.AllowUserToOrderColumns = true;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Location = new System.Drawing.Point(104, 155);
            this.dgvDetails.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowHeadersWidth = 51;
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.Size = new System.Drawing.Size(238, 170);
            this.dgvDetails.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(102, 117);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 36;
            this.label3.Text = "Detalles";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(508, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 15);
            this.label2.TabIndex = 35;
            this.label2.Text = "Fecha decision:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 15);
            this.label1.TabIndex = 34;
            this.label1.Text = "Proceso de venta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(464, 117);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 15);
            this.label4.TabIndex = 46;
            this.label4.Text = "Participando";
            // 
            // dgvParticipating
            // 
            this.dgvParticipating.AllowUserToAddRows = false;
            this.dgvParticipating.AllowUserToDeleteRows = false;
            this.dgvParticipating.AllowUserToOrderColumns = true;
            this.dgvParticipating.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParticipating.Location = new System.Drawing.Point(461, 155);
            this.dgvParticipating.Margin = new System.Windows.Forms.Padding(2);
            this.dgvParticipating.Name = "dgvParticipating";
            this.dgvParticipating.ReadOnly = true;
            this.dgvParticipating.RowHeadersWidth = 51;
            this.dgvParticipating.RowTemplate.Height = 24;
            this.dgvParticipating.Size = new System.Drawing.Size(238, 170);
            this.dgvParticipating.TabIndex = 47;
            // 
            // SalesProcessesParticipatingDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 704);
            this.Controls.Add(this.dgvParticipating);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblFechaDecision);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.lblCerrarSesion);
            this.Controls.Add(this.dgvParticipants);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnDiscardParticipation);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SalesProcessesParticipatingDetails";
            this.Text = "SalesProcessesParticipatingDetails";
            ((System.ComponentModel.ISupportInitialize)(this.dgvParticipants)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParticipating)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFechaDecision;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.LinkLabel lblCerrarSesion;
        private System.Windows.Forms.DataGridView dgvParticipants;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDiscardParticipation;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvParticipating;
    }
}