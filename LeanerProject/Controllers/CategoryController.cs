using LeanerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeanerProject.Controllers
{
    public class CategoryController : Controller
    {
        Context _context = new Context();
        public ActionResult Index()
        {
            var value = _context.Categories.ToList();
            return View(value);
        }

        public ActionResult ChangeCategoryStatus(int id)
        {
            var value = _context.Categories.Find(id);
            if (value.Status == true)
            {
                value.Status = false;
            }
            else
            {
                value.Status = true;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}