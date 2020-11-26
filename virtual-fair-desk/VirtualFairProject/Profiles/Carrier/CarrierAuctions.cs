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
                foreach (var item in findByIdCarrier.purchaseRequests)
                {
                    AdminApi users = new AdminApi();
                    //cambiar variables
                    users.id = Convert.ToInt32(item.id.ToString());
                    users.email = item.idPurchaseRequest.ToString();
                    users.dateA = item.creationDate;
                    users.fullName = item.updateDate.ToString();
                    users.city = item.isPublic.ToString();
                    lstParticipating.Add(users);
                }

                dgvAuctions.DataSource = lstParticipating;
            }

            string[] arrayString = new string[] { "id", "idPurchaseRequest", "creationDate", "updateDate" };

            foreach (var item in arrayString)
            {
                DataGridViewTextBoxColumn dataGrid = new DataGridViewTextBoxColumn();

                dataGrid.DataPropertyName = item;
                if (item == "id")
                {
                    dataGrid.HeaderText = "ID";
                }
                else if (item == "idPurchaseRequest")
                {
                    dataGrid.HeaderText = "Id Venta";
                }
                else if (item == "creationDate")
                {
                    dataGrid.HeaderText = "Fecha Decisión";
                }
                else if (item == "updateDate")
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
                foreach (var item in findAuctionsPublish.purchaseRequests)
                {
                    AdminApi users = new AdminApi();
                    //cambiar variables
                    users.id = Convert.ToInt32(item.id.ToString());
                    users.email = item.idPurchaseRequest.ToString();
                    users.dateA = item.creationDate;
                    users.fullName = item.updateDate.ToString();
                    users.city = item.isPublic.ToString();
                    lstParticipating.Add(users);
                }

                dgvAllAuctions.DataSource = lstParticipating;
            }

            string[] arrayString = new string[] { "id", "idPurchaseRequest", "creationDate", "updateDate", "isPublic" };

            foreach (var item in arrayString)
            {
                DataGridViewTextBoxColumn dataGrid = new DataGridViewTextBoxColumn();

                dataGrid.DataPropertyName = item;
                if (item == "id")
                {
                    dataGrid.HeaderText = "ID";
                }
                else if (item == "idPurchaseRequest")
                {
                    dataGrid.HeaderText = "Id Purchase";
                }
                else if (item == "creationDate")
                {
                    dataGrid.HeaderText = "Fecha Creacion";
                }
                else if (item == "updateDate")
                {
                    dataGrid.HeaderText = "Fecha Actualizacion";
                }
                else if (item == "isPublic")
                {
                    dataGrid.HeaderText = "Es publico";
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
    }
}
