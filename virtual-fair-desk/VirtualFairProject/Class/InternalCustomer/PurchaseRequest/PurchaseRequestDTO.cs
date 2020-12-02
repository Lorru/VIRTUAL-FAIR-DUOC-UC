using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualFairProject.Class.InternalCustomer.PurchaseRequest
{
    public class PurchaseRequestDTO
    {
        public string id { get; set; }
        public string idClient { get; set; }
        public string idPurchaseRequestType { get; set; }
        public string desiredDate { get; set; }
        public string updateDate { get; set; }
        public string totalWeight { get; set; }
        public string idPurchaseRequestStatus { get; set; }
        public string totalPrice { get; set; }
        public string idRequestStatus { get; set; }
        public string nameRequestStatus { get; set; }

    }
}
