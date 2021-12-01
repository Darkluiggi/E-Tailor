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
        [HttpPost]
        public bool CreateAppointment(int id,[FromBody] Appointment appointment)
        {
            try
            {
                var costumer = _context.Costumers.Include(x => x.appointments).FirstOrDefault(x => x.id == id);
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
        /// Crear nuevo rol
        /// </summary>
        /// <param name="id"></param>
        [HttpPost]
        public List<Appointment> GetAppointmentsByCostumer(int id)
        {
            List<Appointment> result = new List<Appointment>();

            var costumer = _context.Costumers.Include(x => x.appointments).FirstOrDefault(x => x.id == id);
            result= costumer.appointments;
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
                var appointment= _context.Appointments.Find(id);
                appointment.status = false;
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

            List<Tailor> model = _context.Tailors.Include(x=> x.user).Where(x => x.estado).ToList();
            List<TailorList> result = new List<TailorList>();
            model.ForEach (x =>
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

    }
}
