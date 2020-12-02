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

namespace VirtualFairProject.Profiles.Consultant.ModuleReports
{
    public partial class GenerateReports : Form
    {
        public GenerateReports()
        {
            InitializeComponent();
        }

        private void GenerateReports_Load(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();

            var reports = new Reports();
            reports.Show();

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            string token = Session.Token;

            DateTime desde = dtpDesde.Value;
            DateTime hasta = dtpHasta.Value;

            dynamic parameters = new System.Dynamic.ExpandoObject();

            parameters.updateDateOf = dtpDesde.Value.ToString("yyyy-MM-dd");
            parameters.updateDateTo = dtpHasta.Value.ToString("yyyy-MM-dd");

            var findByPurchaseRequest = VirtualFairIntegration.FindByIdPurchaseRequestStatusInTwoNineAndUpdateDateConsultant(token, parameters);

            if (findByPurchaseRequest.statusCode == 200)
            {
                string text = findByPurchaseRequest.message;
                string title = "Información";
                MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
