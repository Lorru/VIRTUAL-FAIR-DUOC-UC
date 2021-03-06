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
using VirtualFairProject.Profiles.Client;

namespace VirtualFairProject.Profiles.InternalCustomer
{
    public partial class RefuseDelivery : Form
    {
        public RefuseDelivery()
        {
            InitializeComponent();

            var nameUser = Session.NameUser;
            var nameProfile = Session.NameProfile;

            lblBienvenido.Text = String.Concat("Bienvenido ", nameUser, " | ", nameProfile.ToUpper());

        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string token = Session.Token;
            int idClient = Session.IdProfile;

            int id = Convert.ToInt32(Session.id);

            var comentario = txtComentario.Text;
            dynamic client = new System.Dynamic.ExpandoObject();
            client.id = id;
            client.idPurchaseRequestStatus = 9;

            if (comentario != "")
            {
                try
                {
                    var updateStatusById = VirtualFairIntegration.UpdateStatusById(token, client);

                    if (updateStatusById.statusCode == 200)
                    {
                        string text = updateStatusById.message;
                        string title = "Información";
                        MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        var purchaseRequestBack = new PurchaseRequest();
                        purchaseRequestBack.Show();
                        this.Close();
                    }
                }
                catch (Exception)
                {
                    string text = "Hubo un error al intentar rechazar la entrega.";
                    string title = "Información";
                    MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                

            }
            else
            {
                try
                {
                    client.remark = comentario;
                    var updateStatusByIdRemark = VirtualFairIntegration.CreateRemark(token, client);

                    if (updateStatusByIdRemark.statusCode == 200)
                    {
                        string text = updateStatusByIdRemark.message;
                        string title = "Información";
                        MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch (Exception )
                {
                    string text = "Hubo un error al intentar rechazar la entrega.";
                    string title = "Información";
                    MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();


        }
    }
}
