using MvcProject.Models.Entity;
using MvcProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class EducationController : Controller
    {
        // GET: Skills
        GenericRepository<Education> repo = new GenericRepository<Education>();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }

        [HttpGet]
        public ActionResult EditEducation(int id)
        {
            var values = repo.FindWhere(x => x.Id == id);
            return View(values);
        }

        [HttpPost]
        public ActionResult EditEducation(Education p)
        {
            var find = repo.FindWhere(x => x.Id == p.Id);
            find.Content = p.Content;
            find.Title = p.Title;
            find.Subtitle = p.Subtitle;
            find.Date = p.Date;
            find.Gpa = p.Gpa;
            repo.Update();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteEducation(int id)
        {
            var find = repo.FindWhere(x => x.Id == id);
            repo.Delete(find);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEducation(Education p)
        {
            repo.Add(p);
            return RedirectToAction("Index");
        }
    }
}