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

namespace VirtualFairProject.Profiles.ExternalCustomer
{
    public partial class PurchaseRequestDetailsExternal : Form
    {

        private PurchaseRequestDTO _loginData;

        public PurchaseRequestDetailsExternal(PurchaseRequestDTO loginData)
        {
            _loginData = loginData;

            InitializeComponent();

            string token = Session.Token;
            string idPurchaseRequest = Convert.ToString(_loginData.id);

            lblNSolicitudCompra.Text = Convert.ToString(_loginData.id);

            var findByIdPurchaseRequest = VirtualFairIntegration.FindByIdPurchaseRequest(token, idPurchaseRequest);

            List<AddProducts> listPurchaseRequestDetials = new List<AddProducts>();

            if (findByIdPurchaseRequest.countRows != 0)
            {

                lblEstado.Text = String.Concat("Estado: ", findByIdPurchaseRequest.purchaseRequestProducts[0].purchaseRequest.purchaseRequestStatus.name);
                lblDesiredDate.Text = String.Concat("Fecha desea de entrega: ", findByIdPurchaseRequest.purchaseRequestProducts[0].purchaseRequest.desiredDate);


                foreach (var item in findByIdPurchaseRequest.purchaseRequestProducts)
                {
                    AddProducts pRobject = new AddProducts();
                    pRobject.nameProduct = item.product.name.ToString();
                    pRobject.weight = item.weight;
                    //pRobject.idPurchaseRequestType = purchaseRequest.purchaseRequests[0].idPurchaseRequestType.ToString();
                    pRobject.remark = item.remark.ToString();
                    pRobject.requieresRefrigerationBool = item.requiresRefrigeration;

                    if (pRobject.requieresRefrigerationBool == 1)
                    {
                        pRobject.requiresRefrigeration = "Si";
                    }
                    else if (pRobject.requieresRefrigerationBool == 0)
                    {
                        pRobject.requiresRefrigeration = "No";
                    }


                    pRobject.agreedPrice = item.agreedPrice.ToString();

                    listPurchaseRequestDetials.Add(pRobject);
                }
            }

            dgvPurchaseRequestDetails.AutoGenerateColumns = false;

            dgvPurchaseRequestDetails.DataSource = listPurchaseRequestDetials;

            string[] arrayString = new string[] { "nameProduct", "weight", "remark", "requiresRefrigeration", "agreedPrice" };

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
                else if (item == "remark")
                {
                    dataGrid.HeaderText = "Comentario";
                }
                else if (item == "requiresRefrigeration")
                {
                    dataGrid.HeaderText = "Requiere refrigeración";
                }
                else if (item == "agreedPrice")
                {
                    dataGrid.HeaderText = "Precio acordado";
                }

                dataGrid.Name = item;

                dgvPurchaseRequestDetails.Columns.Add(dataGrid);

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var refuseDevilery = new RefuseDeliveryExternal();
            refuseDevilery.Show();
            this.Close();
        }

        private void btnRecibirEntrega_Click(object sender, EventArgs e)
        {
            string token = Session.Token;
            int idClient = Session.IdProfile;
            Session.id = lblNSolicitudCompra.Text;
            int id = Convert.ToInt32(Session.id);
            //var comentario = txtComentario.Text;

            dynamic purchaseRequest = new System.Dynamic.ExpandoObject();
            purchaseRequest.id = id;
            purchaseRequest.idPurchaseRequestStatus = 8;

            var updateStatusById = VirtualFairIntegration.UpdateStatusById(token, purchaseRequest);

            if (updateStatusById.statusCode == 200)
            {
                string text = updateStatusById.message;
                string title = "Información";
                MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

                var purchaseRequestBack = new PurchaseRequestExternal();
                purchaseRequestBack.Show();
                this.Close();


            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {

            this.Close();

            var purchaseRequestExternal = new PurchaseRequestExternal();
            purchaseRequestExternal.Show();
            
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
