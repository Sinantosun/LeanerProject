using FluentValidation.Results;
using LeanerProject.Models;
using LeanerProject.ValidationRules.StudentRules;
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
                return RedirectToAction("Index", "StudentCourse");
            }
            else
            {
                ModelState.AddModelError("","Kullanıcı Adı Veya Şifre Hatalı");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Student student)
        {
            StudentValidator validationRules = new StudentValidator();
            ValidationResult validationResult = validationRules.Validate(student);
            if (validationResult.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                TempData["Result"] = "kaydınız oluşturuldu";
                return RedirectToAction("Index");
            }
            else
            {
                string err = string.Join("<br>", validationResult.Errors.Select(x => x.ErrorMessage));
                TempData["Result"] = err;
                return View();
            }
     
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Default");
        }
    }
}