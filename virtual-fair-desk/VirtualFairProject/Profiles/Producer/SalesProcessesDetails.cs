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
    public partial class SalesProcessesDetails : Form
    {
        public SalesProcessesDetails()
        {
            InitializeComponent();

            var nameUser = Session.NameUser;
            var nameProfile = Session.NameProfile;

            lblBienvenido.Text = String.Concat("Bienvenido ", nameUser, " | ", nameProfile.ToUpper());

            lblFechaDecision.Visible = false;
            btnDiscardParticipation.Visible = false;
            LoadDetails();
            //LoadParticipate();
            LoadParticipants();
            LoadNumericUpDown();
        }


        private void LoadNumericUpDown() 
        {
            int y1 = 55;
            int y2 = 55;
            //GroupBox groupBox = new GroupBox();
            //groupBox.Location = new Point(645, 127);
            int countRows = Convert.ToInt32(Session.countRows);

            List<string> lstNamesProducts = Session.lstNamesProducts;

            //Peso ofrecido Kg
            foreach (var item in lstNamesProducts)
            {
                NumericUpDown numericPeso = new NumericUpDown();
                numericPeso.Name = String.Concat("nudPesoOfrecido", item);
                numericPeso.Location = new Point(9, y1);
                numericPeso.Size = new Size(103,20);
                numericPeso.Visible = true;
                numericPeso.Maximum = 1000000;
                groupBox1.Controls.Add(numericPeso);
               // this.Controls.Add(numericPeso);
                y1 = y1 + 26;
            }

            //Valor por Kg
            foreach (var item in lstNamesProducts)
            {
                NumericUpDown numericValor = new NumericUpDown();
                numericValor.Name = String.Concat("nudValor", item);
                numericValor.Location = new Point(136, y2);
                numericValor.Size = new Size(103, 20);
                numericValor.Visible = true;
                numericValor.Maximum = 1000000;
                groupBox1.Controls.Add(numericValor);
                //this.Controls.Add(numericValor);
                y2 = y2 + 26;
            }
        }

        private void LoadDetails() 
        {
            string token = Session.Token;

            var idPurchaseRequest = Session.id;

           // lblNSolicitudCompra.Text = _loginData.id;

            var findByIdPurchaseRequest = VirtualFairIntegration.FindByIdPurchaseRequest(token, idPurchaseRequest);

            if (findByIdPurchaseRequest.statusCode == 403)
            {
                string text = findByIdPurchaseRequest.message;
                string title = "Información";
                MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

                var login = new Login();
                login.Show();

                this.Close();
            }
            else if (true)
            {

            }

            List<string> lstNamesProducts = new List<string>();

            List<AddProducts> lstSalesProcessesDetails = new List<AddProducts>();

            if (findByIdPurchaseRequest.countRows != 0)
            {
                lblFechaDecision.Visible = true;
                lblFechaDecision.Text = findByIdPurchaseRequest.purchaseRequestProducts[0].purchaseRequest.desiredDate.ToString();

                foreach (var item in findByIdPurchaseRequest.purchaseRequestProducts)
                {
                    AddProducts pRobject = new AddProducts();
                    pRobject.nameProduct = item.product.name.ToString();
                    pRobject.weight = item.weight;

                    lstSalesProcessesDetails.Add(pRobject);
                    lstNamesProducts.Add(item.product.name.ToString());

                }
            }

            Session.lstNamesProducts = lstNamesProducts;
            Session.countRows = findByIdPurchaseRequest.countRows;


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

        private void lblCerrarSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string text = "Has cerrado tu sesión";
            string title = "Información";
            MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

            var login = new Login();
            login.Show();

            this.Close();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();

            var salesProcesses = new SalesProcesses();
            salesProcesses.Show();
        }

        private void LoadParticipants() 
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
                    pRobject.nameClient = item.producer.fullName;
                    pRobject.nameProduct = item.purchaseRequestProduct.product.name;

                    lstSalesProcessesDetails.Add(pRobject);
                    //lstNamesProducts.Add(item.product.name.ToString());
                }
            }

            dgParticipants.AutoGenerateColumns = false;

            //var productsElements = from element in lstSalesProcessesDetails where 

            dgParticipants.DataSource = lstSalesProcessesDetails;

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

                dgParticipants.Columns.Add(dataGrid);

            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            List<string> lstNamesProducts = Session.lstNamesProducts;    

            string valuePrice = "";
            string valueKg = "";

            string token = Session.Token;

            var idPurchaseRequest = Session.id;

            var findByIdPurchaseRequest = VirtualFairIntegration.FindByIdPurchaseRequest(token, idPurchaseRequest);

            //Peso ofrecido Kg

            List<string> lstIdProducts = new List<string>();

            int countId = 0;

            foreach (var item1 in findByIdPurchaseRequest.purchaseRequestProducts)
            {
                //Session.idProduct = item1.id;

                lstIdProducts.Add(item1.id.ToString());
            }

            var purchaseRequestProducers = new List<dynamic>();

            foreach (var item in lstNamesProducts)
            {
                valueKg = String.Concat("nudPesoOfrecido", item);
                valuePrice = String.Concat("nudValor", item);

                Control ctrl = this.Controls.Find(valueKg.ToString(), true).FirstOrDefault();
                Control ctrl1 = this.Controls.Find(valuePrice.ToString(), true).FirstOrDefault();

                

                if (ctrl != null)
                {
                    if (ctrl is NumericUpDown)
                    {
                        dynamic participate = new System.Dynamic.ExpandoObject();
                        NumericUpDown kg = ctrl as NumericUpDown;
                        NumericUpDown price = ctrl1 as NumericUpDown;

                        participate.idPurchaseRequestProduct = Convert.ToInt32(lstIdProducts[countId]);
                        countId++;
                        participate.idProducer = Convert.ToInt32(Session.IdProfile);
                        participate.weight = kg.Value;
                        participate.price = price.Value;

                        purchaseRequestProducers.Add(participate);

                    }
                }
            }

            var createMassive = VirtualFairIntegration.CreateMassiveProducer(token, purchaseRequestProducers);

            if (createMassive.statusCode == 201)
            {
                string text = createMassive.message;
                string title = "Información";
                MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                var salesProcesses = new SalesProcesses();

                salesProcesses.Show();

                this.Close();
            }
            else
            {

            }

        }

        private void btnDiscardParticipation_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lblFechaDecision_Click(object sender, EventArgs e)
        {

        }

        private void dgParticipants_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dgvDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
