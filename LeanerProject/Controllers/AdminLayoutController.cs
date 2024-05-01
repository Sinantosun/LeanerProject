using LeanerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeanerProject.Controllers
{
    public class AdminLayoutController : Controller
    {
     
        public ActionResult Index()
        {
            
            return View();
        }

        public PartialViewResult _AdminHeadPartial()
        {
            return PartialView();
        }

        public PartialViewResult _AdminSideBarPartial()
        {
            return PartialView();
        }

        public PartialViewResult _AdminNavbarPartial()
        {
            int id = Convert.ToInt32(Session["AdminID"]);
            Context context = new Context();
            ViewBag.NameSurname = context.Admins.FirstOrDefault(x => x.AdminsID == id).NameSurname;
            return PartialView();
        }

        public PartialViewResult _AdminFooterPartial()
        {
            return PartialView();
        }

        public PartialViewResult _AdminScriptsPartial()
        {
            return PartialView();
        }
    }
}