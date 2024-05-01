using LeanerProject.Models;
using LeanerProject.Models.Entities;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeanerProject.Controllers
{
    public class StudentProfileController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            int Id = Convert.ToInt32(Session["StudentID"].ToString());
            var value = context.Students.FirstOrDefault(x => x.StudentId == Id);
            return View(value);
        }
        [HttpPost]
        public ActionResult Index(Student student)
        {
            var value = context.Students.Find(student.StudentId);
            value.NameSurname = student.NameSurname;
            value.UserName = student.UserName;
            if (student.Password != null)
            {
                value.Password = student.Password;
            }
            context.SaveChanges();
            TempData["ResultSuccess"] = "Profiliniz Güncellendi";
            return View(value);
        }
    }
}