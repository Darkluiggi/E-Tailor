using E_Tailor.Entity.Auth;
using E_Tailor.Entity.Users;
using E_Tailor.Persistence;
using Microsoft.AspNetCore.Http;
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
    public class ClothController : ControllerBase
    {
        private readonly E_TailorContext _context;

        public ClothController(E_TailorContext context)
        {
            _context = context;
        }
        /// <summary>
        /// obtener lista de usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<User> GetList()
        {
            List<User> model = _context.Users.Where(x=> x.estado).Include(x=> x.rol).ToList();
            return model;
        }

        /// <summary>
        /// obtener lista de usuarios
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns> 
        [HttpGet("{name}")]
        public List<User> FindByName(string name)
        {
            List<User> model = _context.Users.Where(x => x.estado).Include(x => x.rol).Where(x=> x.name.ToUpper().Contains(name.ToUpper())).ToList();
            return model;
        }

        /// <summary>
        /// obtener user por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public User Get(int? id)
        {

            var user = _context.Users.Include(x => x.rol).FirstOrDefault(x=> x.id==id);

            return user;
        }


        /// <summary>
        /// Crear nuevo user
        /// </summary>
        /// <param name="user"></param>
        [HttpPost]
        public User Create([FromBody] User user)
        {
            user.password = Encriptar(user.password);
            var rol = _context.Roles.Find(user.idRol);

            user.rol = null;
            _context.Users.Add(user);
            _context.SaveChanges();

            switch (rol.nombre)
            {
                case "Administrador":
                    Manager manager = new Manager();
                    manager.idUser = user.id;
                    manager.user = null;
                    _context.Managers.Add(manager);
                    break;
                case "Cliente":
                    Customer costumer = new Customer();
                    costumer.idUser = user.id;
                    costumer.user = null;
                    _context.Costumers.Add(costumer);
                    break;
                case "Tailor":
                    Tailor tailor = new Tailor();
                    tailor.idUser = user.id;
                    tailor.user = null;
                    _context.Tailors.Add(tailor);
                    break;
                default:
                    break;
            }
                

            _context.SaveChanges();
            return user;
        }

        /// <summary>
        /// Actualizar un user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        [HttpPut("{id}")]
        public void Edit(int id, [FromBody] User user)
        {
            try
            {
                User rolModel = _context.Users.Find(id);
                rolModel.name = user.name;
                rolModel.phoneNumber = user.phoneNumber;
                rolModel.idRol = user.idRol;
                rolModel.email = user.email;

                _context.Users.Update(rolModel);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Borrar un user
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            User user = _context.Users.Find(id);
            user.estado = false;
            _context.Update(user);
            _context.SaveChanges();
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
