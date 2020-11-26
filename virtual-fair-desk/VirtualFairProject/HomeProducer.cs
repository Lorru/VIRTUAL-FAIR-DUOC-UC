using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualFairProject.Class;
using VirtualFairProject.Profiles.Producer;

namespace VirtualFairProject
{
    public partial class HomeProducer : Form
    {
        public HomeProducer()
        {
            InitializeComponent();

            var nameUser = Session.NameUser;

            lblBienvenido.Text = String.Concat("Bienvenido ", nameUser);
        }

        private void procesosDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var procesosVenta = new SalesProcesses();
            procesosVenta.Show();
            this.Close();
        }

        private void lblCerrarSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            string text = "Has cerrado tu sesión";
            string title = "Información";
            MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

            var login = new Login();
            login.Show();

            this.Close();
        }
    }
}
