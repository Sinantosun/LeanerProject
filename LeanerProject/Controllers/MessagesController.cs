using LeanerProject.Models;
using LeanerProject.Models.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
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
        [HttpPost]
        public ActionResult SendMessage(Message message)
        {
            if (message.Attachment != null)
            {
                var guid = Guid.NewGuid();
                var ex = Path.GetExtension(Request.Files[0].FileName);
                string fullFile = "~/Images/Messages/" + guid + ex;
                Request.Files[0].SaveAs(Server.MapPath(fullFile));
                message.Attachment = "/Images/Messages/" + guid + ex;
                message.AttachmentNormalizeName = Path.GetFileName(Request.Files[0].FileName) + ex;
            }

            message.SenderNameSurname = "Sinan Tosun";
            message.IsDeleted = false;
            message.MessageDate = DateTime.Now;
            message.IsRead = false;
            _context.Messages.Add(message);
            _context.SaveChanges();
            return View();
        }
    }
}