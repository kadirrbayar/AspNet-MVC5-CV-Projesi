using MvcProject.Models.Entity;
using MvcProject.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            using (var db = new CvProjectMVCEntities())
            {
                var values = db.About.FirstOrDefault(x => x.Id == 1);
                ViewBag.v1 = values.Image;       
                return View();
            }
        }
        public PartialViewResult About()
        {
            using (var db = new CvProjectMVCEntities())
            {
                var values = db.About.ToList();
                return PartialView(values);
            }
        }
        public PartialViewResult Experience()
        {
            using (var db = new CvProjectMVCEntities())
            {
                var values = db.Experience.ToList();
                return PartialView(values);
            }
        }
        public PartialViewResult Education()
        {
            using (var db = new CvProjectMVCEntities())
            {
                var values = db.Education.ToList();
                return PartialView(values);
            }
        }
        public PartialViewResult Skills()
        {
            using (var db = new CvProjectMVCEntities())
            {
                var values = db.Skills.ToList();
                return PartialView(values);
            }
        }
        public PartialViewResult Interests()
        {
            using (var db = new CvProjectMVCEntities())
            {
                var values = db.Interests.ToList();
                return PartialView(values);
            }
        }
        public PartialViewResult Certifications()
        {
            using (var db = new CvProjectMVCEntities())
            {
                var values = db.Certifications.ToList();
                return PartialView(values);
            }
        }
        public PartialViewResult SocialMedia()
        {
            using (var db = new CvProjectMVCEntities())
            {
                var values = db.SocialMedia.Where(x => x.Active == true).ToList();
                return PartialView(values);
            }
        }
        public PartialViewResult Tools()
        {
            using (var db = new CvProjectMVCEntities())
            {
                var values = db.Tools.ToList();
                return PartialView(values);
            }
        }
        [HttpGet]
        public PartialViewResult Contact()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult AddContact(Contact p)
        {
            GenericRepository<Contact> repository = new GenericRepository<Contact>();
            p.Date = DateTime.Now;
            repository.Add(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }

    }
}