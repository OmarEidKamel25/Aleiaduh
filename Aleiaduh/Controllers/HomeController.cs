using System.Diagnostics;
using Aleiaduh.DataAccess;
using Aleiaduh.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aleiaduh.Controllers
{
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
            //var details = new
            //{
                
            //};
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
        public IActionResult Appointment()
        {
            return View();
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
