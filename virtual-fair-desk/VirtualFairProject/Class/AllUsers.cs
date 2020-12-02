using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualFairProject.Class
{
    public class AllUsers
    {

        public int countRows { get; set; }

        public List<AdminApi> users { get; set; }

        public int statusCode { get; set; }



        public int id { get; set; }

        public int idProduct { get; set; }
        public string nameProduct { get; set; }
        public string kg { get; set; }
        public string price { get; set; }

        public string productKgPrice 
        {
            get 
            {
                return string.Concat(nameProduct, " - ", kg, "Kg - $", price," c/Kg");
            }
        }


        public string nameUser { get; set; }
        public string profileUser { get; set; }

        public string nameUserProfileUser
        {
            get
            {
                return string.Concat(nameUser, " | ", profileUser);
            }
        }

    }
}
