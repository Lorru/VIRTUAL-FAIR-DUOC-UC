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

namespace VirtualFairProject.Profiles.Producer
{
    public partial class SalesProcessesParticipatingDetails : Form
    {
        public SalesProcessesParticipatingDetails()
        {
            InitializeComponent();
            LoadDgvSP();
            LoadDgvParticipating();
            LoadDgvParticipants();

            lblFechaDecision.Visible = false;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();

            var salesProcesses = new SalesProcesses();
            salesProcesses.Show();
        }

        private void LoadDgvSP() 
        {
            string token = Session.Token;

            var idPurchaseRequest = Session.id;

            // lblNSolicitudCompra.Text = _loginData.id;

            var findByIdPurchaseRequest = VirtualFairIntegration.FindByIdPurchaseRequest(token, idPurchaseRequest);

            List<string> lstNamesProducts = new List<string>();

            List<AddProducts> lstSalesProcessesDetails = new List<AddProducts>();

            if (findByIdPurchaseRequest.countRows != 0)
            {
                lblFechaDecision.Visible = true;
                lblFechaDecision.Text = findByIdPurchaseRequest.purchaseRequestProducts[0].purchaseRequest.desiredDate;

                foreach (var item in findByIdPurchaseRequest.purchaseRequestProducts)
                {
                    AddProducts pRobject = new AddProducts();
                    pRobject.idPurchaseRequestProduct = item.id;
                    pRobject.nameProduct = item.product.name.ToString();
                    pRobject.weight = item.weight;

                    lstSalesProcessesDetails.Add(pRobject);
                    lstNamesProducts.Add(item.product.name.ToString());

                }
            }

            Session.lstNamesProducts = lstNamesProducts;
            Session.countRows = findByIdPurchaseRequest.countRows;
            Session.lstAddProducts = lstSalesProcessesDetails;

            dgvDetails.AutoGenerateColumns = false;

            dgvDetails.DataSource = lstSalesProcessesDetails;

            string[] arrayString = new string[] { "nameProduct", "weight" };

            //List<PropertyInfo> lst = typeof(AdminApi).GetProperties().Where(x => x.Name == "id" || x.Name == "fullName" ||
            //                                                                x.Name == "email" || x.Name == "nameProfile" ).ToList();

            foreach (var item in arrayString)
            {
                DataGridViewTextBoxColumn dataGrid = new DataGridViewTextBoxColumn();

                dataGrid.DataPropertyName = item;
                dataGrid.ReadOnly = true;

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

        //Servicio para obtener una lista de la participación del productor que estan participando en la solicitud de compra por IdPurchaseRequest y por IdProducer
        private void LoadDgvParticipating() 
        {
            string token = Session.Token;

            dynamic parameters = new System.Dynamic.ExpandoObject();
            parameters.idPurchaseRequest = Session.id;
            parameters.idProducer = Session.IdProfile;

            var findByIdPurchaseRequestAndIdProducer = VirtualFairIntegration.FindByIdPurchaseRequestAndIdProducer(token, parameters);

            List<string> lstNamesProducts = new List<string>();

            List<AddProducts> lstSalesProcessesDetails = new List<AddProducts>();
            List<AddProducts> lstAddProducts = new List<AddProducts>();

            if (findByIdPurchaseRequestAndIdProducer.countRows != 0)
            {
                
                foreach (var item in findByIdPurchaseRequestAndIdProducer.purchaseRequestProducers)
                {
                    AddProducts pRobject = new AddProducts();
                    pRobject.idPurchaseRequestProduct = item.idPurchaseRequestProduct;
                    pRobject.nameProduct = item.purchaseRequestProduct.product.name;
                    pRobject.weight = item.weight;
                    pRobject.price = item.price.ToString();
                    
                    lstSalesProcessesDetails.Add(pRobject);
                    //lstNamesProducts.Add(item.product.name.ToString());
                }
            }

            Session.lstNamesProducts = lstNamesProducts;

            lstAddProducts = Session.lstAddProducts;

            List<AddProducts> orderList = lstSalesProcessesDetails.OrderBy(x => x.idPurchaseRequestProduct).ToList();


            dgvParticipating.AutoGenerateColumns = false;


            //var productsElements = from element in lstSalesProcessesDetails where 

            dgvParticipating.DataSource = orderList;

            string[] arrayString = new string[] { "weight", "price" };

            //List<PropertyInfo> lst = typeof(AdminApi).GetProperties().Where(x => x.Name == "id" || x.Name == "fullName" ||
            //                                                                x.Name == "email" || x.Name == "nameProfile" ).ToList();

            foreach (var item in arrayString)
            {
                DataGridViewTextBoxColumn dataGrid = new DataGridViewTextBoxColumn();

                dataGrid.DataPropertyName = item;
                dataGrid.ReadOnly = true;

                if (item == "weight")
                {
                    dataGrid.HeaderText = "Peso ofrecido Kg";
                }
                if (item == "price")
                {
                    dataGrid.HeaderText = "$ Valor por Kg";
                }

                dataGrid.Name = item;

                dgvParticipating.Columns.Add(dataGrid);

            }

        }

        private void LoadDgvParticipants() 
        {
            string token = Session.Token;

            dynamic parameters = new System.Dynamic.ExpandoObject();
            parameters.idPurchaseRequest = Session.id;

            var getFindByIdPurchaseRequest = VirtualFairIntegration.GetFindByIdPurchaseRequest(token, parameters);
            //GetFindByIdPurchaseRequest

            List<string> lstNamesProducts = new List<string>();

            List<AddProducts> lstSalesProcessesDetails = new List<AddProducts>();
            List<AddProducts> lstAddProducts = new List<AddProducts>();

            if (getFindByIdPurchaseRequest.countRows != 0)
            {
                foreach (var item in getFindByIdPurchaseRequest.purchaseRequestProducers)
                {
                    AddProducts pRobject = new AddProducts();
                    pRobject.nameClient = item.purchaseRequestProduct.purchaseRequest.client.fullName;
                    pRobject.nameProduct = item.purchaseRequestProduct.product.name;
                   
                    lstSalesProcessesDetails.Add(pRobject);
                    //lstNamesProducts.Add(item.product.name.ToString());
                }
            }

            dgvParticipants.AutoGenerateColumns = false;

            //var productsElements = from element in lstSalesProcessesDetails where 

            dgvParticipants.DataSource = lstSalesProcessesDetails;

            string[] arrayString = new string[] { "nameClient", "nameProduct" };

            foreach (var item in arrayString)
            {
                DataGridViewTextBoxColumn dataGrid = new DataGridViewTextBoxColumn();

                dataGrid.DataPropertyName = item;
                dataGrid.ReadOnly = true;

                if (item == "nameClient")
                {
                    dataGrid.HeaderText = "Nombre participante";
                }
                if (item == "nameProduct")
                {
                    dataGrid.HeaderText = "Nombre producto";
                }

                dataGrid.Name = item;

                dgvParticipants.Columns.Add(dataGrid);

            }
        }

        private void btnDiscardParticipation_Click(object sender, EventArgs e)
        {
            string token = Session.Token;

            dynamic parameters = new System.Dynamic.ExpandoObject();
            parameters.idPurchaseRequest = Session.id;
            parameters.idProducer = Session.IdProfile;

            var discardParticipation = VirtualFairIntegration.DestroySalesProcessesProducer(token, parameters);

            if (discardParticipation.statusCode == 200)
            {
                string text = discardParticipation.message;
                string title = "Información";
                MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

                var salesProcesses = new SalesProcesses();

                salesProcesses.Show();

                this.Close();
            }

        }
    }
}
