
using E_Tailor.Entity.Appointments;
using E_Tailor.Entity.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Tailor.Entity.Users
{
    public class Costumer
    {
        public Costumer()
        {
            clothes = new List<Cloth>();
            appointments = new List<Appointment>();
        }
        public int id { get; set; }
        [ForeignKey("user")]
        public int idUser { get; set; }
        public User user { get; set; }
        public List<Cloth> clothes { get; set; }
        public List<Appointment> appointments { get; set; }

    }
}
