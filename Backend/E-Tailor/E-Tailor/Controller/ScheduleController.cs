using E_Tailor.Entity.Appointments;
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
        /// <param name="rol"></param>
        [HttpPost]
        public List<Appointment> GetAppointmentsByClient(int id,[FromBody] Appointment appointment)
        {
            List<Appointment> result = new List<Appointment>();
          
            _context.SaveChanges();
            return result;
        }

    }
}
