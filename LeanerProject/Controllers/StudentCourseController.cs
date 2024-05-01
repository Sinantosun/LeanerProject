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
            //string session = Session["StudentName"].ToString();
            //var studentId = _context.Students.FirstOrDefault(x => x.NameSurname == session).StudentId;
            var values = _context.CourseRegisters.Include(x => x.Course).Where(x => x.StudentId == 7).ToList();
            return View(values);
        }

        public ActionResult StudentCourseVideos(int id)
        {
            var value = _context.courseVideos.OrderBy(x=>x.VideoNumber).Where(x => x.CourseId == id).ToList();
            return View(value);
        }
    }
}