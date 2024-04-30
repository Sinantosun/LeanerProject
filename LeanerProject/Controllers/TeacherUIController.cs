using LeanerProject.Models;
using LeanerProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeanerProject.Controllers
{
    public class TeacherUIController : Controller
    {

        Context _context = new Context();
        public ActionResult Index()
        {
            List<UITeacherViewModel> list = new List<UITeacherViewModel>();
            var value = _context.teachers.Include(x => x.courses).ToList();
            foreach (var item in value)
            {
                list.Add(new UITeacherViewModel
                {
                    TeacherID = item.TeacherID,
                    NameSurname = item.NameSurname,
                    CourseCount = item.courses.Where(x => x.TeacherID == item.TeacherID).Count().ToString(),
                });
            }
            return View(list);
        }

        public ActionResult TeacherCoursesDetail(int id)
        {
            var value = _context.Courses.Include(x => x.Reviews).Include(x => x.Courses).Where(x => x.TeacherID == id).ToList();
            ViewBag.TeacherName = value.Select(x => x.Teacher.NameSurname).FirstOrDefault();

            return View(value);
        }
    }
}