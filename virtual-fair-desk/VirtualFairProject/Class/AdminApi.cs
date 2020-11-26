using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualFairProject.Class
{
    public class AdminApi
    {
        [DisplayName("Direccion")]
        public string address { get; set; }
        [DisplayName("Ciudad")]
        public string city { get; set; }
        [DisplayName("País")]
        public string country { get; set; }
        [DisplayName("Email")]
        public string email { get; set; }
        [DisplayName("Nombre Completo")]
        public string fullName { get; set; }
        [DisplayName("Id")]
        public int id { get; set; }
        [DisplayName("Id Profile")]
        public int idProfile { get; set; }
        [DisplayName("Password")]
        public string password { get; set; }
        [DisplayName("Profile")]
        public Profile profile { get; set; }

        
        [DisplayName("Status")]
        public int status { get; set; }

        [DisplayName("Perfil")]
        public string nameProfile { get; set; }

        public DateTime dateA { get; set; }

        public string statusName { get; set; }

        public string totalWeight { get; set; }

        public string nameStatus { get; set; }

        public string isPublic { get; set; }

        public string idDetails { get; set; }

        //public int statusCode { get; set; }
    }
}
