using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_Tailor.Entity.Auth;
using E_Tailor.Persistence;

namespace E_Tailor.Controller
{
    /// <summary>
    /// Servicio Expuesto en WebApi de TODO
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RolsController : ControllerBase
    {
        private readonly E_TailorContext _context;

        public RolsController(E_TailorContext context)
        {
            _context = context;
        }
        /// <summary>
        /// obtener lista de roles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Rol> GetList()
        {
            List <Rol> model = _context.Roles.Where(x => x.estado).ToList();
            return model;
        }

        /// <summary>
        /// obtener rol por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Rol Get(int? id)
        {
           
            var rol =  _context.Roles.Find(id);          

            return rol;
        }

        /// <summary>
        /// Crear nuevo rol
        /// </summary>
        /// <param name="rol"></param>
        [HttpPost]
        public void Create([FromBody] Rol rol)
        {
                _context.Roles.Add(rol);
                _context.SaveChanges();   
        }

        /// <summary>
        /// Actualizar un rol
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rol"></param>
        [HttpPut("{id}")]
        public void Edit(int id, [FromBody] Rol rol)
        {
            try
            {
                Rol rolModel = _context.Roles.Find(id);
                rolModel.nombre = rol.nombre;                
                _context.Roles.Update(rolModel);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Borrar un rol
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Rol rol =_context.Roles.Find(id);
            rol.estado = false;
            _context.Update(rol);
            _context.SaveChanges();
        }



    }
}
