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
    public partial class SalesProcesses : Form
    {
        public SalesProcesses()
        {
            InitializeComponent();


            LoadDgvSP();

            LoadDgvSalesProcesses1();


        }


        private void LoadDgvSalesProcesses1() 
        {
            string token = Session.Token;
            int idProducer = Session.IdProfile;
            dynamic parameters = new System.Dynamic.ExpandoObject();
            parameters.idPurchaseRequestType = 1;
            parameters.idProducer = idProducer;

            var salesProcesses = VirtualFairIntegration.FindByIdPurchaseRequestTypeAndIsPublicEqualToOne(token, parameters);

            List<AdminApi> lstAll = new List<AdminApi>();

            dgvSalesProcesses1.AutoGenerateColumns = false;

            if (salesProcesses != null)
            {
                foreach (var item in salesProcesses.purchaseRequests)
                {
                    AdminApi salesProcessesAll = new AdminApi();
                    salesProcessesAll.id = Convert.ToInt32(item.id.ToString());
                    salesProcessesAll.email = item.totalWeight.ToString();
                    salesProcessesAll.dateA = item.desiredDate;
                    salesProcessesAll.fullName = item.purchaseRequestStatus.name.ToString();
                    lstAll.Add(salesProcessesAll);
                }

                dgvSalesProcesses1.DataSource = lstAll;
            }

            string[] arrayString = new string[] { "id", "email", "dateA", "fullName" };

            foreach (var item in arrayString)
            {
                DataGridViewTextBoxColumn dataGrid = new DataGridViewTextBoxColumn();

                dataGrid.DataPropertyName = item;
                if (item == "id")
                {
                    dataGrid.HeaderText = "ID";
                }
                else if (item == "email")
                {
                    dataGrid.HeaderText = "Peso Total Kg";
                }
                else if (item == "dateA")
                {
                    dataGrid.HeaderText = "Fecha Decisión";
                }
                else if (item == "fullName")
                {
                    dataGrid.HeaderText = "Estado";
                }

                dataGrid.Name = item;

                dgvSalesProcesses1.Columns.Add(dataGrid);

            }

            DataGridViewButtonColumn verDetalles1 = new DataGridViewButtonColumn();

            verDetalles1.FlatStyle = FlatStyle.Popup;
            verDetalles1.HeaderText = "Ver Detalle";
            verDetalles1.Name = "Ver Detalle";
            verDetalles1.UseColumnTextForButtonValue = true;
            verDetalles1.Text = "Ver Detalle";

            verDetalles1.Width = 80;
            if (dgvSalesProcesses1.Columns.Contains(verDetalles1.Name = "Ver Detalle"))
            {

            }
            else
            {
                dgvSalesProcesses1.Columns.Add(verDetalles1);
            }
        }
        private void LoadDgvSP() 
        {
            string token = Session.Token;
            int idProducer = Session.IdProfile;
            dynamic parameters = new System.Dynamic.ExpandoObject();
            parameters.idPurchaseRequestType = 1;
            parameters.idProducer = idProducer;

            var salesProcessesParticipating = VirtualFairIntegration.FindByIdPurchaseTypeAndIdProducer(token, parameters);

            List<AdminApi> lstParticipating = new List<AdminApi>();

            dgvSP.AutoGenerateColumns = false;

            if (salesProcessesParticipating != null)
            {
                foreach (var item in salesProcessesParticipating.purchaseRequests)
                {
                    AdminApi users = new AdminApi();

                    users.id = Convert.ToInt32(item.id.ToString());
                    users.email = item.totalWeight.ToString();
                    users.dateA = item.desiredDate;
                    users.fullName = item.purchaseRequestStatus.name.ToString();
                    lstParticipating.Add(users);
                }

                dgvSP.DataSource = lstParticipating;
            }

            string[] arrayString = new string[] { "id", "email", "dateA", "fullName" };

            foreach (var item in arrayString)
            {
                DataGridViewTextBoxColumn dataGrid = new DataGridViewTextBoxColumn();

                dataGrid.DataPropertyName = item;
                if (item == "id")
                {
                    dataGrid.HeaderText = "ID";
                }
                else if (item == "email")
                {
                    dataGrid.HeaderText = "Peso Total Kg";
                }
                else if (item == "dateA")
                {
                    dataGrid.HeaderText = "Fecha Decisión";
                }
                else if (item == "fullName")
                {
                    dataGrid.HeaderText = "Estado";
                }

                dataGrid.Name = item;

                dgvSP.Columns.Add(dataGrid);

            }


            DataGridViewButtonColumn verDetalles = new DataGridViewButtonColumn();

            verDetalles.FlatStyle = FlatStyle.Popup;
            verDetalles.HeaderText = "Ver Detalle";
            verDetalles.Name = "Ver Detalle";
            verDetalles.UseColumnTextForButtonValue = true;
            verDetalles.Text = "Ver Detalle";

            verDetalles.Width = 80;
            if (dgvSP.Columns.Contains(verDetalles.Name = "Ver Detalle"))
            {

            }
            else
            {
                dgvSP.Columns.Add(verDetalles);
            }

        }

        private void rbLocalProcesses_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbForeignProcesses_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
