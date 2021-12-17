using E_Tailor.Entity.Appointments;
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
        public List<Cloth> GetList()
        {
            List<Cloth> model = _context.Clothes.Where(x=> x.estado).ToList();
            return model;
        }

        /// <summary>
        /// obtener lista de usuarios
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns> 
        [HttpGet("{name}")]
        public List<Cloth> FindByName(string name)
        {
            List<Cloth> model = _context.Clothes.Where(x => x.estado).Where(x=> x.name.ToUpper().Contains(name.ToUpper())).ToList();
            return model;
        }
        /// <summary>
        /// obtener lista de prendas
        /// </summary>
        /// <returns></returns> 
        [HttpGet]
        public List<Cloth> FindByName()
        {
            List<Cloth> model = _context.Clothes.Where(x => x.estado).ToList();
            return model;
        }

        /// <summary>
        /// obtener user por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Cloth Get(int? id)
        {

            var cloth = _context.Clothes.FirstOrDefault(x=> x.id==id);

            return cloth;
        }


        /// <summary>
        /// Crear nuevo user
        /// </summary>
        /// <param name="cloth"></param>
        [HttpPost]
        public Cloth Create([FromBody] Cloth cloth)
        {
          
            _context.Clothes.Add(cloth);
            _context.SaveChanges();

           
           

            return cloth;
        }

        /// <summary>
        /// Actualizar un user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        [HttpPut("{id}")]
        public void Edit(int id, [FromBody] Cloth cloth)
        {
            try
            {
                Cloth clothModel = _context.Clothes.Find(id);
                clothModel.name = cloth.name;
                clothModel.gender = cloth.gender;

                _context.Clothes.Update(clothModel);
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
            Cloth cloth = _context.Clothes.Find(id);
            cloth.estado = false;
            _context.Clothes.Update(cloth);
            _context.SaveChanges();
        }

        


    }
}
