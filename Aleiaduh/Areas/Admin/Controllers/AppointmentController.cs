using Aleiaduh.DataAccess;
using Aleiaduh.Models;
using Aleiaduh.Repositories;
using Aleiaduh.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Aleiaduh.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentRepository appointmentRepository;
        private readonly ApplicationDbContext applicationDbContext;

        public AppointmentController(IAppointmentRepository appointmentRepository, ApplicationDbContext applicationDbContext)
        {
            this.appointmentRepository = appointmentRepository;
            this.applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            var appointments = appointmentRepository.Get();
            return View(appointments.ToList());
        }
    }
}
