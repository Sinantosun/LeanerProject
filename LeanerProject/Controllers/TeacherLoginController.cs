using LeanerProject.Models;
using LeanerProject.Models.Entities;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LeanerProject.Controllers
{
    public class TeacherLoginController : Controller
    {
        Context _context = new Context();


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Teacher teacher)
        {
            var values = _context.teachers.FirstOrDefault(x => x.UserName == teacher.UserName && x.Password == teacher.Password);
            if (values == null)
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(values.UserName, false);
                Session["teacherName"] = values.NameSurname;
                return RedirectToAction("Index", "TeacherCourse");
            }

        }

        
    }
}