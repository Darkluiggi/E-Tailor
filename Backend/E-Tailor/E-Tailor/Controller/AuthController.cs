using E_Tailor.Entity.Auth;
using E_Tailor.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
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
        public AuthResponse Authorize(string email, string password)
        {
            AuthResponse response = new AuthResponse();
            try
            {   
                User result = _context.Users.Include(x=> x.rol).FirstOrDefault(x => x.email.Equals(email));
                string str = Encriptar(password);
                if (str == result.password)
                {
                    response.user = result;
                    response.authorized = true;
                }
                else
                {
                    response.user = new User();
                    response.authorized = false;

                }
            }
            catch (Exception)
            {
                response.user = new User();
                response.authorized = false;
            }
            

            return response;

        }


        public static string Encriptar(string password)
        {

            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(password));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();



        }
    }
}
