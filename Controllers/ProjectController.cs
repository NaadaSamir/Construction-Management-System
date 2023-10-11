using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class ProjectController : Controller
    {
        CompanyContext db = new CompanyContext();
        public IActionResult Index()
        {
            List<Project> Projects = db.Projects.ToList();
            return View(Projects);
        }

        public IActionResult Details(int id)
        {
            Project? project = db.Projects.FirstOrDefault(P => P.Pnumber == id);
            return View(project);

        }
        public IActionResult Delete(int id)
        {
            var project = db.Projects.FirstOrDefault(P => P.Pnumber == id);
            db.Remove(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.projs = db.Projects.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Project proj)
        {


            if (ModelState.IsValid)
            {
                db.Projects.Add(proj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.projs = db.Projects.ToList();
            return View("Create", proj);
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var Proj = db.Projects.Find(id);
            if (Proj != null)
            {
                ViewBag.depts = db.Projects.ToList();
                return View(Proj);
            }
            return Content("Project not Found");
        }
        [HttpPost]
        public IActionResult Update(Project newProj)
        {
            var Proj = db.Projects.Find(newProj.Pnumber);
            if (Proj != null)
                if (ModelState.IsValid)
                {

                    Proj.Pnumber = newProj.Pnumber;
                    Proj.Pname = newProj.Pname;
                    Proj.Plocation = newProj.Plocation;
                    Proj.Dnum = newProj.Dnum;


                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            ViewBag.Proj = db.Projects.ToList();
            return View();
        }
    }
}
