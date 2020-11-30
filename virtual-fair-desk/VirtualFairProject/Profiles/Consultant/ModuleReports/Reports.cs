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
                //downloadArchive.fileName = Nombre del archivo
                //downloadArchive.file = Base64

                string base64 = downloadArchive.file;

                PDFDownload(base64);


            }
            else
            {

            }
        }

        private void PDFDownload(string base64PDF) 
        {
            //Read the base64 text from the text file
//            string base64String = base64PDF;

            //Get bytes from the base64 string 
            //byte[] byteArray = System.Convert.FromBase64String(base64String);

            //Load PDF document
            //PdfLoadedDocument loadedDocument = new PdfLoadedDocument(byteArray);

            //Get the first page from the document
            //PdfLoadedPage page = loadedDocument.Pages[0] as PdfLoadedPage;

            //Create PDF graphics for the page
            //PdfGraphics graphics = page.Graphics;

            //Use the system installed font
            //PdfFont font = new PdfStandardFont(PdfFontFamily.Courier, 20);

            //Draw the text
            //graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new PointF(0, 0));

            //Save the PDF document to the memory stream
            //MemoryStream stream = new MemoryStream();
            //loadedDocument.Save(stream);

            //Close the document
            //loadedDocument.Close(true);

            //Convert the saved PDF document to Base64 string
            //string base64 = Convert.ToBase64String(stream.ToArray());

            //Write the base64 string to a text file
            //File.WriteAllText("Test.pdf", base64);


            using (PdfDocument document = new PdfDocument())
            {

                string base64String = base64PDF;

                //Get bytes from the base64 string 
                byte[] byteArray = System.Convert.FromBase64String(base64String);

                PdfLoadedDocument loadedDocument = new PdfLoadedDocument(byteArray);
                //Add a page to the document
                PdfPage page = document.Pages.Add();

                //Create PDF graphics for a page
                PdfGraphics graphics = page.Graphics;

                //Set the standard font
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

                //Draw the text
                //graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new PointF(0, 0));

                //Save the document
                document.Save("Output.pdf");

                if (MessageBox.Show("Desea visualizar el PDF?", "PDF fue creado",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    == DialogResult.Yes)
                {
                    try
                    {
                        //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
                        System.Diagnostics.Process.Start("Output.pdf");

                        //Exit
                        Close();
                    }
                    catch (Win32Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
                else
                    Close();
            }

        }

        //private void PDF() 
        //{
        //    string base64 = "";
        //    byte[] imageBytes = Convert.FromBase64String(base64);
        //    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imageBytes);

        //    using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
        //    {
        //        Document document = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
        //        PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
        //        document.Open();
        //        document.Add(image);
        //        document.Close();
        //        byte[] bytes = memoryStream.ToArray();
        //        memoryStream.Close();

        //        //Response.Clear();
        //        //Response.ContentType = "application/pdf";
        //        //Response.AddHeader("Content-Disposition", "attachment; filename=Image.pdf");
        //        //Response.ContentType = "application/pdf";
        //        //Response.Buffer = true;
        //        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //        //Response.BinaryWrite(bytes);
        //        //Response.End();
        //    }
        //}
    }
}
