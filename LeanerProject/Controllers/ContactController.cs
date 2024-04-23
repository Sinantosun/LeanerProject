using LeanerProject.Models;
using LeanerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LeanerProject.Controllers
{
    public class ContactController : Controller
    {
        Context Context = new Context();
        public ActionResult Index()
        {

            return View();
        }
        public PartialViewResult ContactInfo()
        {
            var values = Context.Contacts.ToList();
            return PartialView(values);
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult SendMessage(Message message)
        {
            message.IsRead = false;
            Context.Messages.Add(message);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}