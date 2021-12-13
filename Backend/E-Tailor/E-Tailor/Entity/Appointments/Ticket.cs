using E_Tailor.Entity.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Tailor.Entity.Appointments

{
    public class Ticket: ModelBase
    {
        public int id { get; set; }
        [ForeignKey("tailor")]
        public int idTailor { get; set; }
        public Tailor tailor { get; set; }
        [ForeignKey("customer")]
        public int idCustomer { get; set; }
        public Customer customer { get; set; }
        public DateTime deliveryDate { get; set; }
        public int servicePrice { get; set; }

    }
}
