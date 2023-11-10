using InstitutionProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InstitutionProject.Controllers
{
    public class CampusesController : Controller
    {
        private readonly InstituteDbContext db;

        public CampusesController(InstituteDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View(db.Campuses.Include(x=>x.Institute).ToList());
        }

        public IActionResult Create()
        {
            ViewBag.institutes = db.Institutes.ToList();

            return View();
        }

        [HttpPost]

        public IActionResult Create(Campus campus)
        {
            if (ModelState.IsValid)
            {
                db.Campuses.Add(campus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            var campus = db.Campuses.Find(id);
            if(campus == null)
            {
                return NotFound();
            }
            ViewBag.institutes = db.Institutes.ToList();
            return View(campus);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(int? id,Campus campus)
        {
            if(id != campus.CampusId)
            {
                return NotFound();
            }
            ViewBag.institutes = db.Institutes.ToList();
            if (ModelState.IsValid)
            {
                db.Campuses.Update(campus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(campus);
        }


        public IActionResult Delete(int? id)
        {
            var campus = db.Campuses.FirstOrDefault(x=>x.CampusId == id);
            if(campus == null)
            {
                return NotFound();
            }
            ViewBag.institutes = db.Institutes.ToList();

            return View(campus);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public IActionResult DoDelte(int? id)
        {

            var campus = db.Campuses.Find(id);
            if (campus != null)
            {
                db.Campuses.Remove(campus);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private bool CampusExists(int id)
        {
            return (db.Campuses?.Any(e => e.CampusId == id)).GetValueOrDefault();
        }
    }
}
