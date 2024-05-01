using LeanerProject.Models;
using System;
using System.Collections.Generic;
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
            var values = _context.CourseRegisters.Where(x => x.Student.StudentId == 2);
            return View(values);
        }
    }
}