using Aleiaduh.DataAccess;
using Aleiaduh.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aleiaduh.Areas.User.Controllers
{
    [Area("User")]
    public class AppointmentController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        public IActionResult Index()
        {
            var appointments = dbContext.Appointments;
            return View(appointments.ToList());
        }
        [HttpGet]
        public IActionResult AddAppointment()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAppointment(Appointment appointment)
        {
            var doctor = dbContext.Doctors.Where(d => d.Id == appointment.Id);
            if (appointment.AppointmentDate > DateTime.Now)
            {
                dbContext.Add(new Appointment
                {
                    AppointmentDate = appointment.AppointmentDate,
                    PatientId = appointment.PatientId,
                    DoctorId = appointment.DoctorId,
                    Status = appointment.Status,
                    Description = appointment.Description
                });
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index",controllerName:"Home");

        }
    }
}
