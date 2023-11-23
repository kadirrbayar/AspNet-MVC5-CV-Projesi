using MvcProject.Models.Entity;
using MvcProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class ExperienceController : Controller
    {
        GenericRepository<Experience> experienceRepository = new GenericRepository<Experience>();
        public ActionResult Index()
        {
            var values = experienceRepository.List();
            return View(values);
        }

        [HttpGet]
        public ActionResult EditExperience(int id)
        {
            var values = experienceRepository.FindWhere(x => x.Id == id);
            return View(values);
        } 

        [HttpPost]
        public ActionResult EditExperience(Experience p)
        {
            var find = experienceRepository.FindWhere(x => x.Id == p.Id);
            find.Subtitle = p.Subtitle;
            find.Title = p.Title;
            find.Content = p.Content;
            find.Date = p.Date;
            experienceRepository.Update();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteExperience(int id)
        {
            var find = experienceRepository.FindWhere(x => x.Id == id);
            experienceRepository.Delete(find);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddExperience(Experience p)
        {
            experienceRepository.Add(p);
            return RedirectToAction("Index");
        }
    }
}