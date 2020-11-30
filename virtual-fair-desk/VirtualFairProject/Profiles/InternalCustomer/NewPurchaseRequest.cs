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
using VirtualFairProject.Profiles.Client;

namespace VirtualFairProject.Profiles.InternalCustomer
{
    public partial class NewPurchaseRequest : Form
    {

        private List<AddProducts> items = new List<AddProducts>();

        public NewPurchaseRequest()
        {
            InitializeComponent();

            dgvProducts1.AutoGenerateColumns = false;

            string[] arrayString = new string[] { "idProduct", "nameProduct","weight", "remark", "requiresRefrigeration" };

            foreach (var item in arrayString)
            {
                DataGridViewTextBoxColumn dataGrid = new DataGridViewTextBoxColumn();

                dataGrid.DataPropertyName = item;

                if (item == "idProduct")
                {
                    dataGrid.HeaderText = "Id Product";
                }
                else if(item == "nameProduct")
                {
                    dataGrid.HeaderText = "Nombre Producto";
                }
                else if (item == "weight")
                {
                    dataGrid.HeaderText = "Peso Kg";
                }
                else if (item == "remark")
                {
                    dataGrid.HeaderText = "Comentario";
                }
                else if (item == "requiresRefrigeration")
                {
                    dataGrid.HeaderText = "Requiere Refrigeración";
                }

                dataGrid.Name = item;

                dgvProducts1.Columns.Add(dataGrid);

            }

            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();

            deleteButton.FlatStyle = FlatStyle.Popup;
            deleteButton.HeaderText = "Eliminar";
            deleteButton.Name = "Eliminar";
            deleteButton.UseColumnTextForButtonValue = true;
            deleteButton.Text = "Eliminar";

            deleteButton.Width = 60;
            if (dgvProducts1.Columns.Contains(deleteButton.Name = "Eliminar"))
            {

            }
            else
            {
                dgvProducts1.Columns.Add(deleteButton);
            }


            var filenamesList = new BindingList<AddProducts>(items);

            dgvProducts1.DataSource = filenamesList;


            LoadProducts();

        }

        private void LoadProducts() 
        {
            string token = Session.Token;
            var findProducts = VirtualFairIntegration.FindAllProducts(token);

            cmbProducts.DataSource = findProducts.products;
            cmbProducts.DisplayMember = "name";
            cmbProducts.ValueMember = "id";
            cmbProducts.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        private void btnAgregarSolicitud_Click(object sender, EventArgs e)
        {

            var peso = nudPesoKg.Value;
            int idProducto = Convert.ToInt32(cmbProducts.SelectedValue.ToString());
            var nombreProducto = cmbProducts.Text;
            var comentario = txtComentario.Text;
            var refri = chkRequiereRefrigeracion.Checked;

            var refriValue = refri ? 1 : 0;

            var refrigeracion = refri ? "Si" : "No";

            var filenamesList = new BindingList<AddProducts>(items);

            if (filenamesList.Where(x => x.idProduct == idProducto).FirstOrDefault() == null)
            {
                AddProducts products = new AddProducts();

                products.idProduct = Convert.ToInt32(idProducto);
                products.nameProduct = nombreProducto;
                products.weight = Convert.ToInt32(peso);
                products.remark = comentario;
                products.requieresRefrigerationBool = refriValue;
                products.requiresRefrigeration = refrigeracion;
               
                items.Add(products);

                dgvProducts1.DataSource = filenamesList;

                dgvProducts1.Update();
                dgvProducts1.Refresh();

                txtComentario.Text = "";
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

        private void btnRegistrarSolicitudCompra_Click(object sender, EventArgs e)
        {
            List<dynamic> lst = items.Select(x => new
            {
                idProduct = x.idProduct,
                weight = x.weight,
                remark = x.remark,
                requiresRefrigeration = x.requieresRefrigerationBool
            }).Cast<dynamic>().ToList();

            //var lst1 = lst.Where(x => x.requieresRefrigeration == "Si").ToList();

            if (lst.Count == 0)
            {
                string text = "Debe agregar productos para realizar esta acción";
                string title = "Información";
                MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                string token = Session.Token;
                int idClient = Session.IdProfile;

                dynamic objectAPI = new System.Dynamic.ExpandoObject();

                objectAPI.desiredDate = Convert.ToDateTime(dtpFechaDeseadaEntrega.Value);
                //objectAPI.pruebaDate =  DateTime.UtcNow.Subtract(new DateTime(dtpFechaDeseadaEntrega.Value,DateTimeKind.Utc)).TotalMilliseconds;
                objectAPI.idClient = idClient;
                objectAPI.idPurchaseRequestType = 1;
                objectAPI.purchaseRequestProducts = lst;



                var createNewPurchaseRequest = VirtualFairIntegration.CreateNewPurchaseRequest(token, objectAPI);

                if (createNewPurchaseRequest.statusCode == 200)
                {
                    string text = "Se deben completar todos los campos requeridos";
                    string title = "Información";
                    MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (createNewPurchaseRequest.statusCode == 201)
                {
                    string text = createNewPurchaseRequest.message;
                    string title = "Información";
                    MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();

                    var solicitudCompra = new PurchaseRequest();
                    solicitudCompra.Show();


                }
            }
        }

        private void dgvProducts1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                int rowIndex = dgvProducts1.CurrentCell.RowIndex;
                dgvProducts1.Rows.RemoveAt(rowIndex);

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
            var homeInternalCustomer = new HomeInternalCustomer();
            homeInternalCustomer.Show();
        }
    }
}
