using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Tailor.Entity.Appointments
{
    public class Cloth : ModelBase
    {
        public int id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
    }
}
