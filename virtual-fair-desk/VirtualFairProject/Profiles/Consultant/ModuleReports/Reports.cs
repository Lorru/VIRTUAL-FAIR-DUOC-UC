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
//using iTextSharp;
//using iTextSharp.text;
//using iTextSharp.text.pdf;
using System.Web;
using System.IO;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

namespace VirtualFairProject.Profiles.Consultant.ModuleReports
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();

            var nameUser = Session.NameUser;
            var nameProfile = Session.NameProfile;

            lblBienvenido.Text = String.Concat("Bienvenido ", nameUser, " | ", nameProfile.ToUpper());

            lblProductoMasPerdido.Visible = false;
            lblPesoTotalPerdidaKg.Visible = false;
            lblCostoTotalPerdida.Visible = false;
            btnDescargarReporte.Visible = false;

            dgvReport.Visible = false;
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            //var generateReports = new GenerateReports();
            //generateReports.Show();

            //this.Hide();

            string token = Session.Token;

            DateTime desde = dtpDesde.Value;
            DateTime hasta = dtpHasta.Value;

            dynamic parameters = new System.Dynamic.ExpandoObject();

            parameters.updateDateOf = dtpDesde.Value.ToString("yyyy-MM-dd");
            parameters.updateDateTo = dtpHasta.Value.ToString("yyyy-MM-dd");

            Session.dateOf = parameters.updateDateOf;
            Session.dateTo = parameters.updateDateTo;

            var findByPurchaseRequest = VirtualFairIntegration.FindByIdPurchaseRequestStatusInTwoNineAndUpdateDateConsultant(token, parameters);

            if (findByPurchaseRequest.statusCode == 200)
            {
                lblProductoMasPerdido.Visible = true;
                lblPesoTotalPerdidaKg.Visible = true;
                lblCostoTotalPerdida.Visible = true;
                btnDescargarReporte.Visible = true;

                lblProductoMasPerdido.Text = String.Concat("Producto más perdido: ", findByPurchaseRequest.summaryReport.mostLostProduct);
                lblPesoTotalPerdidaKg.Text = String.Concat("Peso total pérdida Kg: ", findByPurchaseRequest.summaryReport.totalWeightLoss);
                lblCostoTotalPerdida.Text = String.Concat("Costo total pérdida: ", findByPurchaseRequest.summaryReport.totalCostLoss);

                dgvReport.Visible = true;

                List<AdminApi> lstParticipating = new List<AdminApi>();

                dgvReport.AutoGenerateColumns = false;

                if (findByPurchaseRequest != null)
                {
                    foreach (var item in findByPurchaseRequest.summaryReport.detailReports)
                    {
                        AdminApi users = new AdminApi();

                        users.id = Convert.ToInt32(item.idPurchaseRequest.ToString());
                        users.email = item.product.ToString(); //nameProduct
                        users.totalWeight = item.weight; //weight
                        users.fullName = item.client.ToString(); //nameClient
                        users.dateA = item.date; //date
                        users.country = item.costLoss; //costLoss
                        lstParticipating.Add(users);
                    }

                    dgvReport.DataSource = lstParticipating;
                }

                string[] arrayString = new string[] { "id", "email", "totalWeight", "fullName", "dateA", "country" };

                foreach (var item in arrayString)
                {
                    DataGridViewTextBoxColumn dataGrid = new DataGridViewTextBoxColumn();

                    dataGrid.DataPropertyName = item;
                    if (item == "id")
                    {
                        dataGrid.HeaderText = "ID Proceso Venta";
                    }
                    else if (item == "email")
                    {
                        dataGrid.HeaderText = "Producto";
                    }
                    else if (item == "totalWeight")
                    {
                        dataGrid.HeaderText = "Peso Kg";
                    }
                    else if (item == "fullName")
                    {
                        dataGrid.HeaderText = "Solicitante";
                    }
                    else if (item == "dateA")
                    {
                        dataGrid.HeaderText = "Fecha";
                    }
                    else if (item == "country")
                    {
                        dataGrid.HeaderText = "Costo pérdida";
                    }

                    dataGrid.Name = item;

                    dgvReport.Columns.Add(dataGrid);

                }

            }
            else
            {
                string text = findByPurchaseRequest.message;
                string title = "Información";
                MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }




        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            var homeConsultant = new HomeConsultant();
            homeConsultant.Show();

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

        private void btnDescargarReporte_Click(object sender, EventArgs e)
        {
            string token = Session.Token;

            dynamic parameters = new System.Dynamic.ExpandoObject();
            parameters.updateDateOf = Session.dateOf;
            parameters.updateDateTo = Session.dateTo;

            var downloadArchive = VirtualFairIntegration.FindByIdPurchaseRequestStatusInTwoNineAndUpdateDatePdfConsultant(token, parameters);

            if (downloadArchive.statusCode == 200)
            {

                SaveFileDialog sfdArchive = new SaveFileDialog();

                if (sfdArchive.ShowDialog() == DialogResult.OK)
                {
                    sfdArchive.FileName = String.Concat(sfdArchive.FileName,".pdf");
                    File.WriteAllBytes(sfdArchive.FileName, Convert.FromBase64String(downloadArchive.file.ToString()));
                }

            }
            else
            {

            }

        


        }

       
    }
}
