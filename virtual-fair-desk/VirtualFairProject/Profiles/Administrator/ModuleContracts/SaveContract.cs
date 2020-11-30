using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        private void asdf() 
        {
            string token = Session.Token;

            //findByIdPurchaseRequestStatusInTwoNineAndExpirationDateGreatherThanNow
            //Servicio para obtener una lista de todos los productos de una solicitud de compra rechazado y que la fecha de expiración sea mayor que la fecha actual
            var purchaseRequestStatus = VirtualFairIntegration.FindByIdPurchaseRequestStatusInTwoNineAndExpirationDateGreatherThanNow(token);

            if (purchaseRequestStatus.countRows != 0)
            {
                List<AllUsers> lstProducts = new List<AllUsers>();

                foreach (var item in purchaseRequestStatus.purchaseRequestProducts)
                {
                    AllUsers cmb = new AllUsers();
                    cmb.id = Convert.ToInt32(item.id);
                    cmb.nameUser = Convert.ToInt32(item.product.id);
                    cmb.profileUser = item.product.name.ToString();
                    lstProducts.Add(cmb);
                }

                cmbUsers.DataSource = lstProducts;
                cmbUsers.ValueMember = "id";
                cmbUsers.DisplayMember = "nameUserProfileUser";
                cmbUsers.DropDownStyle = ComboBoxStyle.DropDownList;

            }
        }
        private void LoadUsers() 
        {
            string token = Session.Token;

            var allUsers = VirtualFairIntegration.GetFindAllUsers(token);

            if (allUsers.countRows != 0)
            {
                List<AllUsers> lstUsers = new List<AllUsers>();

                foreach (var item in allUsers.users)
                {
                    AllUsers cmb = new AllUsers();
                    cmb.id = Convert.ToInt32(item.id);
                    cmb.nameUser = item.fullName.ToString();
                    cmb.profileUser = item.profile.name.ToString();
                    lstUsers.Add(cmb);
                }

                cmbUsers.DataSource = lstUsers;
                cmbUsers.ValueMember = "id";
                cmbUsers.DisplayMember = "nameUserProfileUser";
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string token = Session.Token;

            dynamic contract = new System.Dynamic.ExpandoObject();
            contract.idUser = cmbUsers.SelectedValue;
            //contract.idUsers = Session.IdProfile;
            contract.expirationDate = Convert.ToDateTime(dtpFechaExpiracion.Value);
            contract.isValid = 1; //1 -0
            contract.contractPath = ""; //opcional 

            var saveContract = VirtualFairIntegration.CreateContract(token, contract);

            if (saveContract.statusCode == 201)
            {
                string text = saveContract.message;
                string title = "Información";
                MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

                var contracts = new Contracts();
                contracts.Show();

                this.Close();
            }
        }

        private void btnSearchContract_Click(object sender, EventArgs e)
        {
            int size = -1;
            DialogResult result = ofdContract.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = ofdContract.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    size = text.Length;
                }
                catch (IOException)
                {
                }
            }
            //Console.WriteLine(size); // <-- Shows file size in debugging mode.
            //Console.WriteLine(result); // <-- For debugging use.
        }
    }
}
