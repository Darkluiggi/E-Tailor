using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Tailor.Entity.Auth
{
    public class AuthResponse
    {
        public AuthResponse()
        {
            authorized = false;
        }
        public User user { get; set; }
        public bool authorized { get; set; }
        public string message { get; set; }

    }
}
