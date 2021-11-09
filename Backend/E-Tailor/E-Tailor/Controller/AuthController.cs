using E_Tailor.Entity.Auth;
using E_Tailor.Persistence;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Tailor.Controller
{
    /// <summary>
    /// Servicio Expuesto en WebApi de TODO
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly E_TailorContext _context;

        public AuthController(E_TailorContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Actualizar un user
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        [HttpPost]
        public User Authorize(string email, string password)
        {
            User result = new User();
            return result;

        }
    }
}
