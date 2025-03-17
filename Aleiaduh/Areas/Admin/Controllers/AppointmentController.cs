using Aleiaduh.DataAccess;
using Aleiaduh.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aleiaduh.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppointmentController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        public IActionResult Index()
        {
            var appointments = dbContext.Appointments;
            return View(appointments.ToList());
        }

    }
}
