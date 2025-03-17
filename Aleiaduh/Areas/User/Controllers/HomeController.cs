using System.Diagnostics;
using Aleiaduh.DataAccess;
using Aleiaduh.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aleiaduh.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ApplicationDbContext dbContext = new ApplicationDbContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var doctors = dbContext.Doctors.Include(d => d.Department);
            var details = new
            {
                Doctors=doctors,
            };
            return View(doctors);
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Services()
        {
            return View();
        }
        public IActionResult Team()
        {
            var doctors = dbContext.Doctors.Include(d=>d.Department);
            return View(doctors.ToList());
        }
        public IActionResult Appointment(string? DoctorName)
        {
            var doctors = dbContext.Doctors.ToList();

            return View(doctors);
        }
        public IActionResult NotFoundPage()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
