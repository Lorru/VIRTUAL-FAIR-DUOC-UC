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
    public partial class Auctions : Form
    {
        public Auctions()
        {
            InitializeComponent();

            LoadAllAuctions();
        }

        private void btnBuscarSubasta_Click(object sender, EventArgs e)
        {

        }

        private void btnCrearSubasta_Click(object sender, EventArgs e)
        {
            var createAuctions = new CreateAuctions();
            createAuctions.Show();

            this.Close();
        }

        private void LoadAllAuctions() 
        {
            string token = Session.Token;

            var allAuctions = VirtualFairIntegration.GetFindAllAuctionsAdmin(token);

            List<AdminApi> lstAllAuctions = new List<AdminApi>();

            dgvAuctions.AutoGenerateColumns = false;

            if (allAuctions.countRows != 0)
            {
                foreach (var item in allAuctions.transportAuctions)
                {
                    AdminApi allAuctionsObject = new AdminApi();
                    allAuctionsObject.id = Convert.ToInt32(item.id.ToString());
                    allAuctionsObject.fullName = item.client.fullName.ToString();
                    allAuctionsObject.totalWeight = item.totalWeight.ToString();
                    allAuctionsObject.dateA = item.desiredDate;
                    allAuctionsObject.nameStatus = item.purchaseRequestStatus.name.ToString(); //STATUS
                    allAuctionsObject.isPublic = item.isPublic.ToString();
                    lstAllAuctions.Add(allAuctionsObject);
                }

                dgvAuctions.DataSource = lstAllAuctions;
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

                dgvAuctions.Columns.Add(dataGrid);

            }

            DataGridViewButtonColumn verDetalles1 = new DataGridViewButtonColumn();

            verDetalles1.FlatStyle = FlatStyle.Popup;
            verDetalles1.HeaderText = "Ver Detalle";
            verDetalles1.Name = "Ver Detalle";
            verDetalles1.UseColumnTextForButtonValue = true;
            verDetalles1.Text = "Ver Detalle";

            verDetalles1.Width = 80;
            if (dgvAuctions.Columns.Contains(verDetalles1.Name = "Ver Detalle"))
            {

            }
            else
            {
                dgvAuctions.Columns.Add(verDetalles1);
            }
        }

        private void btnPublishAuctions_Click(object sender, EventArgs e)
        {
            var updateAuctionsNotPublic = new UpdateAuctionsNotPublic();
            updateAuctionsNotPublic.Show();

            this.Close();
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
