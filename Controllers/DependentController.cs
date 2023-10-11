using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;

namespace FinalProject.Controllers
{
    public class DependentController : Controller
    {
        CompanyContext db = new CompanyContext();
        public IActionResult Index()
        {
            List<Dependent> Dependents = db.Dependents.ToList();
            return View(Dependents);
        }

        public IActionResult Details(int id)
        {
            Dependent? dependent = db.Dependents.FirstOrDefault(DE => DE.Essn == id);

            return View(dependent);

        }
        public IActionResult Delete(int id)
        {
            var dependent = db.Dependents.FirstOrDefault(DE => DE.Essn == id);
            db.Remove(dependent);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
      
             [HttpGet]
        public IActionResult Create()
        {
            ViewBag.depen = db.Dependents.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Dependent Depen)
        {


            if (ModelState.IsValid)
            {
                db.Dependents.Add(Depen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Depen = db.Dependents.ToList();
            return View("Create", Depen);
        }


        [HttpGet]
        public IActionResult Update(int id, string dependentName)
        {
            var Depen = db.Dependents.Find(id, dependentName);
            if (Depen != null)
            {
                ViewBag.Depen = db.Dependents.ToList();
                return View(Depen);
            }
            return Content("Dependent not Found");
        }

        [HttpPost]
        public IActionResult Update(Dependent newDepen)
        {
            var depen = db.Dependents.Find(newDepen.Essn, newDepen.Dependent_Name);
            if (depen != null)
            {
                if (ModelState.IsValid)
                {
                    depen.Essn = newDepen.Essn;
                    depen.Dependent_Name = newDepen.Dependent_Name;
                    depen.Sex = newDepen.Sex;
                    depen.Bdate = newDepen.Bdate;
                    depen.Relationship = newDepen.Relationship;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.depen = db.Dependents.ToList();
            return View();
        }

    }
}
