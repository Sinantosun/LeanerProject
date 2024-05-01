using LeanerProject.Models;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LeanerProject.Controllers
{
    public class StudentLoginController : Controller
    {
        Context _context = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Student student)
        {
            var values = _context.Students.FirstOrDefault(x => x.UserName == student.UserName && x.Password == student.Password);
            if (values != null)
            {
            
                FormsAuthentication.SetAuthCookie(values.NameSurname, false);
                Session["StudentName"] = values.NameSurname;
                return RedirectToAction("Index", "Default");
            }
            else
            {
                ModelState.AddModelError("","Kullanıcı Adı Veya Şifre Hatalı");
            }
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Default");
        }
    }
}