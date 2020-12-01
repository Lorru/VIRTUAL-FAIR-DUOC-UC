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
    public partial class AuctionsDetails : Form
    {
        public AuctionsDetails()
        {
            InitializeComponent();
            LoadDgvCarrierWinnerAuctions();

            var nameUser = Session.NameUser;
            var nameProfile = Session.NameProfile;

            lblBienvenido.Text = String.Concat("Bienvenido ", nameUser, " | ", nameProfile.ToUpper());
        }

        private void LoadDgvCarrierWinnerAuctions()
        {
            string token = Session.Token;
            dynamic parameters = new System.Dynamic.ExpandoObject();
            parameters.idPurchaseRequest = Session.id;

            var carrierWinners = VirtualFairIntegration.GetParticipantByIdPurchaseRequest(token,parameters);

            List<AdminApi> lstAllAuctions = new List<AdminApi>();

            dgvCarrierWinnerAuctions.AutoGenerateColumns = false;

            if (carrierWinners.statusCode == 200)
            {
                //foreach (var item in carrierWinners.transportAuctionCarrier)
                //{
                    AdminApi allAuctionsObject = new AdminApi();
                    allAuctionsObject.id = Convert.ToInt32(carrierWinners.transportAuctionCarrier.id.ToString());
                    allAuctionsObject.fullName = carrierWinners.transportAuctionCarrier.carrier.fullName.ToString();
                    allAuctionsObject.price = carrierWinners.transportAuctionCarrier.price.ToString();
                    lstAllAuctions.Add(allAuctionsObject);
                //}

                dgvCarrierWinnerAuctions.DataSource = lstAllAuctions;
            }
            else if (carrierWinners.statusCode == 500)
            {
                lblWinners.Text = "No existen ganadores para esta subasta";
            }

            string[] arrayString = new string[] { "id", "fullName", "price" };

            foreach (var item in arrayString)
            {
                DataGridViewTextBoxColumn dataGrid = new DataGridViewTextBoxColumn();

                dataGrid.DataPropertyName = item;
                if (item == "id")
                {
                    dataGrid.HeaderText = "ID";
                }
                if (item == "fullName")
                {
                    dataGrid.HeaderText = "Nombre participante";
                }
                else if (item == "price")
                {
                    dataGrid.HeaderText = "Oferta";
                }

                dataGrid.Name = item;

                dgvCarrierWinnerAuctions.Columns.Add(dataGrid);

            }
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            var auctions = new Auctions();
            auctions.Show();

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
