using LeanerProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeanerProject.Controllers
{
    public class CourseUIController : Controller
    {
        Context _context = new Context();
        public ActionResult Index()
        {
            var value = _context.Courses.Include(x => x.Reviews).Include(x => x.Courses).ToList();
            return View(value);
        }
    }
}