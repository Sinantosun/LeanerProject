using FluentValidation;
using LeanerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeanerProject.ValidationRules.ContactRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Address).NotEmpty().WithMessage("Adress Alanı Boş Geçilemez");
            RuleFor(x => x.OpenHours).NotEmpty().WithMessage("Açık Saatler Alanı Boş Geçilemez");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Geçersiz Email Adresi");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email Alanı Boş Geçilemez");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon Alanı Boş Geçilemez");
        }
    }
}