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
using VirtualFairProject.Profiles.ExternalCustomer;

namespace VirtualFairProject
{
    public partial class HomeExternalCustomer : Form
    {
        public HomeExternalCustomer()
        {
            InitializeComponent();

            var nameUser = Session.NameUser;
            var nameProfile = Session.NameProfile;

            lblBienvenido.Text = String.Concat("Bienvenido ", nameUser, " | ", nameProfile.ToUpper());
        }

        private void solicitudesDeCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var solicitudCompraExternal = new PurchaseRequestExternal();
            solicitudCompraExternal.Show();
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

        private void miPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myProfile = new MyProfile();
            myProfile.Show();

            this.Close();
        }
    }
}
