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

namespace VirtualFairProject.Profiles.Administrator.ModuleAuctions
{
    public partial class Auctions : Form
    {
        public Auctions()
        {
            InitializeComponent();

            LoadAllAuctions();

            var nameUser = Session.NameUser;
            var nameProfile = Session.NameProfile;

            lblBienvenido.Text = String.Concat("Bienvenido ", nameUser, " | ", nameProfile.ToUpper());
        }

        private void btnBuscarSubasta_Click(object sender, EventArgs e)
        {

        }

        private void btnCrearSubasta_Click(object sender, EventArgs e)
        {
            var createAuctions = new CreateAuctions();
            createAuctions.Show();

            this.Close();
        }

        private void LoadAllAuctions() 
        {
            string token = Session.Token;

            var allAuctions = VirtualFairIntegration.GetFindAllAuctionsAdmin(token);

            List<AdminApi> lstAllAuctions = new List<AdminApi>();

            dgvAuctions.AutoGenerateColumns = false;

            if (allAuctions.countRows != 0)
            {
                foreach (var item in allAuctions.transportAuctions)
                {
                    AdminApi allAuctionsObject = new AdminApi();
                    allAuctionsObject.id = Convert.ToInt32(item.id.ToString());
                    allAuctionsObject.idProfile = Convert.ToInt32(item.purchaseRequest.id);
                    allAuctionsObject.fullName = item.purchaseRequest.client.fullName.ToString();
                    allAuctionsObject.totalWeight = item.purchaseRequest.totalWeight.ToString();
                    allAuctionsObject.dateA = item.desiredDate;
                    allAuctionsObject.nameStatus = item.purchaseRequest.purchaseRequestStatus.name.ToString(); //STATUS
                    allAuctionsObject.isPublic = item.isPublic.ToString();
                    lstAllAuctions.Add(allAuctionsObject);
                }

                dgvAuctions.DataSource = lstAllAuctions;
            }

            string[] arrayString = new string[] { "id", "idProfile","fullName", "totalWeight", "dateA", "nameStatus" };

            foreach (var item in arrayString)
            {
                DataGridViewTextBoxColumn dataGrid = new DataGridViewTextBoxColumn();

                dataGrid.DataPropertyName = item;
                if (item == "id")
                {
                    dataGrid.HeaderText = "ID";
                }
                if (item == "idProfile")
                {
                    dataGrid.HeaderText = "ID Venta";
                }
                else if (item == "fullName")
                {
                    dataGrid.HeaderText = "Solicitado por";
                }
                else if (item == "totalWeight")
                {
                    dataGrid.HeaderText = "Peso Total Kg";
                }
                else if (item == "dateA")
                {
                    dataGrid.HeaderText = "Fecha Decisión";
                }
                else if (item == "nameStatus")
                {
                    dataGrid.HeaderText = "Estado";
                }

                dataGrid.Name = item;

                dgvAuctions.Columns.Add(dataGrid);

            }

            DataGridViewButtonColumn verDetalles1 = new DataGridViewButtonColumn();

            verDetalles1.FlatStyle = FlatStyle.Popup;
            verDetalles1.HeaderText = "Ver Detalle";
            verDetalles1.Name = "Ver Detalle";
            verDetalles1.UseColumnTextForButtonValue = true;
            verDetalles1.Text = "Ver Detalle";

            verDetalles1.Width = 80;
            if (dgvAuctions.Columns.Contains(verDetalles1.Name = "Ver Detalle"))
            {

            }
            else
            {
                dgvAuctions.Columns.Add(verDetalles1);
            }
        }

        private void btnPublishAuctions_Click(object sender, EventArgs e)
        {
            var updateAuctionsNotPublic = new UpdateAuctionsNotPublic();
            updateAuctionsNotPublic.Show();

            this.Close();
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

        private void dgvAuctions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                int rowIndex = dgvAuctions.CurrentCell.RowIndex;
                //Session.Edit = true;

                var purchaseRequest = dgvAuctions.CurrentRow.DataBoundItem;
                AdminApi purRequest = (AdminApi)purchaseRequest;

                Session.id = Convert.ToString(purRequest.id);

                var auctionsDetails = new AuctionsDetails();

                auctionsDetails.Show();

                this.Close();

            }
        }

        private void btnRemoveAuctions_Click(object sender, EventArgs e)
        {
            var remoteAuctions = new RemoveAuctionsPublish();
            remoteAuctions.Show();

            this.Close();
        }
    }
}
