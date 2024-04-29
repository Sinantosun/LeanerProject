using FluentValidation.Results;
using LeanerProject.Models;
using LeanerProject.Models.Entities;
using LeanerProject.ValidationRules.ContactRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeanerProject.Controllers
{
    public class ContactController : Controller
    {
        Context _context = new Context();
        public ActionResult Index()
        {
            var value = _context.Contacts.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddContact(Contact contact)
        {

            ContactValidator validationRules = new ContactValidator();
            ValidationResult validationResult = validationRules.Validate(contact);
            if (validationResult.IsValid)
            {
                _context.Contacts.Add(contact);
                _context.SaveChanges();
                TempData["Result"] = "kayıt eklendi";
                return RedirectToAction("Index");
            }
            else
            {
                string err = string.Join("<br>", validationResult.Errors.Select(x => x.ErrorMessage));
                TempData["Result"] = err;
                return View();
            }
         
        }

        public ActionResult DeleteContact(int id)
        {
            var value = _context.Contacts.Find(id);
            _context.Contacts.Remove(value);
            _context.SaveChanges();
            TempData["Result"] = "Kayıt Silindi";
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var value = _context.Contacts.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateContact(Contact contact)
        {

            ContactValidator validationRules = new ContactValidator();
            ValidationResult validationResult = validationRules.Validate(contact);
            if (validationResult.IsValid)
            {
                var value = _context.Contacts.Find(contact.ContactID);
                value.Address = contact.Address;
                value.Email = contact.Email;
                value.OpenHours = contact.OpenHours;
                value.Phone = contact.Phone;
              
                _context.SaveChanges();
                TempData["Result"] = "kayıt güncellendi";
                return RedirectToAction("Index");
            }
            else
            {
                string err = string.Join("<br>", validationResult.Errors.Select(x => x.ErrorMessage));
                TempData["Result"] = err;
                return View();
            }

        }
    }
}