
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
        /// </summary>>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public List<Ticket> GetList(int? id)
        {
            var customers = _context.Costumers.Include(x => x.user).Where(x => x.estado).ToList();
            var Tailor = _context.Tailors.Include(x => x.user).FirstOrDefault(x => x.idUser == id);
            List<Ticket> model = _context.Tickets.Where(x => x.estado).Include(x => x.customer).Include(x => x.tailor).Where(x => x.idTailor == Tailor.id).ToList();
            model.ForEach(x => {
                x.tailor = Tailor;
                x.customer = customers.FirstOrDefault(y => y.id == x.idCustomer);
            });
            var tasks = _context.Tasks.Where(x => x.estado).ToList();
            model.ForEach(x=>
            {
                var taskIds = x.tasksIds.Split(',').ToList();
                taskIds.ForEach(y =>
                {
                    var task = tasks.FirstOrDefault(z => z.id == Int32.Parse(y));
                    x.tasks.Add(task);
                });
            });
            return model;
        }

        /// <summary>
        /// obtener user por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public List<Ticket> GetTicketsByCustomer(int? id)
        {

            var costumer = _context.Costumers.Include(x => x.user).FirstOrDefault(x => x.idUser == id);
            costumer.tickets = new List<Ticket>();
            var tickets = _context.Tickets.ToList();
            var userTickets = costumer.ticketsIds.Split(',').ToList();
            var tailors = _context.Tailors.Include(x=> x.user).ToList();
            var tasks = _context.Tasks.ToList();
            userTickets.ForEach(x=>
            {
                Ticket ticket = new Ticket();
                ticket = tickets.FirstOrDefault(y => y.id == Int32.Parse(x));
                ticket.tailor = tailors.FirstOrDefault(x => x.id == ticket.idTailor);
                costumer.tickets.Add(ticket);
            });
            costumer.tickets.ForEach(x =>
            {
                x.customer = new Entity.Users.Customer();
               
                   var taskIds = x.tasksIds.Split(',').ToList();
                    taskIds.ForEach(y =>
                    {
                        x.tasks.Add(tasks.FirstOrDefault(z=> z.id==Int32.Parse(y)));
                    });
               
            });



            return costumer.tickets;
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
        /// obtener user por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Appointment CloseAppointment(int? id)
        {
            var appointment = _context.Appointments.Find(id);
            appointment.estado = false;
            appointment.status = "Fullfilled";
            _context.Appointments.Update(appointment);
            _context.SaveChanges();

            return appointment;
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
                ticket.servicePrice = ticket.tasks.Sum(x => x.price);
                ticket.tasksIds = "";
                ticket.tasks.ForEach(x =>
                {
                    if (ticket.tasksIds == "")
                    {
                        ticket.tasksIds =  x.id.ToString();
                    }
                    else
                    {
                        ticket.tasksIds = ticket.tasksIds + ',' + x.id.ToString();
                    }
                    
                   
                });
                ticket.tasks = null;
                _context.Tickets.Add(ticket);
                _context.SaveChanges();
                var customer = _context.Costumers.First(x => x.id == ticket.idCustomer);
                if (customer.ticketsIds == null)
                {
                    customer.ticketsIds = ticket.id.ToString();
                }
                else
                {
                    customer.ticketsIds = customer.ticketsIds + ',' + ticket.id;
                }
                ticket.status = "Creado";
                _context.Costumers.Update(customer);
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
