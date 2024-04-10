using LeanerProject.Models;
using LeanerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeanerProject.Controllers
{
    public class CategoryIconsController : Controller
    {
        Context _context = new Context();
        public ActionResult Index()
        {
            var value = _context.CategoryIcons.ToList();


            return View(value);
        }
        [HttpGet]
        public ActionResult AddIcon()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddIcon(CategoryIcons categoryIcons)
        {
            _context.CategoryIcons.Add(categoryIcons);
            _context.SaveChanges();
            TempData["Result"] = "Yeni ikon eklendi.";
            return View();
        }

        public ActionResult DeleteIcon(int id)
        {

            var item = _context.CategoryIcons.Find(id);
            _context.CategoryIcons.Remove(item);
            _context.SaveChanges();
            TempData["Result"] = "Silindi";
            return RedirectToAction("Index");
        }
    }
}