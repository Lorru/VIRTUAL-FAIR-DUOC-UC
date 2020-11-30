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

namespace VirtualFairProject.Profiles.Carrier
{
    public partial class CarrierAuctions : Form
    {
        public CarrierAuctions()
        {
            InitializeComponent();

            LoadAuctions();
            LoadAuctionsPublish();
        }

        //Subastas públicas en las que está participando el transportista.
        private void LoadAuctions() 
        {
            string token = Session.Token;
            int idCarrier = Session.IdProfile;
            dynamic parameters = new System.Dynamic.ExpandoObject();
            //parameters.idPurchaseRequestType = 1;
            parameters.idCarrier = idCarrier;

            var findByIdCarrier = VirtualFairIntegration.FindByIdCarrierAndIsPublicEqualToOne(token, parameters);

            List<AdminApi> lstParticipating = new List<AdminApi>();

            dgvAuctions.AutoGenerateColumns = false;

            if (findByIdCarrier.countRows != 0)
            {
                foreach (var item in findByIdCarrier.transportAuctions)
                {
                    AdminApi users = new AdminApi();
                    //cambiar variables
                    users.id = Convert.ToInt32(item.id.ToString());
                    users.email = item.idPurchaseRequest.ToString();
                    users.dateA = item.desiredDate;
                    users.fullName = item.purchaseRequest.purchaseRequestStatus.name.ToString();
                    lstParticipating.Add(users);
                }

                dgvAuctions.DataSource = lstParticipating;
            }

            string[] arrayString = new string[] { "id", "email", "dateA", "fullName"};

            foreach (var item in arrayString)
            {
                DataGridViewTextBoxColumn dataGrid = new DataGridViewTextBoxColumn();

                dataGrid.DataPropertyName = item;
                if (item == "id")
                {
                    dataGrid.HeaderText = "ID";
                }
                else if (item == "email")
                {
                    dataGrid.HeaderText = "Id Venta";
                }
                else if (item == "dateA")
                {
                    dataGrid.HeaderText = "Fecha Decisión";
                }
                else if (item == "fullName")
                {
                    dataGrid.HeaderText = "Estado";
                }

                dataGrid.Name = item;

                dgvAuctions.Columns.Add(dataGrid);

            }


            DataGridViewButtonColumn verDetalles = new DataGridViewButtonColumn();

            verDetalles.FlatStyle = FlatStyle.Popup;
            verDetalles.HeaderText = "Ver Detalle";
            verDetalles.Name = "Ver Detalle";
            verDetalles.UseColumnTextForButtonValue = true;
            verDetalles.Text = "Ver Detalle";

            verDetalles.Width = 80;
            if (dgvAuctions.Columns.Contains(verDetalles.Name = "Ver Detalle"))
            {

            }
            else
            {
                dgvAuctions.Columns.Add(verDetalles);
            }

        }

        private void LoadAuctionsPublish() 
        {
            string token = Session.Token;
            int idCarrier = Session.IdProfile;
            dynamic parameters = new System.Dynamic.ExpandoObject();

            var findAuctionsPublish = VirtualFairIntegration.GetFindByIsPublicEqualToOneAdmin(token);

            List<AdminApi> lstParticipating = new List<AdminApi>();

            dgvAllAuctions.AutoGenerateColumns = false;

            if (findAuctionsPublish.countRows != 0)
            {
                foreach (var item in findAuctionsPublish.transportAuctions)
                {
                    AdminApi users = new AdminApi();
                    //cambiar variables
                    users.id = Convert.ToInt32(item.id.ToString());
                    users.email = item.idPurchaseRequest.ToString();
                    users.dateA = item.desiredDate;
                    users.city = item.purchaseRequest.purchaseRequestStatus.name.ToString();
                    lstParticipating.Add(users);
                }

                dgvAllAuctions.DataSource = lstParticipating;
            }

            string[] arrayString = new string[] { "id", "email", "dateA", "city" };

            foreach (var item in arrayString)
            {
                DataGridViewTextBoxColumn dataGrid = new DataGridViewTextBoxColumn();

                dataGrid.DataPropertyName = item;
                if (item == "id") //id
                {
                    dataGrid.HeaderText = "ID";
                }
                else if (item == "email") //idPurchaseRequest
                {
                    dataGrid.HeaderText = "Id Venta"; 
                }
                else if (item == "dateA") // desiredDate
                {
                    dataGrid.HeaderText = "Fecha Decisión";
                }
                else if (item == "city") //purchaseRequestStatus.name
                {
                    dataGrid.HeaderText = "Estado";
                }

                dataGrid.Name = item;

                dgvAllAuctions.Columns.Add(dataGrid);

            }


            DataGridViewButtonColumn verDetalles = new DataGridViewButtonColumn();

            verDetalles.FlatStyle = FlatStyle.Popup;
            verDetalles.HeaderText = "Ver Detalle";
            verDetalles.Name = "Ver Detalle";
            verDetalles.UseColumnTextForButtonValue = true;
            verDetalles.Text = "Ver Detalle";

            verDetalles.Width = 80;
            if (dgvAllAuctions.Columns.Contains(verDetalles.Name = "Ver Detalle"))
            {

            }
            else
            {
                dgvAllAuctions.Columns.Add(verDetalles);
            }

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            var homeCarrier = new HomeCarrier();
            homeCarrier.Show();
           
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

        private void dgvAllAuctions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                int rowIndex = dgvAllAuctions.CurrentCell.RowIndex;
                //Session.Edit = true;

                var purchaseRequest = dgvAllAuctions.CurrentRow.DataBoundItem;
                AdminApi purRequest = (AdminApi)purchaseRequest;
                //id venta = email

                Session.idTransportAuction = Convert.ToString(purRequest.id);

                var carrierDetailsAuctions = new CarrierDetailsAuctions();

                carrierDetailsAuctions.Show();

                this.Close();

            }
        }

        private void dgvAuctions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                int rowIndex = dgvAllAuctions.CurrentCell.RowIndex;
                //Session.Edit = true;

                var purchaseRequest = dgvAuctions.CurrentRow.DataBoundItem;
                AdminApi purRequest = (AdminApi)purchaseRequest;
                //id venta = email

                Session.idTransportAuction = Convert.ToString(purRequest.id);

                var carrierDetailsParticipatingAuctions = new CarrierDetailsParticipatingAuctions();

                carrierDetailsParticipatingAuctions.Show();

                this.Close();

            }
        }
    }
}
