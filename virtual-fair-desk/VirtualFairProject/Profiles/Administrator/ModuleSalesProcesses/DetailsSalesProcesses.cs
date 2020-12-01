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

namespace VirtualFairProject.Profiles.Administrator.ModuleSalesProcesses
{
    public partial class DetailsSalesProcesses : Form
    {
        public DetailsSalesProcesses()
        {
            InitializeComponent();
            lblIDProcesoVenta.Visible = false;

            LoadDgvDetails();
            LoadParticipants();
            LoadProducersWinners();

            var nameUser = Session.NameUser;
            var nameProfile = Session.NameProfile;

            lblBienvenido.Text = String.Concat("Bienvenido ", nameUser, " | ", nameProfile.ToUpper());
        }

        private void LoadDgvDetails() 
        {
            string token = Session.Token;

            var idPurchaseRequest = Session.id;

            lblIDProcesoVenta.Visible = true;
            lblIDProcesoVenta.Text = Session.id;

            // lblNSolicitudCompra.Text = _loginData.id;

            var findByIdPurchaseRequest = VirtualFairIntegration.FindByIdPurchaseRequest(token, idPurchaseRequest);

            List<AddProducts> lstSalesProcessesDetails = new List<AddProducts>();

            if (findByIdPurchaseRequest.countRows != 0)
            {
                foreach (var item in findByIdPurchaseRequest.purchaseRequestProducts)
                {
                    AddProducts pRobject = new AddProducts();
                    pRobject.nameProduct = item.product.name.ToString();
                    pRobject.weight = item.weight;
                    pRobject.nameClient = item.purchaseRequest.client.fullName.ToString();

                    lstSalesProcessesDetails.Add(pRobject);
                }

                lblNombreUsuario.Text = lstSalesProcessesDetails[0].nameClient.ToString();
                lblDate.Text = String.Concat("Finalizado el ",Session.date);
            }

            dgvDetails.AutoGenerateColumns = false;

            dgvDetails.DataSource = lstSalesProcessesDetails;

            string[] arrayString = new string[] { "nameProduct", "weight" };

            //List<PropertyInfo> lst = typeof(AdminApi).GetProperties().Where(x => x.Name == "id" || x.Name == "fullName" ||
            //                                                                x.Name == "email" || x.Name == "nameProfile" ).ToList();

            foreach (var item in arrayString)
            {
                DataGridViewTextBoxColumn dataGrid = new DataGridViewTextBoxColumn();

                dataGrid.DataPropertyName = item;
                if (item == "nameProduct")
                {
                    dataGrid.HeaderText = "Nombre producto";
                }
                if (item == "weight")
                {
                    dataGrid.HeaderText = "Peso Kg";
                }

                dataGrid.Name = item;

                dgvDetails.Columns.Add(dataGrid);

            }
        }

        private void LoadParticipants()
        {
            // findByIdPurchaseRequest /{ idPurchaseRequest}
            string token = Session.Token;

            dynamic parameters = new System.Dynamic.ExpandoObject();
            parameters.idPurchaseRequest = Session.id; // 65 - cambiar id

            var findByIdPurchaseRequest = VirtualFairIntegration.GetFindByIdPurchaseRequest(token, parameters);


            List<Participants> lstSalesProcessesDetails = new List<Participants>();

            if (findByIdPurchaseRequest != null)
            {
                foreach (var item in findByIdPurchaseRequest.purchaseRequestProducers)
                {
                    Participants pRobject = new Participants();
                    pRobject.nameParticipant = item.producer.fullName.ToString();
                    pRobject.nameProduct = item.purchaseRequestProduct.product.name.ToString();
                    pRobject.offeredWeight = item.weight;
                    pRobject.valueKg = item.price.ToString();

                    lstSalesProcessesDetails.Add(pRobject);
                }

                //lblNombreUsuario.Text = lstSalesProcessesDetails[0].nameClient.ToString();
            }

            dgvParticipants.AutoGenerateColumns = false;

            dgvParticipants.DataSource = lstSalesProcessesDetails;

            string[] arrayString = new string[] { "nameParticipant", "nameProduct", "offeredWeight", "valueKg" };


            foreach (var item in arrayString)
            {
                DataGridViewTextBoxColumn dataGrid = new DataGridViewTextBoxColumn();

                dataGrid.DataPropertyName = item;
                if (item == "nameParticipant")
                {
                    dataGrid.HeaderText = "Nombre participante";
                }
                if (item == "nameProduct")
                {
                    dataGrid.HeaderText = "Nombre producto";
                }
                if (item == "offeredWeight")
                {
                    dataGrid.HeaderText = "Peso ofrecido Kg";
                }
                if (item == "valueKg")
                {
                    dataGrid.HeaderText = "$ Valor por Kg";
                }

                dataGrid.Name = item;

                dgvParticipants.Columns.Add(dataGrid);

            }

        }

        private void LoadProducersWinners()
        {
            string token = Session.Token;

            dynamic parameters = new System.Dynamic.ExpandoObject();
            parameters.idPurchaseRequest = Session.id;

            var getParticipants = VirtualFairIntegration.GetParticipantsByIdPurchaseRequestProducers(token, parameters);

            List<string> lstNamesProducts = new List<string>();

            List<AddProducts> lstSalesProcessesDetails = new List<AddProducts>();
            List<AddProducts> lstAddProducts = new List<AddProducts>();

            if (getParticipants.countRows != 0)
            {
                foreach (var item in getParticipants.purchaseRequestProducers)
                {
                    AddProducts pRobject = new AddProducts();
                    pRobject.id = Convert.ToInt32(item.id.ToString());
                    pRobject.nameClient = item.producer.fullName;
                    pRobject.nameProduct = item.purchaseRequestProduct.product.name;
                    pRobject.weight = Convert.ToInt32(item.weight.ToString());
                    pRobject.price = item.price.ToString();

                    lstSalesProcessesDetails.Add(pRobject);
                    //lstNamesProducts.Add(item.product.name.ToString());
                }
            }

            dgvWinners.AutoGenerateColumns = false;

            //var productsElements = from element in lstSalesProcessesDetails where 

            dgvWinners.DataSource = lstSalesProcessesDetails;

            string[] arrayString = new string[] { "id","nameClient", "nameProduct" ,"weight" , "price" };

            foreach (var item in arrayString)
            {
                DataGridViewTextBoxColumn dataGrid = new DataGridViewTextBoxColumn();

                dataGrid.DataPropertyName = item;
                dataGrid.ReadOnly = true;

                if (item == "id")
                {
                    dataGrid.HeaderText = "ID";
                }
                if (item == "nameClient")
                {
                    dataGrid.HeaderText = "Nombre productor";
                }
                if (item == "nameProduct")
                {
                    dataGrid.HeaderText = "Producto";
                }
                if (item == "weight")
                {
                    dataGrid.HeaderText = "Peso ofrecido Kg";
                }
                if (item == "price")
                {
                    dataGrid.HeaderText = "$ Valor por Kg";
                }

                dataGrid.Name = item;

                dgvWinners.Columns.Add(dataGrid);

            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();

            var salesProcesses = new SalesProcesses();
            salesProcesses.Show();
           
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

        private void btnSendReports_Click(object sender, EventArgs e)
        {
            string token = Session.Token;

            dynamic parameters = new System.Dynamic.ExpandoObject();
            parameters.idPurchaseRequest = Session.id;

            var sendReport = VirtualFairIntegration.SendReportToParticipantsByIdPurchaseRequest(token, parameters);

            if (sendReport.statusCode == 200)
            {
                string text = sendReport.message;
                string title = "Información";
                MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

            }


        }
    }
}
