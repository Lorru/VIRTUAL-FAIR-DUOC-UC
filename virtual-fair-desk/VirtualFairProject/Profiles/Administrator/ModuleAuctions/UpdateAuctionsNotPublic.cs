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
    public partial class UpdateAuctionsNotPublic : Form
    {
        public UpdateAuctionsNotPublic()
        {
            InitializeComponent();
            LoadDgvAuctionsNotPublic();
        }

        private void LoadDgvAuctionsNotPublic() 
        {
            string token = Session.Token;

            var auctionsNotPublic = VirtualFairIntegration.GetFindByIsPublicEqualToZeroAdmin(token);

            List<AdminApi> lstPurchaseRequestPublic = new List<AdminApi>();

            dgvAuctionsNotPublic.AutoGenerateColumns = false;

            if (auctionsNotPublic.countRows != 0)
            {
                foreach (var item in auctionsNotPublic.purchaseRequests)
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

                dgvAuctionsNotPublic.DataSource = lstPurchaseRequestPublic;
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

                dgvAuctionsNotPublic.Columns.Add(dataGrid);

            }

            DataGridViewButtonColumn publicarSubasta = new DataGridViewButtonColumn();

            publicarSubasta.FlatStyle = FlatStyle.Popup;
            publicarSubasta.HeaderText = "Accion";
            publicarSubasta.Name = "Publicar subasta";
            publicarSubasta.UseColumnTextForButtonValue = true;
            publicarSubasta.Text = "Publicar subasta";

            publicarSubasta.Width = 80;
            if (dgvAuctionsNotPublic.Columns.Contains(publicarSubasta.Name = "Publicar subasta"))
            {

            }
            else
            {
                dgvAuctionsNotPublic.Columns.Add(publicarSubasta);
            }
        }

        private void dgvAuctionsNotPublic_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 5)
            {

            }
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
