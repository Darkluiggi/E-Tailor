using E_Tailor.Entity.Appointments;
using E_Tailor.Entity.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Tailor.Entity.Users
{
    public class Tailor :ModelBase
    {
        public int id { get; set; }
        [ForeignKey("user")]
        public int idUser { get; set; }
        public User user { get; set; }
        public List<Registry> registries { get; set; }
    }
}
