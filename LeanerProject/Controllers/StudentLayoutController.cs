using LeanerProject.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeanerProject.Controllers
{
    public class StudentLayoutController : Controller
    {
        // GET: StudentLayout
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult _StudentHeadPartial()
        {
            return PartialView();
        }

        public PartialViewResult _StudentSideBarPartial()
        {
            return PartialView();
        }

        public PartialViewResult _StudentNavbarPartial()
        {
            int id = Convert.ToInt32(Session["StudentID"]);
            Context context = new Context();
            ViewBag.StudentName = context.Students.FirstOrDefault(x => x.StudentId == id).NameSurname;
            return PartialView();
        }

        public PartialViewResult _StudentFooterPartial()
        {
            return PartialView();
        }

        public PartialViewResult _StudentScriptsPartial()
        {
            return PartialView();
        }
    }
}