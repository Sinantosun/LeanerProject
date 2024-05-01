using LeanerProject.Models;
using LeanerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LeanerProject.Controllers
{
    public class AdminLoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Index(Admins admins)
        {
            Context context = new Context();
            var value = context.Admins.FirstOrDefault(x => x.UserName == admins.UserName && x.Password == admins.Password
            );
            if (value != null)
            {
                FormsAuthentication.SetAuthCookie(value.NameSurname, false);
                Session["UserName"] = value.NameSurname;
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}