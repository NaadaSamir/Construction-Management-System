using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class EmployeeController : Controller
    {

        CompanyContext db = new CompanyContext();
        public IActionResult Index()
        {
            List<Employee> Employees = db.Employees.ToList();
            return View(Employees);
        }

        public IActionResult Details(int id)
        {
            Employee? employee = db.Employees.FirstOrDefault(E => E.SSN == id);
            return View(employee);

        }
        public IActionResult Delete(int id)
        {
            var employee = db.Employees.FirstOrDefault(E => E.SSN == id);
            db.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.emps = db.Employees.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee emp)
        {


            if (ModelState.IsValid)
            {
                db.Employees.Add(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.emps = db.Employees.ToList();
            return View("Create", emp);
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var emp = db.Employees.Find(id);
            if (emp != null)
            {
                ViewBag.depts = db.Departments.ToList();
                return View(emp);
            }
            return Content("Employee not Found");
        }
        [HttpPost]
        public IActionResult Update(Employee newEmp)
        {
            var emp = db.Employees.Find(newEmp.SSN);
            if (emp != null)
                if (ModelState.IsValid)
                {

                    emp.SSN = newEmp.SSN;
                    emp.Fname = newEmp.Fname;
                    emp.Lname = newEmp.Lname;
                    emp.Minit = newEmp.Minit;
                    emp.Sex = newEmp.Sex;
                    emp.Address = newEmp.Address;
                    emp.Salary = newEmp.Salary;
                    emp.DNO= newEmp.DNO;
                    emp.BDATE = newEmp.BDATE;
                    emp.SuperSSN = newEmp.SuperSSN;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            ViewBag.emps = db.Employees.ToList();
            return View();
        }

    }
}
