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
using VirtualFairProject.Profiles.Administrator;
using VirtualFairProject.Profiles.Administrator.ModuleAuctions;
using VirtualFairProject.Profiles.Administrator.ModuleContracts;
using VirtualFairProject.Profiles.Administrator.ModuleSalesProcesses;

namespace VirtualFairProject
{
    public partial class HomeAdmin : Form
    {
        public HomeAdmin()
        {
            InitializeComponent();

            var nameUser = Session.NameUser;
            var nameProfile = Session.NameProfile;

            lblBienvenido.Text = String.Concat("Bienvenido ", nameUser, " | ", nameProfile.ToUpper());
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var usuarios = new Users();
            usuarios.Show();
            this.Close();
        }

        private void procesosDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var salesProcesses = new SalesProcesses();
            salesProcesses.Show();
            this.Close();
        }

        private void subastasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var auctions = new Auctions();
            auctions.Show();
            this.Close();
        }

        private void contratosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var contracts = new Contracts();
            contracts.Show();
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
