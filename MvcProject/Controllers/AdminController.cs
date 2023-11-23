using MvcProject.Models.Entity;
using MvcProject.Repository;
using Org.BouncyCastle.Crypto.Tls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<Admins> generic = new GenericRepository<Admins>();
        public ActionResult Index()
        {
            var values = generic.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(Admins p)
        {
            p.Password = GetMD5HashData(p.Password);
            generic.Add(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditUser(int id)
        {
            var find = generic.FindWhere(x => x.Id == id);
            find.Password = null;
            return View(find);
        }
        [HttpPost]
        public ActionResult EditUser(Admins p)
        {
            var find = generic.FindWhere(x => x.Id == p.Id);
            if (!ValidateMD5HashData(p.OldPassword, find.Password))
            {
                ModelState.AddModelError("OldPassword", "Eski şifre yanlış.");
                return View(find);
            }
            find.UserName = p.UserName;
            find.Password = GetMD5HashData(p.Password);
            generic.Update();
            ViewBag.Message = "Güncelleme başarılı";
            return RedirectToAction("Index");
        }
        public ActionResult DeleteUser(int id)
        {
            var find = generic.FindWhere(x => x.Id == id);
            generic.Delete(find);
            return RedirectToAction("Index");
        }

        private string GetMD5HashData(string data)
        {
            MD5 md5 = MD5.Create();
            byte[] hashData = md5.ComputeHash(Encoding.Default.GetBytes(data));
            StringBuilder returnValue = new StringBuilder();
            for (int i = 0; i < hashData.Length; i++)
            {
                returnValue.Append(hashData[i].ToString());
            }
            return returnValue.ToString();
        }

        private bool ValidateMD5HashData(string inputData, string storedHashData)
        {
            string getHashInputData = GetMD5HashData(inputData);
            if (string.Compare(getHashInputData, storedHashData) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}