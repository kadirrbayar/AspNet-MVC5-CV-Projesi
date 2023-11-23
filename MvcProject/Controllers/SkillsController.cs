using MvcProject.Models.Entity;
using MvcProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class SkillsController : Controller
    {
        // GET: Skills
        GenericRepository<Skills> skillRepository = new GenericRepository<Skills>();
        public ActionResult Index()
        {
            var values = skillRepository.List();
            return View(values);
        }

        [HttpGet]
        public ActionResult EditSkill(int id)
        {
            var values = skillRepository.FindWhere(x => x.Id == id);
            return View(values);
        }

        [HttpPost]
        public ActionResult EditSkill(Skills p)
        {
            var find = skillRepository.FindWhere(x => x.Id == p.Id);
            find.Title = p.Title;
            find.Level = p.Level;
            skillRepository.Update();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSkill(int id)
        {
            var find = skillRepository.FindWhere(x => x.Id == id);
            skillRepository.Delete(find);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSkill(Skills p)
        {
            skillRepository.Add(p);
            return RedirectToAction("Index");
        }
    }
}