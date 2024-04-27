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
        public ActionResult Index()
        {
            var value = _context.teachers.ToList();
            return View(value);
        }

        public ActionResult TeacherCourses(int id)
        {
            List<TeacherCourseViewModel> list = new List<TeacherCourseViewModel>();

            var value = _context.CourseRegisters.Where(x => x.StudentId == id).ToList();
            var studentName = _context.Students.FirstOrDefault(x => x.StudentId == id).NameSurname;
            ViewBag.StudentName = studentName;
            foreach (var item in value)
            {
                list.Add(new TeacherCourseViewModel
                {
                    NameSurname = item.Course.CourseName,
                    CourseReviewValue = _context.Reviews.Where(x => x.StudentId == id && x.CourseId == item.CourseId).Select(x => x.ReviewValue).FirstOrDefault().ToString(),
                });
            }
            return View(list);
        }
    }
}