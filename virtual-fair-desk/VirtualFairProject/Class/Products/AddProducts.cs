using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualFairProject.Class
{
    public class AddProducts
    {
        public int idProduct { get; set; }
        public string idPurchaseRequest { get; set; }
        public int weight { get; set; }
        public string remark { get; set; }
        public string requiresRefrigeration { get; set; } 
        public int requieresRefrigerationBool { get; set; }

        public string nameProduct { get; set; }

        public string agreedPrice { get; set; }


        // 


        public string nameClient { get; set; }

    }
}
