using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualFairProject.Class
{
    public class SessionToken
    {
        public DateTime expirationDate { get; set; }
        public DateTime creationDate { get; set; }
        public string token { get; set; }
        public int id { get; set; }
        public string host { get; set; }
        public int idUser { get; set; }

    }
}
