using MvcProject.Models.Entity;
using MvcProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        GenericRepository<Contact> repository = new GenericRepository<Contact>();
        public ActionResult Index()
        {
            var values = repository.List();
            return View(values);
        }

        [HttpPost]
        public ActionResult DeleteContact(List<int> itemIds)
        {
            try
            {
                foreach (var itemId in itemIds)
                {
                    var find = repository.FindWhere(x => x.Id == itemId);
                    repository.Delete(find);
                }

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult ContactDetails(int id)
        {
            var find = repository.FindWhere(x => x.Id == id);
            if(find != null)
            {
                return View(find);
            }
            return RedirectToAction("Index");
        }

    }
}