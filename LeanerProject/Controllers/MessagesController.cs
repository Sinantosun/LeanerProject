using LeanerProject.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeanerProject.Controllers
{
    public class MessagesController : Controller
    {
        Context _context = new Context();
        public ActionResult Index()
        {
            var values = _context.Messages.ToList();
           
            return View(values);
        }


        public ActionResult MessageDetail(int id)
        {
            var value = _context.Messages.Find(id);
            value.IsRead = true;
            _context.SaveChanges();
            return View(value);
        }

        public PartialViewResult MessagesSide()
        {
            var values = _context.Messages.ToList();
            var TrashMessage = _context.Messages.Where(x => x.IsDeleted == true).Count();
            ViewBag.TrashMessageCount = TrashMessage;
            ViewBag.InboxCount = values.Count();
            return PartialView();
        }
        public ActionResult SendMessage()
        {
            return View();
        }
    }
}