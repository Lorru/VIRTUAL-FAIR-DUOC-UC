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
    public partial class CarrierDetailsAuctions : Form
    {
        public CarrierDetailsAuctions()
        {

            

            InitializeComponent();

            lblTipoSubasta.Visible = false;
            lblFechaDecision.Visible = false;
            lblFechaDeseada.Visible = false;

            LoadDetailsAuctions();
            LoadParticipants();

            var nameUser = Session.NameUser;
            var nameProfile = Session.NameProfile;

            lblBienvenido.Text = String.Concat("Bienvenido ", nameUser, " | ", nameProfile.ToUpper());


        }

        private void LoadDetailsAuctions() 
        {
            string token = Session.Token;

            dynamic parameters = new System.Dynamic.ExpandoObject();
            //parameters.idPurchaseRequest = Session.id;
            string idPurchaseRequest = Session.idTransportAuction;

            //var findByIdTransportAuction = VirtualFairIntegration.FindByIdTransportAuction(token, parameters);
            var findByIdTransportAuction = VirtualFairIntegration.FindByIdPurchaseRequest(token, idPurchaseRequest); 
            List<AdminApi> lstParticipating = new List<AdminApi>();

            dgvDetailsAuctions.AutoGenerateColumns = false;

            if (findByIdTransportAuction.countRows != 0)
            {
                lblTipoSubasta.Visible = true;
                lblFechaDecision.Visible = true;
                lblFechaDeseada.Visible = true;

                lblFechaDeseada.Text = findByIdTransportAuction.purchaseRequestProducts[0].purchaseRequest.desiredDate;
                lblFechaDecision.Text = findByIdTransportAuction.purchaseRequestProducts[0].purchaseRequest.creationDate;
                lblTipoSubasta.Text = String.Concat(findByIdTransportAuction.purchaseRequestProducts[0].purchaseRequest.purchaseRequestType.name," ", findByIdTransportAuction.purchaseRequestProducts[0].idPurchaseRequest);

                foreach (var item in findByIdTransportAuction.purchaseRequestProducts)
                {
                    AdminApi users = new AdminApi();
                    //cambiar variables
                    users.id = Convert.ToInt32(item.id.ToString());
                    users.fullName = item.product.name.ToString(); //nombre producto
                    users.email = item.weight.ToString(); //peso kg
                    users.city = item.remark.ToString(); //comentario
                    users.address = item.requiresRefrigeration; //requiere refrigeracion
                    if (users.address == "1")
                    {
                        users.country = "Si";
                    }
                    else
                    {
                        users.country = "No";
                    }
                    lstParticipating.Add(users);
                }

                dgvDetailsAuctions.DataSource = lstParticipating;
            }

            string[] arrayString = new string[] { "id", "fullName","email", "city", "country" };

            foreach (var item in arrayString)
            {
                DataGridViewTextBoxColumn dataGrid = new DataGridViewTextBoxColumn();

                dataGrid.DataPropertyName = item;
                if (item == "id") //id
                {
                    dataGrid.HeaderText = "ID";
                }
                else if (item == "fullName") //nombre producto
                {
                    dataGrid.HeaderText = "Nombre producto";
                }
                else if (item == "email") //peso kg
                {
                    dataGrid.HeaderText = "Peso Kg";
                }
                else if (item == "city") // comentario
                {
                    dataGrid.HeaderText = "Comentario";
                }
                else if (item == "country") //requiere refrigeracion
                {
                    dataGrid.HeaderText = "Requiere Refrigeración";
                }

                dataGrid.Name = item;

                dgvDetailsAuctions.Columns.Add(dataGrid);

            }

        }

        private void LoadParticipants() 
        {
            string token = Session.Token;

            dynamic parameters = new System.Dynamic.ExpandoObject();
            parameters.idTransportAuction = Session.idTransportAuction;

            var loadParticipants = VirtualFairIntegration.FindByIdTransportAuction(token, parameters);

            List<AdminApi> lstParticipating = new List<AdminApi>();

            dgvParticipants.AutoGenerateColumns = false;

            if (loadParticipants.countRows != 0)
            {
                foreach (var item in loadParticipants.transportAuctionCarriers)
                {
                    AdminApi users = new AdminApi();
                    //cambiar variables
                    users.id = Convert.ToInt32(item.id.ToString()); //Posición
                    users.fullName = item.carrier.fullName.ToString(); //Nombre
                    users.email = item.price.ToString(); //Oferta
                    lstParticipating.Add(users);
                }

                dgvParticipants.DataSource = lstParticipating;
            }

            string[] arrayString = new string[] { "id", "fullName", "email" };

            foreach (var item in arrayString)
            {
                DataGridViewTextBoxColumn dataGrid = new DataGridViewTextBoxColumn();

                dataGrid.DataPropertyName = item;
                if (item == "id") //Posición
                {
                    dataGrid.HeaderText = "Posición";
                }
                else if (item == "fullName") //nombre 
                {
                    dataGrid.HeaderText = "Nombre";
                }
                else if (item == "email") //oferta
                {
                    dataGrid.HeaderText = "Oferta";
                }

                dataGrid.Name = item;

                dgvParticipants.Columns.Add(dataGrid);

            }
        }

        private void btnRegistrarOferta_Click(object sender, EventArgs e)
        {
            string token = Session.Token;

            dynamic objectCreate = new System.Dynamic.ExpandoObject();
            objectCreate.idTransportAuction = Session.idTransportAuction;
            objectCreate.idCarrier = Session.id;
            objectCreate.price = txtPrice.Text;

            var createAuction = VirtualFairIntegration.CreateAuctionCarrier(token, objectCreate);

            if (createAuction.statusCode == 201)
            {
                string text = createAuction.message;
                string title = "Información";
                MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            var carrierAuctions = new CarrierAuctions();
            carrierAuctions.Show();
           
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
