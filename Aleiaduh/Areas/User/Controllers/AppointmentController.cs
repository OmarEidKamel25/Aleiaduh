using Aleiaduh.DataAccess;
using Aleiaduh.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aleiaduh.Areas.User.Controllers
{
    [Area("User")]
    public class AppointmentController : Controller
    {
        //ApplicationDbContext dbContext = new ApplicationDbContext();
        private readonly ApplicationDbContext applicationDbContext;
        public AppointmentController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public IActionResult Index()
        {
            var appointments = applicationDbContext.Appointments;
            return View(appointments.ToList());
        }
        [HttpGet]
        public IActionResult AddAppointment()
        {
            ViewBag.Patients = applicationDbContext.Patients;
            ViewBag.Doctors = applicationDbContext.Doctors.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult AddAppointment(Appointment appointment)
        {
            var doctor = applicationDbContext.Doctors.FirstOrDefault(d => d.Id == appointment.Id);
            var existingAppointment = applicationDbContext.Appointments.FirstOrDefault(d => d.DoctorId == appointment.DoctorId &&
            d.AppointmentDate.Date == appointment.AppointmentDate.Date);
            if (appointment.AppointmentDate > DateTime.Now && existingAppointment==null)
            {
                appointment.Status = "Pending";
                applicationDbContext.Add(appointment);
                applicationDbContext.SaveChanges();
            }
            else
            {
                TempData["ErrorMessage"] = "The date is invalid or the doctor already has an appointment";
                return RedirectToAction(actionName: "AddAppointment", controllerName: "Appointment");
            }
            return RedirectToAction("Index",controllerName:"Home");

        }
    }
}