using MvcProject.Models.Entity;
using Newtonsoft.Json.Linq;
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
    [AllowAnonymous]
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admins p)
        {
            using (var db = new CvProjectMVCEntities())
            { 
                var admin = db.Admins.FirstOrDefault(x => x.UserName == p.UserName);
                if (admin != null)
                {
                    if (!ValidateMD5HashData(p.Password, admin.Password))
                    {
                        ModelState.AddModelError("Password", "Kullanıcı adı ya da şifre yanlış.");
                        return View(admin);
                    }
                    FormsAuthentication.SetAuthCookie(p.UserName, true);
                    Session[p.UserName] = admin.UserName.ToString();
                    return RedirectToAction("Index", "Default");
                }
                ModelState.AddModelError("Password", "Kullanıcı adı ya da şifre yanlış.");
                return View();
            }
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

        [HttpGet]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}