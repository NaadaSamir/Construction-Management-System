using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
namespace FinalProject.Controllers
{
    public class DepartmentController : Controller
    {
        CompanyContext db = new CompanyContext();
        public IActionResult Index(string search)
        {
            List<Department> DepartmentList = db.Departments 
                                             .Include(c => c.Projects)
                                             .Include(d => d.DEPT_LOCATIONs)
                                             .Where(d => d.DEPT_LOCATIONs.Any(dl => dl.DLocation.Contains(search)) || search == null)
                                             .ToList();
            return View(DepartmentList);
        }

        public IActionResult Details(int id)
        {
            Dependent? dependent = db.Dependents.FirstOrDefault(DE => DE.Essn == id);
            Department? department = db.Departments.Include(c=>c.Projects)
                .Include(d=>d.DEPT_LOCATIONs)
                .First(n=>n.Dnumber==id);
            return View(department);

        }
        public IActionResult Delete(int id)
        {
            var department = db.Departments.FirstOrDefault(D => D.Dnumber == id);
            db.Remove(department);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.depts = db.Departments.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department Dept)
        {


            if (ModelState.IsValid)
            {
                db.Departments.Add(Dept);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Dept = db.Departments.ToList();
            return View("Create", Dept);
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var Dept = db.Departments.Find(id);
            if (Dept != null)
            {
                ViewBag.depts = db.Departments.ToList();
                return View(Dept);
            }
            return Content("Department not Found");
        }
        [HttpPost]
        public IActionResult Update(Department newDept)
        {
            var dept = db.Departments.Find(newDept.Dnumber);
            if (dept != null)
                if (ModelState.IsValid)
                {

                    dept.Dnumber = newDept.Dnumber;
                    dept.Dname = newDept.Dname;
                    dept.MGRSSN = newDept.MGRSSN;
                    dept.MGRStartDate = newDept.MGRStartDate;
                  

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            ViewBag.dept = db.Departments.ToList();
            return View();
        }
    }
}
