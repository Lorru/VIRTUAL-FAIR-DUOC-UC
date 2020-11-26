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

namespace VirtualFairProject.Profiles.Producer
{
    public partial class SalesProcessesDetails : Form
    {
        public SalesProcessesDetails()
        {
            InitializeComponent();

            LoadDetails();
            //LoadParticipate();
            LoadParticipants();
            Prueba();
        }


        private void Prueba() 
        {
            int y1 = 55;
            int y2 = 55;
            //GroupBox groupBox = new GroupBox();
            //groupBox.Location = new Point(645, 127);
            int countRows = Convert.ToInt32(Session.countRows);

            List<string> lstNamesProducts = Session.lstNamesProducts;

            //Peso ofrecido Kg
            foreach (var item in lstNamesProducts)
            {
                NumericUpDown numericPeso = new NumericUpDown();
                numericPeso.Name = String.Concat("nudPesoOfrecido", item);
                numericPeso.Location = new Point(9, y1);
                numericPeso.Size = new Size(103,20);
                //9, 55
                numericPeso.Visible = true;
                groupBox1.Controls.Add(numericPeso);
                this.Controls.Add(numericPeso);
                y1 = y1 + 26;
            }

            //Valor por Kg
            foreach (var item in lstNamesProducts)
            {
                NumericUpDown numericValor = new NumericUpDown();
                numericValor.Name = String.Concat("nudValor", item);
                numericValor.Location = new Point(136, y2);
                numericValor.Size = new Size(103, 20);
                numericValor.Visible = true;
                groupBox1.Controls.Add(numericValor);
                this.Controls.Add(numericValor);
                y2 = y2 + 26;
            }

            


            

            //for (int i = 0; i < countRows; i++)
            //{

            //        NumericUpDown numericPrueba = new NumericUpDown();
            //        numericPrueba.Location = new Point(44, y);
            //        numericPrueba.Visible = true;
            //        groupBox1.Controls.Add(numericPrueba);
            //        numericPrueba.Name = "numericPrueba";

            //        y = y + 26;




            //}
        }

        private void LoadDetails() 
        {
            string token = Session.Token;

            var idPurchaseRequest = Session.id;

           // lblNSolicitudCompra.Text = _loginData.id;

            var findByIdPurchaseRequest = VirtualFairIntegration.FindByIdPurchaseRequest(token, idPurchaseRequest);

            List<string> lstNamesProducts = new List<string>();

            List<AddProducts> lstSalesProcessesDetails = new List<AddProducts>();

            if (findByIdPurchaseRequest.countRows != 0)
            {
                foreach (var item in findByIdPurchaseRequest.purchaseRequestProducts)
                {
                    AddProducts pRobject = new AddProducts();
                    pRobject.nameProduct = item.product.name.ToString();
                    pRobject.weight = item.weight;

                    lstSalesProcessesDetails.Add(pRobject);
                    lstNamesProducts.Add(item.product.name.ToString());

                }
            }

            Session.lstNamesProducts = lstNamesProducts;
            Session.countRows = findByIdPurchaseRequest.countRows;


            dgvDetails.AutoGenerateColumns = false;

            dgvDetails.DataSource = lstSalesProcessesDetails;

            string[] arrayString = new string[] { "nameProduct", "weight" };

            //List<PropertyInfo> lst = typeof(AdminApi).GetProperties().Where(x => x.Name == "id" || x.Name == "fullName" ||
            //                                                                x.Name == "email" || x.Name == "nameProfile" ).ToList();

            foreach (var item in arrayString)
            {
                DataGridViewTextBoxColumn dataGrid = new DataGridViewTextBoxColumn();

                dataGrid.DataPropertyName = item;
                dataGrid.ReadOnly = true;

                if (item == "nameProduct")
                {
                    dataGrid.HeaderText = "Nombre producto";
                }
                if (item == "weight")
                {
                    dataGrid.HeaderText = "Peso Kg";
                }

                dataGrid.Name = item;

                dgvDetails.Columns.Add(dataGrid);

            }

        }

        private void LoadParticipants() 
        { 
        
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

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();

            var salesProcesses = new SalesProcesses();
            salesProcesses.Show();
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            var x = "asda";

            Control ctrl = this.Controls.Find("nudPesoOfrecidoBROCOLI",true).FirstOrDefault();

            //

            if (ctrl != null)
            {
                if (ctrl is NumericUpDown)
                {
                    NumericUpDown prueba1 = ctrl as NumericUpDown;

                }
            }
        }
    }
}
