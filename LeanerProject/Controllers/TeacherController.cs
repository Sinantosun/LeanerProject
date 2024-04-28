using LeanerProject.Models;
using LeanerProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeanerProject.Controllers
{
    public class TeacherController : Controller
    {
        Context _context = new Context();
        [HttpGet]
        public ActionResult Index()
        {
            var value = _context.teachers.ToList();

            return View(value);
        }
        [HttpPost]
        public ActionResult Index(string UserName)
        {
            var value = _context.teachers.Where(x => x.NameSurname.Contains(UserName)).ToList();
            ViewBag.TeacherName = UserName;
            return View("Index", value);
        }
        public ActionResult TeacherCourses(int id)
        {
            List<TeacherCourseViewModel> list = new List<TeacherCourseViewModel>();

            var value = _context.Courses.Where(x => x.TeacherID == id).ToList();
            var teacherName = _context.teachers.FirstOrDefault(x => x.TeacherID == id).NameSurname;

            ViewBag.TeacherName = teacherName;
            foreach (var item in value)
            {
                var teacherRewivewValue = _context.Reviews.Where(x => x.Course.TeacherID == id && x.CourseId == item.CourseId).ToList();
                string text = "";
                if (teacherRewivewValue.Count == 0)
                {
                    text = "Değerlendirilmedi";
                }
                else
                {
                    text = teacherRewivewValue.Average(y => y.ReviewValue).ToString() + " / 5";
                }
                list.Add(new TeacherCourseViewModel
                {
                    NameSurname = item.CourseName,
                    CourseReviewValue = text
                });
            }
            return View(list);
        }
    }
}