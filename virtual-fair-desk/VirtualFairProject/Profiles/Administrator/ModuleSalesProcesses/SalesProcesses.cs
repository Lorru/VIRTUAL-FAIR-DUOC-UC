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

namespace VirtualFairProject.Profiles.Administrator.ModuleSalesProcesses
{
    public partial class SalesProcesses : Form
    {
        public SalesProcesses()
        {
            InitializeComponent();
            LoadStatus();
            LoadSalesProcesses();

            rbProcesosExtranjeros.Checked = true;

            var nameUser = Session.NameUser;
            var nameProfile = Session.NameProfile;

            lblBienvenido.Text = String.Concat("Bienvenido ", nameUser, " | ", nameProfile.ToUpper());
        }

        private void btnCrearProcesoVenta_Click(object sender, EventArgs e)
        {
            this.Close();

            var newSalesProcesses = new NewSalesProcesses();
            newSalesProcesses.Show();
        }

        private void LoadStatus() 
        {
            string token = Session.Token;
            var findProducts = VirtualFairIntegration.FindAllStatus(token);

            cmbStatus.DataSource = findProducts.purchaseRequestStatus;
            cmbStatus.DisplayMember = "name";
            cmbStatus.ValueMember = "id";
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void LimpiarGrid()
        {

            dgvSalesProcesses.Columns.Clear();
        }

        private void btnAplicarFiltro_Click(object sender, EventArgs e)
        {
            string token = Session.Token;

            dynamic parameters = new System.Dynamic.ExpandoObject();

            if (rbProcesosExtranjeros.Checked)
            {
                parameters.idPurchaseRequestType = 2;
            }
            else if (rbProcesosLocales.Checked)
            {
                parameters.idPurchaseRequestType = 1;
            }

            parameters.idPurchaseRequestStatus = cmbStatus.SelectedValue.ToString();


            dgvSalesProcesses.DataSource = null;

            

            LoadSalesProcessesFilter(token, parameters);


        }

        private void LoadSalesProcessesFilter(string token, dynamic parameters) 
        {
            var findAllPurchaseRequest = VirtualFairIntegration.GetFindByIdPurchaseRequestStatusAndIdPurchaseRequestType(token, parameters);

            LimpiarGrid();

            List<AdminApi> lstAll = new List<AdminApi>();
            dgvSalesProcesses.AutoGenerateColumns = false;

            if (findAllPurchaseRequest.countRows != 0)
            {
                foreach (var item in findAllPurchaseRequest.purchaseRequests)
                {
                    
                    AdminApi salesProcessesAll = new AdminApi();
                    salesProcessesAll.id = Convert.ToInt32(item.id.ToString());
                    salesProcessesAll.fullName = item.client.fullName.ToString();
                    salesProcessesAll.totalWeight = item.totalWeight.ToString();
                    salesProcessesAll.dateA = item.desiredDate;
                    salesProcessesAll.nameStatus = item.purchaseRequestStatus.name.ToString(); //STATUS
                    lstAll.Add(salesProcessesAll);
                }

                dgvSalesProcesses.DataSource = lstAll;
            }

            string[] arrayString = new string[] { "id", "fullName", "totalWeight", "dateA", "nameStatus" };

            foreach (var item in arrayString)
            {
                DataGridViewTextBoxColumn dataGrid = new DataGridViewTextBoxColumn();

                dataGrid.DataPropertyName = item;
                if (item == "id")
                {
                    dataGrid.HeaderText = "ID";
                }
                else if (item == "fullName")
                {
                    dataGrid.HeaderText = "Solicitado por";
                }
                else if (item == "totalWeight")
                {
                    dataGrid.HeaderText = "Peso Total Kg";
                }
                else if (item == "dateA")
                {
                    dataGrid.HeaderText = "Fecha Decisión";
                }
                else if (item == "nameStatus")
                {
                    dataGrid.HeaderText = "Estado";
                }

                dataGrid.Name = item;

                dgvSalesProcesses.Columns.Add(dataGrid);

            }

            DataGridViewButtonColumn verDetalles1 = new DataGridViewButtonColumn();

            verDetalles1.FlatStyle = FlatStyle.Popup;
            verDetalles1.HeaderText = "Ver Detalle";
            verDetalles1.Name = "Ver Detalle";
            verDetalles1.UseColumnTextForButtonValue = true;
            verDetalles1.Text = "Ver Detalle";

            verDetalles1.Width = 80;
            if (dgvSalesProcesses.Columns.Contains(verDetalles1.Name = "Ver Detalle"))
            {

            }
            else
            {
                dgvSalesProcesses.Columns.Add(verDetalles1);
            }
        }

        private void LoadSalesProcesses() 
        {
            string token = Session.Token;

            var findAllPurchaseRequest = VirtualFairIntegration.GetFindAllPurchaseRequisitions(token);

            List<AdminApi> lstAll = new List<AdminApi>();

            dgvSalesProcesses.AutoGenerateColumns = false;

            if (findAllPurchaseRequest != null)
            {
                foreach (var item in findAllPurchaseRequest.purchaseRequests)
                {
                    AdminApi salesProcessesAll = new AdminApi();
                    salesProcessesAll.id = Convert.ToInt32(item.id.ToString());
                    salesProcessesAll.fullName = item.client.fullName.ToString();
                    salesProcessesAll.totalWeight = item.totalWeight.ToString();
                    salesProcessesAll.dateA = item.desiredDate;
                    salesProcessesAll.nameStatus = item.purchaseRequestStatus.name.ToString(); //STATUS
                    salesProcessesAll.isPublic = item.isPublic.ToString();
                    lstAll.Add(salesProcessesAll);
                }

                dgvSalesProcesses.DataSource = lstAll;
            }

            string[] arrayString = new string[] { "id", "fullName", "totalWeight", "dateA", "nameStatus" };

            foreach (var item in arrayString)
            {
                DataGridViewTextBoxColumn dataGrid = new DataGridViewTextBoxColumn();

                dataGrid.DataPropertyName = item;
                if (item == "id")
                {
                    dataGrid.HeaderText = "ID";
                }
                else if (item == "fullName")
                {
                    dataGrid.HeaderText = "Solicitado por";
                }
                else if (item == "totalWeight")
                {
                    dataGrid.HeaderText = "Peso Total Kg";
                }
                else if (item == "dateA")
                {
                    dataGrid.HeaderText = "Fecha Decisión";
                }
                else if (item == "nameStatus")
                {
                    dataGrid.HeaderText = "Estado";
                }

                dataGrid.Name = item;

                dgvSalesProcesses.Columns.Add(dataGrid);

            }

            DataGridViewButtonColumn verDetalles1 = new DataGridViewButtonColumn();

            verDetalles1.FlatStyle = FlatStyle.Popup;
            verDetalles1.HeaderText = "Ver Detalle";
            verDetalles1.Name = "Ver Detalle";
            verDetalles1.UseColumnTextForButtonValue = true;
            verDetalles1.Text = "Ver Detalle";

            verDetalles1.Width = 80;
            if (dgvSalesProcesses.Columns.Contains(verDetalles1.Name = "Ver Detalle"))
            {

            }
            else
            {
                dgvSalesProcesses.Columns.Add(verDetalles1);
            }
        }

        private void dgvSalesProcesses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                var purchaseRequest = dgvSalesProcesses.CurrentRow.DataBoundItem;
                AdminApi adminApi = (AdminApi)purchaseRequest;

                Session.id = Convert.ToString(adminApi.id);
                Session.date = Convert.ToString(adminApi.dateA);

                var detailsSalesProcesses = new DetailsSalesProcesses();
                detailsSalesProcesses.Show();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();

            var homeAdmin = new HomeAdmin();
            homeAdmin.Show();
            
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
