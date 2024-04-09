using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeanerProject.Controllers
{
    public class AdminLayoutController : Controller
    {
        // GET: AdminLayout
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