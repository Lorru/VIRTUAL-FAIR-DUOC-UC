using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualFairProject.Class.InternalCustomer.PurchaseRequest
{
    public class PurchaseRequestProducts
    {

        public int id { get; set; }
        public int idProduct { get; set; }
        public int weight { get; set; }
        public int requieresRefrigeration { get; set; }

    }
}
