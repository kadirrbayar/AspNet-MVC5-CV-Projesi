using MvcProject.Models.Entity;
using MvcProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia
        GenericRepository<SocialMedia> repository = new GenericRepository<SocialMedia>();
        public ActionResult Index()
        {
            var values = repository.List();
            return View(values);
        }

        [HttpPost]
        public ActionResult ToggleStatus(int id, bool isChecked)
        {
            var socialMediaItem = repository.FindWhere(x => x.Id == id);
            if (socialMediaItem != null)
            {
                socialMediaItem.Active = isChecked;
                repository.Update();
            }
            return Json(new { success = true });
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            var find = repository.FindWhere(x => x.Id == id);
            repository.Delete(find);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditSocialMedia(int id)
        {
            var find = repository.FindWhere(x => x.Id == id);
            return View(find);
        }

        [HttpPost]
        public ActionResult EditSocialMedia(SocialMedia p)
        {
            var find = repository.FindWhere(x => x.Id == p.Id);
            find.Name = p.Name;
            find.Icon = p.Icon;
            find.Active = p.Active;
            find.Link = p.Link;
            repository.Update();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddSocialMedia(SocialMedia p)
        {
            repository.Add(p);
            return RedirectToAction("Index");
        }
    }
}