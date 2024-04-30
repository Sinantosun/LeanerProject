using LeanerProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeanerProject.Controllers
{
    public class TeacherReviewsController : Controller
    {
        Context _context = new Context();
        public ActionResult Index()
        {
            var value = _context.Courses.Include(x => x.Reviews).Where(x => x.TeacherID == 1).ToList();
            return View(value);
        }
        public ActionResult TeacherRewievDetail(int id)
        {
            var value = _context.Reviews.Include(x=>x.Course).Include(x=>x.Student).Where(x => x.CourseId == id).ToList();
            ViewBag.TeacherCourseName = _context.Courses.FirstOrDefault(x => x.CourseId == id).CourseName;
            return View(value);
        }
    }
}