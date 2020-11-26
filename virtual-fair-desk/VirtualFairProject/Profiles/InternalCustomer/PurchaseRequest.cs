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
using VirtualFairProject.Profiles.InternalCustomer;

namespace VirtualFairProject.Profiles.Client
{
    public partial class PurchaseRequest : Form
    {
        public PurchaseRequest()
        {
            InitializeComponent();

            string token = Session.Token;

            int idClient = Session.IdProfile;

            var purchaseRequest = VirtualFairIntegration.FindByIdClient(token, idClient);

            //dynamic pRobject = new System.Dynamic.ExpandoObject();

            List<PurchaseRequestDTO> listPurchaseRequest = new List<PurchaseRequestDTO>();

            foreach (var item in purchaseRequest.purchaseRequests)
            {
                PurchaseRequestDTO pRobject = new PurchaseRequestDTO();
                pRobject.id = item.id.ToString();
                pRobject.idClient = item.idClient.ToString();
                //pRobject.idPurchaseRequestType = purchaseRequest.purchaseRequests[0].idPurchaseRequestType.ToString();
                pRobject.desiredDate = item.desiredDate.ToString();
                pRobject.updateDate = item.updateDate.ToString();
                pRobject.totalWeight = item.totalWeight.ToString();
                //pRobject.idPurchaseRequestStatus = purchaseRequest.purchaseRequests[0].idPurchaseRequestStatus.ToString();
                pRobject.totalPrice = item.totalPrice.ToString();
                // pRobject.idRequestStatus = purchaseRequest.purchaseRequests[0].purchaseRequestStatus.id.ToString();
                pRobject.nameRequestStatus = item.purchaseRequestStatus.name.ToString();

                listPurchaseRequest.Add(pRobject);
            }


            dgvPurchaseRequest.AutoGenerateColumns = false;

            dgvPurchaseRequest.DataSource = listPurchaseRequest;

            string[] arrayString = new string[] { "id", "idClient", "totalWeight", "totalPrice", "desiredDate", "updateDate","nameRequestStatus"};

            //List<PropertyInfo> lst = typeof(AdminApi).GetProperties().Where(x => x.Name == "id" || x.Name == "fullName" ||
            //                                                                x.Name == "email" || x.Name == "nameProfile" ).ToList();

            foreach (var item in arrayString)
            {
                DataGridViewTextBoxColumn dataGrid = new DataGridViewTextBoxColumn();

                dataGrid.DataPropertyName = item;
                if (item == "id")
                {
                    dataGrid.HeaderText = "Ids";
                }
                if (item == "idClient")
                {
                    dataGrid.HeaderText = "Id Client";
                }
                else if (item == "totalWeight")
                {
                    dataGrid.HeaderText = "Peso Total Kg";
                }
                else if (item == "totalPrice")
                {
                    dataGrid.HeaderText = "$ Total";
                }
                else if (item == "desiredDate")
                {
                    dataGrid.HeaderText = "Fecha Solicitud";
                }
                else if (item == "updateDate")
                {
                    dataGrid.HeaderText = "Actualizado";
                }
                else if (item == "nameRequestStatus")
                {
                    dataGrid.HeaderText = "Estado";
                }

                dataGrid.Name = item;

                dgvPurchaseRequest.Columns.Add(dataGrid);

            }


            DataGridViewButtonColumn verDetalles = new DataGridViewButtonColumn();

            verDetalles.FlatStyle = FlatStyle.Popup;
            verDetalles.HeaderText = "Ver Detalle";
            verDetalles.Name = "Ver Detalle";
            verDetalles.UseColumnTextForButtonValue = true;
            verDetalles.Text = "Ver Detalle";

            verDetalles.Width = 80;
            if (dgvPurchaseRequest.Columns.Contains(verDetalles.Name = "Ver Detalle"))
            {

            }
            else
            {
                dgvPurchaseRequest.Columns.Add(verDetalles);
            }

        }

        private void btnNewRequest_Click(object sender, EventArgs e)
        {
            var nuevaSolicitudCompra = new NewPurchaseRequest();
            nuevaSolicitudCompra.Show();

            this.Hide();
        }

        private void dgvPurchaseRequest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                int rowIndex = dgvPurchaseRequest.CurrentCell.RowIndex;
                //Session.Edit = true;

                var purchaseRequest = dgvPurchaseRequest.CurrentRow.DataBoundItem;
                PurchaseRequestDTO purRequest = (PurchaseRequestDTO)purchaseRequest;

                var _loginData = purRequest;

                var solicitudCompraDetalles = new PurchaseRequestDetails(_loginData);

                solicitudCompraDetalles.Show();


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
    }
}
