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

namespace VirtualFairProject.Profiles.ExternalCustomer
{
    public partial class NewPurchaseRequestExternal : Form
    {

        private List<AddProducts> items = new List<AddProducts>();

        public NewPurchaseRequestExternal()
        {
            InitializeComponent();


            dgvProducts1.AutoGenerateColumns = false;

            string[] arrayString = new string[] { "idProduct", "nameProduct", "weight", "remark", "requiresRefrigeration" };

            foreach (var item in arrayString)
            {
                DataGridViewTextBoxColumn dataGrid = new DataGridViewTextBoxColumn();

                dataGrid.DataPropertyName = item;

                if (item == "idProduct")
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
            var idProducto = cmbProducts.SelectedValue.ToString();
            var nombreProducto = cmbProducts.Text;
            var comentario = txtComentario.Text;
            var refri = chkRequiereRefrigeracion.Checked;

            var refriValue = refri ? 1 : 0;

            var refrigeracion = refri ? "Si" : "No";

            if (nombreProducto != "")
            {
                AddProducts products = new AddProducts();

                products.idProduct = Convert.ToInt32(idProducto);
                products.nameProduct = nombreProducto;
                products.weight = Convert.ToInt32(peso);
                products.remark = comentario;
                products.requieresRefrigerationBool = refriValue;
                products.requiresRefrigeration = refrigeracion;


                items.Add(products);

                var filenamesList = new BindingList<AddProducts>(items);

                dgvProducts1.DataSource = filenamesList;

                dgvProducts1.Update();
                dgvProducts1.Refresh();


                txtComentario.Text = "";
                nudPesoKg.Value = 0;
                chkRequiereRefrigeracion.Checked = false;

            }
            else
            {
                string text = "Se deben completar todos los campos requeridos";
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
                objectAPI.idClient = idClient;
                objectAPI.idPurchaseRequestType = 2;
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
    }
}
