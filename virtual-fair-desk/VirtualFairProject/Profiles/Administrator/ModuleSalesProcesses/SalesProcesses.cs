using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualFairProject.Profiles.Administrator.ModuleSalesProcesses
{
    public partial class SalesProcesses : Form
    {
        public SalesProcesses()
        {
            InitializeComponent();
        }

        private void btnCrearProcesoVenta_Click(object sender, EventArgs e)
        {
            var newSalesProcesses = new NewSalesProcesses();
            newSalesProcesses.Show();
        }
    }
}
