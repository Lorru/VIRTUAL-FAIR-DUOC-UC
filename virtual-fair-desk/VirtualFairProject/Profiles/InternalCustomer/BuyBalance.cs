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
using VirtualFairProject.Class.InternalCustomer.PurchaseRequest;
using VirtualFairProject.Profiles.Client;

namespace VirtualFairProject.Profiles.InternalCustomer
{
    public partial class BuyBalance : Form
    {

        private List<AddProducts> items = new List<AddProducts>();

        public BuyBalance()
        {
            InitializeComponent();
            LoadFirstGrid();
            LoadCmbProducts();

            var nameUser = Session.NameUser;
            var nameProfile = Session.NameProfile;

            lblBienvenido.Text = String.Concat("Bienvenido ", nameUser, " | ", nameProfile.ToUpper());

        }

        private void LoadFirstGrid() 
        {
            dgvProducts.AutoGenerateColumns = false;

            string[] arrayString = new string[] { "id", "nameProduct", "weight", "price", "requiresRefrigeration" };

            foreach (var item in arrayString)
            {
                DataGridViewTextBoxColumn dataGrid = new DataGridViewTextBoxColumn();

                dataGrid.DataPropertyName = item;

                if (item == "id")
                {
                    dataGrid.HeaderText = "Id Product";
                }
                else if (item == "nameProduct")
                {
                    dataGrid.HeaderText = "Nombre Producto";
                }
                else if (item == "weight")
                {
                    dataGrid.HeaderText = "Peso Kg";
                }
                else if (item == "price")
                {
                    dataGrid.HeaderText = "Precio";
                }
                else if (item == "requiresRefrigeration")
                {
                    dataGrid.HeaderText = "Refrigerar";
                }

                dataGrid.Name = item;

                dgvProducts.Columns.Add(dataGrid);

            }

            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();

            deleteButton.FlatStyle = FlatStyle.Popup;
            deleteButton.HeaderText = "Eliminar";
            deleteButton.Name = "Eliminar";
            deleteButton.UseColumnTextForButtonValue = true;
            deleteButton.Text = "Eliminar";

            deleteButton.Width = 60;
            if (dgvProducts.Columns.Contains(deleteButton.Name = "Eliminar"))
            {

            }
            else
            {
                dgvProducts.Columns.Add(deleteButton);
            }

            var filenamesList = new BindingList<AddProducts>(items);

            dgvProducts.DataSource = filenamesList;
        }
        private void LoadCmbProducts() 
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
                    cmb.idProduct = Convert.ToInt32(item.product.id);
                    cmb.nameProduct = item.product.name.ToString();
                    cmb.kg = item.weight.ToString();
                    cmb.price = item.agreedPrice.ToString();

                    lstProducts.Add(cmb);
                }

                Session.lstProducts = lstProducts;

                cmbProducts.DataSource = lstProducts;
                cmbProducts.ValueMember = "id";
                cmbProducts.DisplayMember = "productKgPrice";
                cmbProducts.DropDownStyle = ComboBoxStyle.DropDownList;

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

        private void btnAgregarSolicitud_Click(object sender, EventArgs e)
        {
            if (cmbProducts.Items.Count == 0)
            {
                string text = "No existen productos para comprar.";
                string title = "Información";
                MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();

                var purchaseRequestExternal = new PurchaseRequest();
                purchaseRequestExternal.Show();
            }
            else
            {
                var peso = nudPesoKg.Value;
                int idPurchaseRequest = Convert.ToInt32(cmbProducts.SelectedValue.ToString());
                var nombreProducto = cmbProducts.Text;
                //var comentario = txtComentario.Text;
                var refri = chkRequiereRefrigeracion.Checked;

                var refriValue = refri ? 1 : 0;

                var refrigeracion = refri ? "Si" : "No";

                var pr = nombreProducto.Split('$');
                var pr1 = pr[1].Split(' ');
                var precioFinal = pr1[0];

                var filenamesList = new BindingList<AddProducts>(items);

                // var asdf1 = filenamesList.Where(x=> x.id == )

                if (filenamesList.Where(x => x.idProduct == idPurchaseRequest).FirstOrDefault() == null)
                {
                    AddProducts products = new AddProducts();

                    for (int z = 0; z <= Session.lstProducts.Count - 1; z++)
                    {
                        if (Session.lstProducts.Where(x => x.id == Session.lstProducts[z].id).First().id == idPurchaseRequest)
                            products.idProduct = Session.lstProducts.Where(x => x.id == Session.lstProducts[z].id).First().idProduct;
                    }

                    decimal precio = (peso * Convert.ToInt32(precioFinal));

                    products.id = Convert.ToInt32(idPurchaseRequest);
                    //products.idProduct = Convert.ToInt32(idProducto);
                    products.nameProduct = nombreProducto;
                    products.weight = Convert.ToInt32(peso);
                    products.price = Convert.ToString(precio);
                    products.requieresRefrigerationBool = refriValue;
                    products.requiresRefrigeration = refrigeracion;

                    items.Add(products);

                    dgvProducts.DataSource = filenamesList;

                    dgvProducts.Update();
                    dgvProducts.Refresh();

                    nudPesoKg.Value = 0;
                    chkRequiereRefrigeracion.Checked = false;
                }
                else
                {
                    string text = "No se puede agregar dos veces el mismo producto, favor eliminar y volver a agregar.";
                    string title = "Información";
                    MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }

        private void btnRegistrarSolicitudCompra_Click(object sender, EventArgs e)
        {
            string token = Session.Token;

            //dynamic purchaseRequest = new System.Dynamic.ExpandoObject();
            //purchaseRequest.idClient = Session.IdProfile;
            //purchaseRequest.desiredDate = Convert.ToDateTime(dtpFechaDeseadaEntrega.Value);

            //BalancePurchaseRequest balancePurchase = new BalancePurchaseRequest();
            //balancePurchase.idClient = Session.IdProfile;
            //balancePurchase.desiredDate = Convert.ToDateTime(dtpFechaDeseadaEntrega.Value);
            //balancePurchase.purchaseRequestProducts = new List<PurchaseRequestProducts>();

            dynamic balancePurchase = new System.Dynamic.ExpandoObject();
            balancePurchase.idClient = Session.IdProfile;
            balancePurchase.desiredDate = Convert.ToDateTime(dtpFechaDeseadaEntrega.Value);
            balancePurchase.purchaseRequestProducts = new List<PurchaseRequestProducts>();

            var filenamesList = new BindingList<AddProducts>(items);

            List<BalancePurchaseRequest> lstBalancePurchase = new List <BalancePurchaseRequest>();

            //List<dynamic> purchaseRequestProducts = new List<dynamic>();


            foreach (var item in filenamesList)
            {
                PurchaseRequestProducts purchaseRequestProducts = new PurchaseRequestProducts();
                purchaseRequestProducts.id = Convert.ToInt32(item.id);
                purchaseRequestProducts.idProduct = item.idProduct;
                purchaseRequestProducts.weight = item.weight;
                purchaseRequestProducts.requiresRefrigeration = item.requieresRefrigerationBool;

                balancePurchase.purchaseRequestProducts.Add(purchaseRequestProducts);
            }

            var createBalance = VirtualFairIntegration.CreateBalancePurchaseRequest(token, balancePurchase);

            if (createBalance.statusCode == 201)
            {
                string text = createBalance.message;
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
            var homeInternalCustomer = new HomeInternalCustomer();
            homeInternalCustomer.Show();
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                int rowIndex = dgvProducts.CurrentCell.RowIndex;
                dgvProducts.Rows.RemoveAt(rowIndex);

            }
        }
    }
}
