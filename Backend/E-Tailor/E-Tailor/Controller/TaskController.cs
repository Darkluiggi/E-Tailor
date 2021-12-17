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

namespace E_Tailor.Controller
{
    /// <summary>
    /// Servicio Expuesto en WebApi de TODO
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly E_TailorContext _context;

        public TaskController(E_TailorContext context)
        {
            _context = context;
        }
        /// <summary>
        /// obtener lista de usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Task> GetList()
        {
            List<Task> model = _context.Tasks.Where(x => x.estado).ToList();
            return model;
        }

        /// <summary>
        /// obtener lista de usuarios
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns> 
        [HttpGet("{name}")]
        public List<Task> FindByName(string name)
        {
            List<Task> model = _context.Tasks.Where(x => x.estado).Where(x => x.name.ToUpper().Contains(name.ToUpper())).ToList();
            return model;
        }

        /// <summary>
        /// obtener user por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Task Get(int? id)
        {

            var cloth = _context.Tasks.FirstOrDefault(x => x.id == id);

            return cloth;
        }


        /// <summary>
        /// Crear nuevo user
        /// </summary>
        /// <param name="user"></param>
        [HttpPost]
        public Task Create([FromBody] Task cloth)
        {

            _context.Tasks.Add(cloth);
            _context.SaveChanges();




            return cloth;
        }

        /// <summary>
        /// Actualizar un user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        [HttpPut("{id}")]
        public void Edit(int id, [FromBody] Task task)
        {
            try
            {
                Task taskModel = _context.Tasks.Find(id);
                taskModel.name = task.name;
                taskModel.price = task.price;

                _context.Tasks.Update(taskModel);
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
            Task cloth = _context.Tasks.Find(id);
            cloth.estado = false;
            _context.Tasks.Update(cloth);
            _context.SaveChanges();
        }




    }
}
