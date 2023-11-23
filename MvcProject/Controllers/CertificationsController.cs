using MvcProject.Models.Entity;
using MvcProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class CertificationsController : Controller
    {
        GenericRepository<Certifications> repo = new GenericRepository<Certifications>();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult EditCertifications(int id)
        {
            var values = repo.FindWhere(x => x.Id == id);
            return View(values);
        }  
        [HttpPost]
        public ActionResult EditCertifications(Certifications p)
        {
            var values = repo.FindWhere(x => x.Id == p.Id);
            values.Title = p.Title;
            values.Date = p.Date;
            repo.Update();
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public ActionResult AddCertifications()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult AddCertifications(Certifications p)
        {
            repo.Add(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCertifications(int id)
        {
            var values = repo.FindWhere(x => x.Id == id);
            repo.Delete(values);
            return RedirectToAction("Index");
        }
    }
}