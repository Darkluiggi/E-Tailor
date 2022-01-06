using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Tailor.Entity.Appointments
{
    public class Task : ModelBase
    {
        public int id { get; set; }
        public string  name { get; set; }
        public int price { get; set; }
        public string icon { get; set; }
    }
}
