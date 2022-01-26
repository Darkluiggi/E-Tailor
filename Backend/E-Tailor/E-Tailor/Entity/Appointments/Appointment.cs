using E_Tailor.Entity.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Tailor.Entity.Appointments
{
    public class Appointment : ModelBase
    {
        public Appointment()
        {
            status = "Programada";
        }
        public int id { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMMM-yyyy}")]
        public DateTime date { get; set; }
        [DisplayFormat(DataFormatString = "{0:HH:MM}")]
        public DateTime hour { get; set; }
        public string serviceType { get; set; }
        public string  gender { get; set; }
        [ForeignKey("tailor")]
        public int idTailor { get; set; }
        public Tailor tailor { get; set; }
        public string status { get; set; }
        [NotMapped]
        public Customer customer { get; set; }
        [NotMapped]
        public int customerId { get;  set; }
        [NotMapped]
        public string customerName { get; set; }
    }
}
