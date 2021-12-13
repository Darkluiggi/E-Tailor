
using E_Tailor.Entity.Appointments;
using E_Tailor.Entity.Auth;
using E_Tailor.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E_Tailor.Controller
{
    /// <summary>
    /// Servicio Expuesto en WebApi de TODO
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly E_TailorContext _context;

        public TicketController(E_TailorContext context)
        {
            _context = context;
        }
        /// <summary>
        /// obtener lista de usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Ticket> GetList()
        {
            List<Ticket> model = _context.Tickets.Where(x=> x.estado).Include(x => x.customer).Include(x => x.tailor).ToList();
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
        public Ticket Get(int? id)
        {

            var ticket = _context.Tickets.Include(x => x.tailor).Include(x=> x.customer).FirstOrDefault(x=> x.id==id);

            return ticket;
        }


        /// <summary>
        /// Crear nuevo user
        /// </summary>
        /// <param name="ticket"></param>
        [HttpPost]
        public Ticket Create([FromBody] Ticket ticket)
        {
            try
            {
                _context.Tickets.Add(ticket);
                _context.SaveChanges();
                return ticket;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Actualizar un user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ticket"></param>
        [HttpPut("{id}")]
        public void Edit(int id, [FromBody] Ticket ticket)
        {
            try
            {
                Ticket TicketModel = _context.Tickets.Find(id);
                TicketModel.deliveryDate = ticket.deliveryDate;
                TicketModel.servicePrice = ticket.servicePrice;

                _context.Tickets.Update(TicketModel);
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
            Ticket ticket = _context.Tickets.Find(id);
            ticket.estado = false;
            _context.Update(ticket);
            _context.SaveChanges();
        }

       


    }
}
