using Aleiaduh.DataAccess;
using Aleiaduh.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aleiaduh.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoctorController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        public IActionResult Index()
        {
            var doctors = dbContext.Doctors.Include(d => d.Department);
            return View(doctors.ToList());
        }
        [HttpGet]
        public IActionResult Edit(int doctorId)
        {
            //ViewData["Departments"] = dbContext.Departments;
            ViewBag.Departments = dbContext.Departments.ToList();
            var doctor = dbContext.Doctors.Include(d => d.Department).FirstOrDefault(d => d.Id == doctorId);
            if (doctor != null)
            {
                return View(doctor);
            }
            return RedirectToAction("NotFoundPage", "Home");
        }
        [HttpPost]
        public IActionResult Edit(Doctor doctor)
        {
            //dbContext.Update(new Doctor
            //{
            //    Id = doctorId,
            //    Name = name,
            //    DepartmentId = departmentId,
            //    Email = email,
            //    Phone = phone,
            //    ImageURL = imageURL,
            //    FacebookURL = facebookURL,
            //    TwitterURL = TwitterURL,
            //    InstagramURL = instagramURL

            //});
            if (doctor!=null)
            {
            dbContext.Doctors.Update(doctor);
            dbContext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int doctorId)
        {

            var doctor = dbContext.Doctors.Include(d => d.Department).FirstOrDefault(d => d.Id == doctorId);
            if (doctor != null)
            {
                dbContext.Remove(doctor);
                dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
            }

                return RedirectToAction("NotFoundPage", "Home");
        }
        [HttpGet]
        public IActionResult Create()
        {
            var doctor = dbContext.Doctors;
            var departments = dbContext.Departments;
            var doctorWihtDepartments = new
            {
                Doctors = doctor,
                Departments = departments
            };
            // IEnumerable<Doctor> doctor = dbContext.Doctors.ToList();
            ViewBag.Departments = dbContext.Departments.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(string name, int departmentId, string email, string phone,
           string imageURL, string facebookURL, string TwitterURL, string instagramURL)
        {
            dbContext.Add(new Doctor
            {
                Name = name,
                DepartmentId = departmentId,
                Email = email,
                Phone = phone,
                ImageURL = imageURL,
                FacebookURL = facebookURL,
                TwitterURL = TwitterURL,
                InstagramURL = instagramURL

            });
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
