using LeanerProject.Models;
using LeanerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeanerProject.Controllers
{
    public class TeacherProfileController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {

            int Id = Convert.ToInt32(Session["teacherId"].ToString());
            var value = context.teachers.FirstOrDefault(x => x.TeacherID == Id);
            return View(value);
        }

        [HttpPost]
        public ActionResult Index(Teacher teacher)
        {
            var value = context.teachers.Find(teacher.TeacherID);
            value.NameSurname = teacher.NameSurname;
            value.UserName = teacher.UserName;
            if (teacher.Password != null)
            {
                value.Password = teacher.Password;
            }
            context.SaveChanges();
            return View(value);
        }
    }
}