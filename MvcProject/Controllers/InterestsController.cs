using MvcProject.Models.Entity;
using MvcProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class InterestsController : Controller
    {
        GenericRepository<Interests> repo = new GenericRepository<Interests>();

        [HttpGet]
        public ActionResult Index()
        {
            var values = repo.FindWhere(x => x.Id == 1);
            return View(values);
        }

        [HttpPost]
        public ActionResult Index(Interests p)
        {
            var find = repo.FindWhere(x => x.Id == 1);
            find.Content1 = p.Content1;
            find.Content2 = p.Content2;
            repo.Update();
            return RedirectToAction("Index");
        }
    }
}