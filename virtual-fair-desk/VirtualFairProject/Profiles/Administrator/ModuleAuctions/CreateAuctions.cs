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

namespace VirtualFairProject.Profiles.Administrator.ModuleAuctions
{
    public partial class CreateAuctions : Form
    {
        public CreateAuctions()
        {
            InitializeComponent();
            LoadPurchaseRequestPublic();
        }

        private void LoadPurchaseRequestPublic() 
        {

            string token = Session.Token;

            var purchaseRequestPublic = VirtualFairIntegration.GetFindByIsPublicEqualToOne(token);

            List<AdminApi> lstPurchaseRequestPublic = new List<AdminApi>();

            dgvNewAuctions.AutoGenerateColumns = false;

            if (purchaseRequestPublic.countRows != 0)
            {
                foreach (var item in purchaseRequestPublic.purchaseRequests)
                {
                    AdminApi allAuctionsObject = new AdminApi();
                    allAuctionsObject.id = Convert.ToInt32(item.id.ToString());
                    allAuctionsObject.fullName = item.client.fullName.ToString();
                    allAuctionsObject.totalWeight = item.totalWeight.ToString();
                    allAuctionsObject.dateA = item.desiredDate;
                    allAuctionsObject.nameStatus = item.purchaseRequestStatus.name.ToString(); //STATUS
                    allAuctionsObject.isPublic = item.isPublic.ToString();
                    lstPurchaseRequestPublic.Add(allAuctionsObject);
                }

                dgvNewAuctions.DataSource = lstPurchaseRequestPublic;
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

                dgvNewAuctions.Columns.Add(dataGrid);

            }

            DataGridViewButtonColumn crearSubasta = new DataGridViewButtonColumn();

            crearSubasta.FlatStyle = FlatStyle.Popup;
            crearSubasta.HeaderText = "Accion";
            crearSubasta.Name = "Crear subasta";
            crearSubasta.UseColumnTextForButtonValue = true;
            crearSubasta.Text = "Crear subasta";

            crearSubasta.Width = 80;
            if (dgvNewAuctions.Columns.Contains(crearSubasta.Name = "Crear subasta"))
            {

            }
            else
            {
                dgvNewAuctions.Columns.Add(crearSubasta);
            }
        }

        private void dgvNewAuctions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                string token = Session.Token;

                var purchaseRequest = dgvNewAuctions.CurrentRow.DataBoundItem;
                AdminApi adminApi = (AdminApi)purchaseRequest;

                dynamic objectCreate = new System.Dynamic.ExpandoObject();
                objectCreate.idPurchaseRequest = adminApi.id;
                //objectCreate.isPublic = 1; //SE PUEDE PASAR ALTIRO EN 1 Y SE PUBLICARÍA DE INMEDIATO

                var createTransportAuc = VirtualFairIntegration.createTransportAuction(token, objectCreate);

                if (createTransportAuc.statusCode == 200)
                {
                    string text = createTransportAuc.message;
                    string title = "Información";
                    MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else if(createTransportAuc.statusCode == 500)
                {
                    string text = "Error al intentar crear la subasta";
                    string title = "Información";
                    MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CreateAuctions_Load(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            var auctions = new Auctions();
            auctions.Show();
            
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
