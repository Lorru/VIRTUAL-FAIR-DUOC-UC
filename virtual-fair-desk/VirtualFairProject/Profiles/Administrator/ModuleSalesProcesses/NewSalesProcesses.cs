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

namespace VirtualFairProject.Profiles.Administrator.ModuleSalesProcesses
{
    public partial class NewSalesProcesses : Form
    {
        public NewSalesProcesses()
        {
            InitializeComponent();

            LoadgvSalesProcessesPublic();

            var nameUser = Session.NameUser;
            var nameProfile = Session.NameProfile;

            lblBienvenido.Text = String.Concat("Bienvenido ", nameUser, " | ", nameProfile.ToUpper());
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();

            var salesProcesses = new SalesProcesses();
            salesProcesses.Show();
        }

        

        private void LoadgvSalesProcessesPublic() 
        {
            string token = Session.Token;
            var findByIsPublic = VirtualFairIntegration.GetFindByIsPublicEqualToZero(token);

            List<AdminApi> lstAll = new List<AdminApi>();
            dgvSalesProcessesPublic.AutoGenerateColumns = false;

            if (findByIsPublic.countRows != 0)
            {
                foreach (var item in findByIsPublic.purchaseRequests)
                {

                    AdminApi salesProcessesAll = new AdminApi();
                    salesProcessesAll.id = Convert.ToInt32(item.id.ToString());
                    salesProcessesAll.fullName = item.client.fullName.ToString();
                    salesProcessesAll.totalWeight = item.totalWeight.ToString();
                    salesProcessesAll.dateA = item.desiredDate;
                    salesProcessesAll.nameStatus = item.purchaseRequestStatus.name.ToString(); //STATUS
                    lstAll.Add(salesProcessesAll);
                }

                dgvSalesProcessesPublic.DataSource = lstAll;
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

                dgvSalesProcessesPublic.Columns.Add(dataGrid);

            }

            DataGridViewButtonColumn publicar = new DataGridViewButtonColumn();

            publicar.FlatStyle = FlatStyle.Popup;
            publicar.HeaderText = "Accion";
            publicar.Name = "Publicar";
            publicar.UseColumnTextForButtonValue = true;
            publicar.Text = "Publicar";

            publicar.Width = 80;
            if (dgvSalesProcessesPublic.Columns.Contains(publicar.Name = "Publicar"))
            {

            }
            else
            {
                dgvSalesProcessesPublic.Columns.Add(publicar);
            }
        }

        private void dgvSalesProcessesPublic_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                string token = Session.Token;

                var purchaseRequest = dgvSalesProcessesPublic.CurrentRow.DataBoundItem;
                AdminApi adminApi = (AdminApi)purchaseRequest;

                dynamic objectUpdate = new System.Dynamic.ExpandoObject();
                objectUpdate.id = adminApi.id;
                objectUpdate.isPublic = 1; //PARA QUE PASE A SER PUBLICO - 0 ES PARA QUE NO QUEDE PUBLICO

                var updateIsPublic = VirtualFairIntegration.AdminUpdateIsPublicById(token, objectUpdate);

                if (updateIsPublic.statusCode == 200)
                {
                    string text = updateIsPublic.message;
                    string title = "Información";
                    MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

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
