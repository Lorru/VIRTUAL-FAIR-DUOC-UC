using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualFairProject.Class
{
    public class Profile
    {
        [DisplayName("Id")]
        public int id { get; set; }
        [DisplayName("Name")]
        public string name { get; set; }

    }
}
