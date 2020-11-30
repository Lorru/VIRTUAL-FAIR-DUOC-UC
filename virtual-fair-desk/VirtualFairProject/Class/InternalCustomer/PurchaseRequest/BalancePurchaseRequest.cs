using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualFairProject.Class.InternalCustomer.PurchaseRequest
{
    public class BalancePurchaseRequest
    {

        public int idClient { get; set; }
        public DateTime desiredDate { get; set; }

        public List<PurchaseRequestProducts> purchaseRequestProducts { get; set; }

    }
}
