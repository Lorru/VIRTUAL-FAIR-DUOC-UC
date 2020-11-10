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

namespace VirtualFairProject.Profiles.InternalCustomer
{
    public partial class RefuseDelivery : Form
    {
        public RefuseDelivery()
        {
            InitializeComponent();

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
                var updateStatusById = VirtualFairIntegration.UpdateStatusById(token, client);

                if (updateStatusById.statusCode == 200)
                {
                    string text = updateStatusById.message;
                    string title = "Información";
                    MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

            }
            else
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
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();


        }
    }
}
