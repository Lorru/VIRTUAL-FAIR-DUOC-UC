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

namespace VirtualFairProject.Profiles.Carrier
{
    public partial class CarrierAuctions : Form
    {
        public CarrierAuctions()
        {
            InitializeComponent();

            LoadAuctions();
        }

        private void LoadAuctions() 
        {
            string token = Session.Token;
            int idCarrier = Session.IdProfile;
            dynamic parameters = new System.Dynamic.ExpandoObject();
            //parameters.idPurchaseRequestType = 1;
            parameters.idCarrier = idCarrier;

            var findByIdCarrier = VirtualFairIntegration.FindByIdCarrierAndIsPublicEqualToOne(token, parameters);

            List<AdminApi> lstParticipating = new List<AdminApi>();

            dgvAuctions.AutoGenerateColumns = false;

            if (findByIdCarrier != null)
            {
                foreach (var item in findByIdCarrier.purchaseRequests)
                {
                    AdminApi users = new AdminApi();
                    //cambiar variables
                    users.id = Convert.ToInt32(item.id.ToString());
                    users.email = item.idPurchaseRequest.ToString();
                    users.dateA = item.creationDate;
                    users.fullName = item.updateDate.ToString();
                    users.city = item.isPublic.ToString();
                    lstParticipating.Add(users);
                }

                dgvAuctions.DataSource = lstParticipating;
            }

            string[] arrayString = new string[] { "id", "idPurchaseRequest", "creationDate", "updateDate", "isPublic" };

            foreach (var item in arrayString)
            {
                DataGridViewTextBoxColumn dataGrid = new DataGridViewTextBoxColumn();

                dataGrid.DataPropertyName = item;
                if (item == "id")
                {
                    dataGrid.HeaderText = "ID";
                }
                else if (item == "idPurchaseRequest")
                {
                    dataGrid.HeaderText = "Id Purchase";
                }
                else if (item == "creationDate")
                {
                    dataGrid.HeaderText = "Fecha Creacion";
                }
                else if (item == "updateDate")
                {
                    dataGrid.HeaderText = "Fecha Actualizacion";
                }
                else if (item == "isPublic")
                {
                    dataGrid.HeaderText = "Es publico";
                }

                dataGrid.Name = item;

                dgvAuctions.Columns.Add(dataGrid);

            }


            DataGridViewButtonColumn verDetalles = new DataGridViewButtonColumn();

            verDetalles.FlatStyle = FlatStyle.Popup;
            verDetalles.HeaderText = "Ver Detalle";
            verDetalles.Name = "Ver Detalle";
            verDetalles.UseColumnTextForButtonValue = true;
            verDetalles.Text = "Ver Detalle";

            verDetalles.Width = 80;
            if (dgvAuctions.Columns.Contains(verDetalles.Name = "Ver Detalle"))
            {

            }
            else
            {
                dgvAuctions.Columns.Add(verDetalles);
            }

        }

    }
}
