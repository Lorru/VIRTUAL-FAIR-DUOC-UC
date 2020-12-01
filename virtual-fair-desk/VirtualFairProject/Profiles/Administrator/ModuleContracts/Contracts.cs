using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualFairProject.Api.Integration;
using VirtualFairProject.Class;

namespace VirtualFairProject.Profiles.Administrator.ModuleContracts
{
    public partial class Contracts : Form
    {
        public Contracts()
        {
            InitializeComponent();

            LoadDgvContracts();

            var nameUser = Session.NameUser;
            var nameProfile = Session.NameProfile;

            lblBienvenido.Text = String.Concat("Bienvenido ", nameUser, " | ", nameProfile.ToUpper());
        }

        private void btnAgregarContrato_Click(object sender, EventArgs e)
        {
            var saveContracts = new SaveContract();
            saveContracts.Show();

            this.Close();
        }

        private void LoadDgvContracts() 
        {
            string token = Session.Token;

            var getAllContracts = VirtualFairIntegration.FindAllContracts(token);

            List<AdminApi> lstAllAuctions = new List<AdminApi>();

            dgvContracts.AutoGenerateColumns = false;

            if (getAllContracts.countRows != 0)
            {
                foreach (var item in getAllContracts.contracts)
                {
                    AdminApi allAuctionsObject = new AdminApi();
                    allAuctionsObject.id = Convert.ToInt32(item.id.ToString());
                    allAuctionsObject.fullName = item.user.fullName.ToString();
                    allAuctionsObject.totalWeight = item.user.profile.name.ToString();
                    allAuctionsObject.dateA = item.expirationDate;
                    allAuctionsObject.isPublic = item.isValid.ToString(); //isValid

                    if (allAuctionsObject.isPublic == "1")
                    {
                        allAuctionsObject.nameStatus = "Si"; //isValid Si 
                    }
                    else
                    {
                        allAuctionsObject.nameStatus = "No"; //isValid No
                    }
                    
                    lstAllAuctions.Add(allAuctionsObject);
                }

                dgvContracts.DataSource = lstAllAuctions;
            }

            string[] arrayString = new string[] { "id", "fullName", "totalWeight", "dateA", "nameStatus" };

            foreach (var item in arrayString)
            {
                DataGridViewTextBoxColumn dataGrid = new DataGridViewTextBoxColumn();

                dataGrid.DataPropertyName = item;
                if (item == "id")
                {
                    dataGrid.HeaderText = "ID";
                }
                else if (item == "fullName")
                {
                    dataGrid.HeaderText = "Nombre usuario";
                }
                else if (item == "totalWeight")
                {
                    dataGrid.HeaderText = "Rol usuario";
                }
                else if (item == "dateA")
                {
                    dataGrid.HeaderText = "Fecha expiración";
                }
                else if (item == "nameStatus")
                {
                    dataGrid.HeaderText = "Vigente";
                }

                dataGrid.Name = item;

                dgvContracts.Columns.Add(dataGrid);

            }

            DataGridViewButtonColumn verDetalles1 = new DataGridViewButtonColumn();

            verDetalles1.FlatStyle = FlatStyle.Popup;
            verDetalles1.HeaderText = "Ver Contrato";
            verDetalles1.Name = "Ver Contrato";
            verDetalles1.UseColumnTextForButtonValue = true;
            verDetalles1.Text = "Ver Contrato";

            verDetalles1.Width = 80;
            if (dgvContracts.Columns.Contains(verDetalles1.Name = "Ver Contrato"))
            {

            }
            else
            {
                dgvContracts.Columns.Add(verDetalles1);
            }

            
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

        private void dgvContracts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string token = Session.Token;

            if (e.ColumnIndex == 5)
            {
                dynamic contract = new System.Dynamic.ExpandoObject();
                
                int rowIndex = dgvContracts.CurrentCell.RowIndex;
                //Session.Edit = true;

                var purchaseRequest = dgvContracts.CurrentRow.DataBoundItem;
                AdminApi purRequest = (AdminApi)purchaseRequest;

                contract.id = Convert.ToInt32(purRequest.id);

                var findById = VirtualFairIntegration.FindContractById(token, contract);

                if (findById.statusCode == 200)
                {
                    if (findById.contract.contractPath != "{}" || findById.contract.contractPath != "")
                    {
                        //Descarga archivo
                        SaveFileDialog sfdArchive = new SaveFileDialog();

                        if (sfdArchive.ShowDialog() == DialogResult.OK) 
                        { 
                            using (WebClient client = new WebClient())
                            {
                                //client.DownloadFile(new Uri(findById.contract.contractPath.ToString()), sfdArchive.FileName);
                                // OR 
                                client.DownloadFileAsync(new Uri(findById.contract.contractPath.ToString()), sfdArchive.FileName);
                            }

                            string text = "Contrato descargado con éxito.";
                            string title = "Información";
                            MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        string text = "No existe archivo para descargar.";
                        string title = "Información";
                        MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {

                }
            }
        }
    }
}
