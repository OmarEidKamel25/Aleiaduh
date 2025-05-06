using Aleiaduh.DataAccess;
using Aleiaduh.Models;
using Aleiaduh.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Aleiaduh.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoctorController : Controller
    {
        private readonly IDoctorRepository doctorRepository;
        private readonly IDepartmentRepository departmentRepository;
        public DoctorController(IDoctorRepository doctorRepository, IDepartmentRepository departmentRepository)
        {
            this.doctorRepository = doctorRepository;
            this.departmentRepository = departmentRepository;
        }

        //DoctorRepository doctorRepository = new DoctorRepository();
        //DepartmentRepository departmentRepository = new DepartmentRepository();
        public IActionResult Index()
        {
            //var doctors = dbContext.Doctors.Include(d => d.Department);
            var doctors = doctorRepository.Get(includes: [d => d.Department]);
            return View(doctors.ToList());
        }
        [HttpGet]
        public IActionResult Edit(int doctorId)
        {

            //ViewData["Departments"] = dbContext.Departments;
            ViewBag.Departments = departmentRepository.Get();
            //ViewBag.Departments = doctorRepository.Get(includes: new Expression<Func<Doctor, object>>[] { d => d.Department });

            var doctor = doctorRepository.Get(includes:[d=>d.Department]).FirstOrDefault(d => d.Id == doctorId);

            if (doctor != null)
            {
                return View(doctor);
            }
            return RedirectToAction("NotFoundPage", "Home");
        }
        [HttpPost]
        public IActionResult Edit(Doctor doctor,IFormFile? file)
        {
            //var existingDoctor = dbContext.Doctors.AsNoTracking().FirstOrDefault(d => d.Id == doctor.Id);
            var existingDoctor = doctorRepository.GetOne(d => d.Id == doctor.Id, tracked: false);
            if (ModelState.IsValid)
            {
                if (existingDoctor != null && file != null && file.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\img", fileName);
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        file.CopyTo(stream);
                    }
                    var oldPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\img",
                        existingDoctor.ImageURL);
                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }
                    doctor.ImageURL = fileName;
                }
                else
                    doctor.ImageURL = existingDoctor.ImageURL;
                // var existingDoctor = dbContext.Doctors.FirstOrDefault(d =>d.Id==doctor.Id);
                if (doctor != null)
                {
                    doctorRepository.Update(doctor);
                    doctorRepository.Commit();
                    TempData["Notification"] = "Update Doctor Successfully";
                }
            }
            else
            {
                ViewBag.Departments =departmentRepository.Get();
                return View();
            }

                return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int doctorId)
        {
            //var doctor = dbContext.Doctors.Include(d => d.Department).FirstOrDefault(d => d.Id == doctorId);
            var doctor = doctorRepository.GetOne(d => d.Id == doctorId, includes: [d => d.Department]);
            if (doctor != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\img",
                 doctor.ImageURL);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                doctorRepository.Delete(doctor);
                doctorRepository.Commit();
                TempData["Notification"] = "Doctor has been Deleted Successfully";
                return RedirectToAction(nameof(Index));
            }

                return RedirectToAction("NotFoundPage", "Home");
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = departmentRepository.Get();
            return View(new Doctor { });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Doctor doctor,IFormFile file)
        {
            if (ModelState.IsValid)
            {

            if (file != null && file.Length > 0)
            {
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory() , @"wwwroot\img", fileName);
                using (var stream=System.IO.File.Create(filePath))
                {
                    file.CopyTo(stream);
                }
                doctor.ImageURL = fileName;
            }

                doctorRepository.Create(doctor);
                doctorRepository.Commit();
                TempData["Notification"] = "Doctor Added Successfully";
                CookieOptions cookieOptions = new CookieOptions()
                {
                    Expires = DateTime.Now.AddSeconds(10)
                };
                Response.Cookies.Append("Notify", "Done",cookieOptions);
            return RedirectToAction(nameof(Index));
            }
            ViewBag.Departments = departmentRepository.Get();
            return View(doctor);
        }
    }
}
