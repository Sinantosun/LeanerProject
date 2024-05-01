using LeanerProject.Models;
using PagedList;
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

        int TeacherId()
        {
            int _id = Convert.ToInt32(Session["teacherId"]);
            return _id;
        }

        Context _context = new Context();
        public ActionResult Index(int pageNumber = 1)
        {
            int id = TeacherId();
            var value = _context.Courses.Include(x => x.Reviews).Where(x => x.TeacherID == id).ToList().ToPagedList(pageNumber, 3);
            return View(value);
        }
        public ActionResult TeacherRewievDetail(int id)
        {
            var value = _context.Reviews.Include(x => x.Course).Include(x => x.Student).Where(x => x.CourseId == id).ToList();
            ViewBag.TeacherCourseName = _context.Courses.FirstOrDefault(x => x.CourseId == id).CourseName;
            return View(value);
        }

        public ActionResult DeleteRewiev(int id)
        {
            var valueFind = _context.Reviews.Find(id);
           
            _context.Reviews.Remove(valueFind);
            _context.SaveChanges();
            var value = _context.Reviews.Include(x => x.Course).Include(x => x.Student).Where(x => x.CourseId == valueFind.CourseId).ToList();
            ViewBag.TeacherCourseName = _context.Courses.FirstOrDefault(x => x.CourseId == valueFind.CourseId).CourseName;

            TempData["ResultSuccess"] = "Kurs Yorumu Silindi.";
            return View("TeacherRewievDetail", value);
        }
    }
}