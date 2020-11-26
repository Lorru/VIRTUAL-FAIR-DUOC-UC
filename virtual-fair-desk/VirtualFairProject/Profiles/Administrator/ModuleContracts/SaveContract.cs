using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualFairProject.Api.Integration;
using VirtualFairProject.Class;

namespace VirtualFairProject.Profiles.Administrator.ModuleContracts
{
    public partial class SaveContract : Form
    {
        public SaveContract()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            var contracts = new Contracts();
            contracts.Show();
        }


        private void LoadUsers() 
        {
            string token = Session.Token;

            var allUsers = VirtualFairIntegration.GetFindAllUsers(token);

            if (allUsers.countRows != 0)
            {
                cmbUsers.DataSource = allUsers.users;
                cmbUsers.ValueMember = "id";
                cmbUsers.DisplayMember = "fullName";
                //cmbUsers.DisplayMember = String.Concat("country","|", "fullName");
                
                cmbUsers.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            
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
