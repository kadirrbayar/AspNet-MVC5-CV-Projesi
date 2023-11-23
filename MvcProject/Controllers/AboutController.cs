using MvcProject.Models.Entity;
using MvcProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class AboutController : Controller
    {
        GenericRepository<About> repo = new GenericRepository<About>();

        [HttpGet]
        public ActionResult Index()
        {
            var values = repo.FindWhere(x => x.Id == 1);
            return View(values);
        }

        [HttpPost]
        public ActionResult Index(About p)
        {
            var values = repo.FindWhere(x => x.Id == 1);
            values.Name = p.Name;
            values.SurName = p.SurName;
            values.Subtitle = p.Subtitle;
            values.Content = p.Content;
            values.Image = p.Image;
            values.Mail = p.Mail;
            repo.Update();
            return RedirectToAction("Index");
        }
    }
}