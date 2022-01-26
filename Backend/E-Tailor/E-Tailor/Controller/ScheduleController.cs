using E_Tailor.Entity.Appointments;
using E_Tailor.Entity.Auth;
using E_Tailor.Entity.Users;
using E_Tailor.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class ScheduleController : ControllerBase
    {
        private readonly E_TailorContext _context;

        public ScheduleController(E_TailorContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Crear nuevo rol
        /// </summary>
        /// <param name="id"></param>
        /// <param name="appointment"></param>
        [HttpPost("{id}")]
        public bool CreateAppointment(int id, [FromBody] Appointment appointment)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(x => x.id == id);
                var costumer = _context.Costumers.FirstOrDefault(x => x.idUser == user.id);
                costumer.appointments.Add(appointment);
                _context.Costumers.Update(costumer);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }


        /// <summary>
        /// Obtener citas por cliente
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        public List<Appointment> GetAppointmentsByCustomer(int id)
        {
            List<Appointment> result = new List<Appointment>();

            var costumer = _context.Costumers.Include(x => x.appointments).FirstOrDefault(x => x.idUser == id && x.estado);
            result = costumer.appointments.Where(x => x.estado).ToList();
            return result;
        }
        /// <summary>
        /// Crear nuevo rol
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        public List<Appointment> GetAppointmentsByTailor(int id)
        {
            List<Appointment> result = new List<Appointment>();
            var tailor = _context.Tailors.FirstOrDefault(x => x.estado && x.idUser == id);
            var appointments = _context.Appointments.Where(x => x.idTailor == tailor.id && x.estado).ToList();
            result = appointments;
            return result;
        }

        /// <summary>
        /// Crear nuevo rol
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        public Appointment GetAppointmentById(int id)
        {

            var costumers = _context.Costumers.Include(x => x.appointments).Include(x => x.user).ToList();
            Appointment result = new Appointment();

            var appointment = _context.Appointments.Include(x => x.tailor).FirstOrDefault(x => x.id == id && x.estado);
            var tailor = _context.Tailors.Include(x => x.user).First(x => x.id == appointment.idTailor);
            appointment.customerName = costumers.FirstOrDefault(x => x.appointments.Any(y => y.id == appointment.id)).user.name;
            appointment.customerId = costumers.FirstOrDefault(x => x.appointments.Any(y => y.id == appointment.id)).id;
            appointment.tailor.user = tailor.user;
            result = appointment;
            return result;
        }

        /// <summary>
        /// Crear nuevo rol
        /// </summary>
        /// <param name="id"></param>
        [HttpPost]
        public bool CancelAppointment(int id)
        {
            bool result = false;
            try
            {
                var appointment = _context.Appointments.Find(id);
                appointment.status = "Cancelada";
                _context.Appointments.Update(appointment);
                _context.SaveChanges();
                result = true;

            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// obtener lista de roles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<TailorList> GetTailorList()
        {

            List<Tailor> model = _context.Tailors.Include(x => x.user).Where(x => x.estado).ToList();
            List<TailorList> result = new List<TailorList>();
            model.ForEach(x =>
            {
                TailorList data = new TailorList();
                data.id = x.id;
                data.name = x.user.name;
                result.Add(data);

            });

            return result;
        }
        public class TailorList
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        /// <summary>
        /// obtener lista de usuarios
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns> 
        [HttpPost]
        public string GetTailorAvailability([FromBody] Appointment appointment)
        {
            string result = "";
            try
            {
                var appointments = _context.Appointments.Where(x => x.date == appointment.date && x.estado).ToList();
                appointment.date = appointment.date.AddHours(appointment.hour.Hour);
                appointment.date = appointment.date.AddMinutes(appointment.hour.Minute);
                TimeSpan daysDifference = appointment.date.Subtract(DateTime.Now);
                //if (daysDifference.Hours <= 0 )
                //{
                //    result = "Ya no se pueden agendar citas en este horario";
                //    return result;
                //}
                //if (appointment.date.Hour < 9 || appointment.date.Hour>18)
                //{
                //    result = "No se pueden agendar citas fuera del horario de la tienda";
                //    return result;
                //}


                if (appointments.Count == 0)
                {
                    result = "Horario disponible";
                    return result;
                }
                else
                {
                    List<string> errors = new List<string>();
                    appointments.ForEach(x =>
                    {
                        TimeSpan timeDifference = appointment.hour.Subtract(x.hour);
                        if (timeDifference.TotalMinutes < 30)
                        {
                            errors.Add("La cita" + x.id + "se solapa con el horario actual");

                        }
                    });
                    if (errors.Count > 0)
                    {

                        result = "Ya existe una cita en el horario seleccionado";
                    }
                    else
                    {
                        result = "Horario disponible";
                    }

                }


            }
            catch (Exception)
            {
                result = "Error al verificar la cita";
            }

            return result;
        }

        /// <summary>
        /// Obtener lista de citas de la tienda
        /// </summary>
        [HttpGet]
        public List<Appointment> GetStoreSchedule()
        {
            List<Appointment> result = new List<Appointment>();
            var appointments = _context.Appointments.Include(x => x.tailor).Where(x => x.estado).ToList();
            List<Customer> customers = _context.Costumers.Include(x => x.user).Where(x => x.estado).ToList();
            appointments.ForEach(x =>
            {
                x.customer = customers.FirstOrDefault(y => y.appointments.Any(z => z.id == x.id));

            });
            appointments.ForEach(x =>
            {
                x.customer.appointments = new List<Appointment>();

            });
            result = appointments;
            return result;
        }

        /// <summary>
        /// Obtener lista de citas de la tienda
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        public string Deliverticket(int id)
        {
            try
            {
                var ticket = _context.Tickets.Where(x => x.id == id).FirstOrDefault();
                return "Se ha finalizado el servicio correctamente";
            }
            catch (Exception)
            {

                return "No ha sido  posible finalizar el servicio";
            }
        }

        /// <summary>
        /// Borrar un user
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Appointment appointment = _context.Appointments.Find(id);
            appointment.estado = false;
            _context.Appointments.Update(appointment);
            _context.SaveChanges();
        }



    }
}
