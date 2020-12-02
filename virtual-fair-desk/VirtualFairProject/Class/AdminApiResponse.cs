using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualFairProject.Class
{
    public class AdminApiResponse
    {

        public SessionToken sessionToken { get; set; }
        public AdminApi userConnect { get; set; }
        public int statusCode { get; set; }

    }
}
