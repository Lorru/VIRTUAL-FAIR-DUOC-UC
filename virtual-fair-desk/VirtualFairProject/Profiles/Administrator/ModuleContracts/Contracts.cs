using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualFairProject.Profiles.Administrator.ModuleContracts
{
    public partial class Contracts : Form
    {
        public Contracts()
        {
            InitializeComponent();
        }

        private void btnAgregarContrato_Click(object sender, EventArgs e)
        {
            var saveContracts = new SaveContract();
            saveContracts.Show();

            this.Hide();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            var homeAdmin = new HomeAdmin();
            homeAdmin.Show();
            
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
