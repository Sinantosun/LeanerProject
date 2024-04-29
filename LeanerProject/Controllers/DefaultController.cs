using LeanerProject.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeanerProject.Controllers
{
    public class DefaultController : Controller
    {
        Context _context = new Context();
        public ActionResult Index()
        {
            var registerdStudentCount = _context.Students.Count();
            var registerdTeacherCount = _context.teachers.Count();

            TempData["StudentRegisterCount"] = registerdStudentCount;
            TempData["TeacherRegisterCount"] = registerdTeacherCount;
            return View();
        }
        public PartialViewResult DefaultBannerPartial()
        {
            var values = _context.Banner.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultAboutPartial()
        {
            var values = _context.Abouts.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultCategoryPartial()
        {
            var values = _context.Categories.Include(x => x.CategoryIcons).Include(x => x.Courses).ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultClassRoomsPartial()
        {
            var values = _context.ClassRooms.Include(x => x.CategoryIcons).ToList();

            return PartialView(values);
        }
        public PartialViewResult DefaultReviewsPartial()
        {
            var values = _context.Reviews.Include(x => x.Course).Include(y => y.Student).Take(4).OrderByDescending(y => y.ReviewId).ToList();

            return PartialView(values);
        }
        public PartialViewResult DefaultCoursePartial()
        {
            var values = _context.Courses.Include(x => x.Reviews).Include(x=>x.Courses).OrderByDescending(x => x.CourseId).Take(3).ToList();

            return PartialView(values);
        }
    }
}