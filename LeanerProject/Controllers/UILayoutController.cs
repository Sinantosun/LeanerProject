using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeanerProject.Controllers
{
    public class UILayoutController : Controller
    {
        // GET: UILayout
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult DefaultHeadPartial()
        {
            return PartialView();
        }
        public PartialViewResult DefaultNavbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult DefaultFooterPartial()
        {
            return PartialView();
        }
        public PartialViewResult DefaultScriptsPartial()
        {
            return PartialView();
        }

        
    }
}