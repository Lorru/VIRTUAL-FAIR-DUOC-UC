using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualFairProject.Class
{
    public static class Session
    {

        public static string Token;
        public static int IdProfile;
        public static bool Edit { get; set; }

        public static string NameUser { get; set; }

        public static string NameProfile { get; set; }

        public static string id { get; set; }

        public static string idDetails { get; set; }

        public static string date { get; set; }

        public static string countRows { get; set; }

        public static List<string> lstNamesProducts { get; set; }

        public static List<AddProducts> lstAddProducts { get; set; }

        public static int idProduct { get; set; }

        public static string dateOf { get; set; }

        public static string dateTo { get; set; }

        public static List<AllUsers> lstProducts { get; set; }


        public static string email { get; set; }
        public static string password { get; set; }

        public static string idTransportAuction { get; set; }
    }
}
