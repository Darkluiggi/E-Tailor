using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Tailor.Entity.Auth
{
    public class User: ModelBase
    {
        public int id { get; set; }
        public string name { get; set; }
        [ForeignKey("rol")]
        public int idRol { get; set; }
        public Rol rol { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
    }
}
