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

namespace VirtualFairProject.Profiles.Producer
{
    public partial class SalesProcesses : Form
    {
        public SalesProcesses()
        {
            InitializeComponent();
            var nameUser = Session.NameUser;
            var nameProfile = Session.NameProfile;

            lblBienvenido.Text = String.Concat("Bienvenido ", nameUser, " | ", nameProfile.ToUpper());

            LoadDgvSP();
            LoadDgvAllSalesProcesses();

            rbLocalProcesses.Checked = true;
        }

        private void LimpiarGridSP()
        {

            dgvSP.Columns.Clear();
        }

        private void LimpiarGridAllSP()
        {

            dgvAllSalesProcesses.Columns.Clear();
        }
        private void LoadDgvSP()
        {
            string token = Session.Token;
            int idProducer = Session.IdProfile;
            dynamic parameters = new System.Dynamic.ExpandoObject();
            if (rbForeignProcesses.Checked)
            {
                parameters.idPurchaseRequestType = 2;//EXTRANJERO
            }
            else
            {
                parameters.idPurchaseRequestType = 1;//LOCAL
            }
            parameters.idProducer = idProducer;

            var salesProcessesParticipating = VirtualFairIntegration.FindByIdPurchaseTypeAndIdProducer(token, parameters);

            List<AdminApi> lstParticipating = new List<AdminApi>();

            LimpiarGridSP();

            dgvSP.AutoGenerateColumns = false;

            if (salesProcessesParticipating.countRows != 0)
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

        private void LoadDgvAllSalesProcesses() 
        {
            string token = Session.Token;
            int idProducer = Session.IdProfile;
            dynamic parameters = new System.Dynamic.ExpandoObject();
            if (rbForeignProcesses.Checked)
            {
                parameters.idPurchaseRequestType = 2;//EXTRANJERO
            }
            else
            {
                parameters.idPurchaseRequestType = 1;//LOCAL
            }
            parameters.idProducer = idProducer;

            var salesProcesses = VirtualFairIntegration.FindByIdPurchaseRequestTypeAndIsPublicEqualToOne(token, parameters);

            List<AdminApi> lstAll = new List<AdminApi>();

            LimpiarGridAllSP();

            dgvAllSalesProcesses.AutoGenerateColumns = false;

            if (salesProcesses.countRows != 0)
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

                dgvAllSalesProcesses.DataSource = lstAll;
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

                dgvAllSalesProcesses.Columns.Add(dataGrid);

            }

            DataGridViewButtonColumn verDetalles1 = new DataGridViewButtonColumn();

            verDetalles1.FlatStyle = FlatStyle.Popup;
            verDetalles1.HeaderText = "Ver Detalle";
            verDetalles1.Name = "Ver Detalle";
            verDetalles1.UseColumnTextForButtonValue = true;
            verDetalles1.Text = "Ver Detalle";

            verDetalles1.Width = 80;
            if (dgvAllSalesProcesses.Columns.Contains(verDetalles1.Name = "Ver Detalle"))
            {

            }
            else
            {
                dgvAllSalesProcesses.Columns.Add(verDetalles1);
            }
        }
        

        private void rbLocalProcesses_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbForeignProcesses_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dgvSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                int rowIndex = dgvSP.CurrentCell.RowIndex;
                //Session.Edit = true;

                var purchaseRequest = dgvSP.CurrentRow.DataBoundItem;
                AdminApi purRequest = (AdminApi)purchaseRequest;

                Session.id = Convert.ToString(purRequest.id);
                Session.status = purRequest.fullName;

                var salesProcessesParticipatingDetails = new SalesProcessesParticipatingDetails();

                salesProcessesParticipatingDetails.Show();

                this.Close();

            }
        }

        private void dgvSalesProcesses1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                int rowIndex = dgvAllSalesProcesses.CurrentCell.RowIndex;
                //Session.Edit = true;

                var purchaseRequest = dgvAllSalesProcesses.CurrentRow.DataBoundItem;
                AdminApi purRequest = (AdminApi)purchaseRequest;

                Session.id = Convert.ToString(purRequest.id);

                var salesProcessesDetails = new SalesProcessesDetails();

                salesProcessesDetails.Show();

                this.Hide();

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

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            LoadDgvSP();
            LoadDgvAllSalesProcesses();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            var homeProducer = new HomeProducer();
            homeProducer.Show();
        }
    }
}
