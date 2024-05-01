using LeanerProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeanerProject.Controllers
{
    public class StudentCourseController : Controller
    {
        Context _context = new Context();
        public ActionResult Index()
        {

            int id = Convert.ToInt32(Session["StudentID"]);
            var values = _context.CourseRegisters.Include(x => x.Course).Include(x=>x.Course.Reviews).Where(x => x.StudentId == id).ToList();
            return View(values);
        }

        public ActionResult StudentCourseVideos(int id)
        {
            var value = _context.courseVideos.OrderBy(x=>x.VideoNumber).Where(x => x.CourseId == id).ToList();
            return View(value);
        }
    }
}