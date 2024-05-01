using LeanerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeanerProject.Controllers
{
    public class TeacherLayoutController : Controller
    {
        // GET: TeacherLayout
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult _TeacherHeadPartial()
        {
            return PartialView();
        }

        public PartialViewResult _TeacherSideBarPartial()
        {
            return PartialView();
        }

        

        public PartialViewResult _TeacherNavbarPartial()
        {
            int id = Convert.ToInt32(Session["teacherId"]);
            Context _context = new Context();
            var name = _context.teachers.Find(id).NameSurname;
            ViewBag.NameSurname = name;
            return PartialView();
        }

        public PartialViewResult _TeacherFooterPartial()
        {
            return PartialView();
        }

        public PartialViewResult _TeacherScriptsPartial()
        {
            return PartialView();
        }
    }
}