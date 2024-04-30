using FluentValidation.Results;
using LeanerProject.Models;
using LeanerProject.Models.Entities;
using LeanerProject.ValidationRules.MessageRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace LeanerProject.Controllers
{
    public class UIContactController : Controller
    {
        Context _context = new Context();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Message message)
        {
            message.ReciverNameSurname = "Admin";
            message.IsDeleted = false;
            message.IsRead = false;
            message.MessageDate = Convert.ToDateTime(DateTime.Now.ToString("g"));
            message.RoleType = "Üye";
            MessageValidator validationRules = new MessageValidator();
            ValidationResult validationResult = validationRules.Validate(message);
            if (validationResult.IsValid)
            {
                _context.Messages.Add(message);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                var err = string.Join("<br>", validationResult.Errors.Select(x => x.ErrorMessage));
                TempData["Result"] = err;
                return View();
            }

         
        }
        public PartialViewResult ContactDetail()
        {
            var value = _context.Contacts.ToList();
            return PartialView(value);
        }

        
    }
}