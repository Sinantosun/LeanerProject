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
    public class StudentsController : Controller
    {
        Context _context = new Context();
        [HttpGet]
        public ActionResult Index()
        {
            var value = _context.Students.ToList();
            return View(value);
        }
        [HttpPost]
        public ActionResult Index(string UserName)
        {
            var value = _context.Students.Where(x => x.NameSurname.Contains(UserName)).ToList();
            ViewBag.StudentName = UserName;
            return View("Index",value);
        }

        public ActionResult StudentCourses(int id)
        {
            List<StudentCourseViewModel> list = new List<StudentCourseViewModel>();

            var value = _context.CourseRegisters.Where(x => x.StudentId == id).ToList();
            var studentName = _context.Students.FirstOrDefault(x => x.StudentId == id).NameSurname;
            ViewBag.StudentName = studentName;
            foreach (var item in value)
            {
                list.Add(new StudentCourseViewModel
                {
                    NameSurname = item.Course.CourseName,
                    CourseReviewValue=_context.Reviews.Where(x=>x.StudentId==id&&x.CourseId==item.CourseId).Select(x=>x.ReviewValue).FirstOrDefault().ToString(),
                });
            }
            return View(list);
        }
    }
}