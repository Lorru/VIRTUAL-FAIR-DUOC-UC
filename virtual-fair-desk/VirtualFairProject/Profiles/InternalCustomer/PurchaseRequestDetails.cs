﻿using System;
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

namespace VirtualFairProject.Profiles.InternalCustomer
{
    public partial class PurchaseRequestDetails : Form
    {

        private PurchaseRequestDTO _loginData;
        public PurchaseRequestDetails(PurchaseRequestDTO loginData)
        {
            _loginData = loginData;
            InitializeComponent();

            string token = Session.Token;
            string idPurchaseRequest = _loginData.id;

            lblNSolicitudCompra.Text = _loginData.id;

            var findByIdPurchaseRequest = VirtualFairIntegration.FindByIdPurchaseRequest(token, idPurchaseRequest);

            lblEstado.Text = String.Concat("Estado: ", findByIdPurchaseRequest.purchaseRequestProducts[0].purchaseRequest.purchaseRequestStatus.name);
            lblDesiredDate.Text = String.Concat("Fecha desea de entrega: ", findByIdPurchaseRequest.purchaseRequestProducts[0].purchaseRequest.desiredDate);


            List<AddProducts> listPurchaseRequestDetials = new List<AddProducts>();

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
            Session.id = lblNSolicitudCompra.Text;

            var refuseDevilery = new RefuseDelivery();
            refuseDevilery.Show();
            //this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string token = Session.Token;
            int idClient = Session.IdProfile;

            //var comentario = txtComentario.Text;
            dynamic client = new System.Dynamic.ExpandoObject();
            client.idClient = idClient;
            client.idPurchaseRequestStatus = 8;

            var updateStatusById = VirtualFairIntegration.UpdateStatusById(token, client);

            if (updateStatusById.statusCode == 200)
            {
                string text = updateStatusById.message;
                string title = "Información";
                MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
