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
using VirtualFairProject.Profiles.Carrier;

namespace VirtualFairProject
{
    public partial class HomeCarrier : Form
    {
        public HomeCarrier()
        {
            InitializeComponent();

            var nameUser = Session.NameUser;

            lblBienvenido.Text = String.Concat("Bienvenido ", nameUser);
        }

        private void subastasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subastasTransportista = new CarrierAuctions();
            subastasTransportista.Show();
        }

        private void lblCerrarSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string text = "Has cerrado tu sesión";
            string title = "Información";
            MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

            var login = new Login();
            login.Show();

            this.Hide();
        }
    }
}
