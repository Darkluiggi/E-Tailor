
using E_Tailor.Entity.Appointments;
using E_Tailor.Entity.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Tailor.Entity.Users
{
    public class Customer : ModelBase
    {
        public Customer()
        {
            tickets = new List<Ticket>();
            appointments = new List<Appointment>();
        }
        public int id { get; set; }
        [ForeignKey("user")]
        public int idUser { get; set; }
        public User user { get; set; }
        public string ticketsIds { get; set; }
        [NotMapped]
        public List<Ticket> tickets { get; set; }
        public List<Appointment> appointments { get; set; }

    }
}
