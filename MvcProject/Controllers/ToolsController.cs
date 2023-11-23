using MvcProject.Models.Entity;
using MvcProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class ToolsController : Controller
    {
        GenericRepository<Tools> repo = new GenericRepository<Tools>();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddTools()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTools(Tools p)
        {
            repo.Add(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditTools(int id)
        {
            var find = repo.FindWhere(x => x.Id == id);
            return View(find);
        }
        [HttpPost]
        public ActionResult EditTools(Tools p)
        {
            var find = repo.FindWhere(x=> x.Id == p.Id);
            find.Photo = p.Photo;
            repo.Update();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteTools(int id)
        {
            var find = repo.FindWhere(x => x.Id == id);
            repo.Delete(find);
            return RedirectToAction("Index");
        }
    }
}