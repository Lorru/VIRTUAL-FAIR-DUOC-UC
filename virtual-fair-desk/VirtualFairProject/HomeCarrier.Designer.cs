namespace VirtualFairProject
{
    partial class HomeCarrier
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.módulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subastasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblBienvenido = new System.Windows.Forms.Label();
            this.lblCerrarSesion = new System.Windows.Forms.LinkLabel();
            this.miPerfilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Home Transportista";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.módulosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // módulosToolStripMenuItem
            // 
            this.módulosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subastasToolStripMenuItem,
            this.miPerfilToolStripMenuItem});
            this.módulosToolStripMenuItem.Name = "módulosToolStripMenuItem";
            this.módulosToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.módulosToolStripMenuItem.Text = "Módulos";
            // 
            // subastasToolStripMenuItem
            // 
            this.subastasToolStripMenuItem.Name = "subastasToolStripMenuItem";
            this.subastasToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.subastasToolStripMenuItem.Text = "Subastas";
            this.subastasToolStripMenuItem.Click += new System.EventHandler(this.subastasToolStripMenuItem_Click);
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.Location = new System.Drawing.Point(608, 53);
            this.lblBienvenido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(41, 15);
            this.lblBienvenido.TabIndex = 6;
            this.lblBienvenido.Text = "label2";
            // 
            // lblCerrarSesion
            // 
            this.lblCerrarSesion.AutoSize = true;
            this.lblCerrarSesion.Location = new System.Drawing.Point(610, 88);
            this.lblCerrarSesion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCerrarSesion.Name = "lblCerrarSesion";
            this.lblCerrarSesion.Size = new System.Drawing.Size(82, 15);
            this.lblCerrarSesion.TabIndex = 7;
            this.lblCerrarSesion.TabStop = true;
            this.lblCerrarSesion.Text = "Cerrar Sesión";
            this.lblCerrarSesion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCerrarSesion_LinkClicked);
            // 
            // miPerfilToolStripMenuItem
            // 
            this.miPerfilToolStripMenuItem.Name = "miPerfilToolStripMenuItem";
            this.miPerfilToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.miPerfilToolStripMenuItem.Text = "Mi Perfil";
            this.miPerfilToolStripMenuItem.Click += new System.EventHandler(this.miPerfilToolStripMenuItem_Click);
            // 
            // HomeCarrier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCerrarSesion);
            this.Controls.Add(this.lblBienvenido);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "HomeCarrier";
            this.Text = "HomeCarrier";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem módulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subastasToolStripMenuItem;
        private System.Windows.Forms.Label lblBienvenido;
        private System.Windows.Forms.LinkLabel lblCerrarSesion;
        private System.Windows.Forms.ToolStripMenuItem miPerfilToolStripMenuItem;
    }
}