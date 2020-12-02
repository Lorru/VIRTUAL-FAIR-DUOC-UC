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
    public partial class RemoveAuctionsPublish : Form
    {
        public RemoveAuctionsPublish()
        {
            InitializeComponent();
            LoadDgvAuctionsPublic();

            var nameUser = Session.NameUser;
            var nameProfile = Session.NameProfile;

            lblBienvenido.Text = String.Concat("Bienvenido ", nameUser, " | ", nameProfile.ToUpper());
        }

        private void LoadDgvAuctionsPublic()
        {
            string token = Session.Token;

            var auctionsNotPublic = VirtualFairIntegration.GetFindByIsPublicEqualToOneAdmin(token);

            List<AdminApi> lstPurchaseRequestPublic = new List<AdminApi>();

            dgvAuctionsPublic.AutoGenerateColumns = false;

            if (auctionsNotPublic.countRows != 0)
            {
                foreach (var item in auctionsNotPublic.transportAuctions)
                {
                    AdminApi allAuctionsObject = new AdminApi();
                    allAuctionsObject.id = Convert.ToInt32(item.id.ToString());
                    allAuctionsObject.fullName = item.purchaseRequest.client.fullName.ToString();
                    allAuctionsObject.totalWeight = item.purchaseRequest.totalWeight.ToString();
                    allAuctionsObject.dateA = item.desiredDate;
                    allAuctionsObject.nameStatus = item.purchaseRequest.purchaseRequestStatus.name.ToString(); //STATUS
                    allAuctionsObject.isPublic = item.purchaseRequest.isPublic.ToString();
                    lstPurchaseRequestPublic.Add(allAuctionsObject);
                }

                dgvAuctionsPublic.DataSource = lstPurchaseRequestPublic;
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

                dgvAuctionsPublic.Columns.Add(dataGrid);

            }

            DataGridViewButtonColumn publicarSubasta = new DataGridViewButtonColumn();

            publicarSubasta.FlatStyle = FlatStyle.Popup;
            publicarSubasta.HeaderText = "Accion";
            publicarSubasta.Name = "Quitar subasta";
            publicarSubasta.UseColumnTextForButtonValue = true;
            publicarSubasta.Text = "Quitar subasta";

            publicarSubasta.Width = 80;
            if (dgvAuctionsPublic.Columns.Contains(publicarSubasta.Name = "Quitar subasta"))
            {

            }
            else
            {
                dgvAuctionsPublic.Columns.Add(publicarSubasta);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();

            var auctions = new Auctions();
            auctions.Show();
        }

        private void dgvAuctionsPublic_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                int rowIndex = dgvAuctionsPublic.CurrentCell.RowIndex;
                //Session.Edit = true;

                var purchaseRequest = dgvAuctionsPublic.CurrentRow.DataBoundItem;
                AdminApi purRequest = (AdminApi)purchaseRequest;

                string token = Session.Token;

                dynamic objectUpdate = new System.Dynamic.ExpandoObject();
                objectUpdate.id = purRequest.id;
                objectUpdate.isPublic = 0; //para dejarla NO publica

                var updateIsPublic = VirtualFairIntegration.UpdateIsPublicByIdAuctions(token, objectUpdate);

                if (updateIsPublic.statusCode == 200)
                {
                    string text = updateIsPublic.message;
                    string title = "Información";
                    MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                    var auctions = new Auctions();
                    auctions.Show();
                }
                else
                {
                    string text = updateIsPublic.message;
                    string title = "Información";
                    MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }
    }
}
