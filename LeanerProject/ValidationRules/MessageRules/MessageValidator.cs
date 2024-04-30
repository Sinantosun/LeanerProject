using FluentValidation;
using LeanerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeanerProject.ValidationRules.MessageRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("E mail adresi boş olamaz");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Geçersiz email adresi");

            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj içeriği boş geçilemez");
            RuleFor(x => x.ReciverNameSurname).NotEmpty().WithMessage("Mesaj alıcı adı soyadı boş geçilemez");
            RuleFor(x => x.SenderNameSurname).NotEmpty().WithMessage("Mesaj gönderen adı soyadı boş geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Mesaj başlığı boş geçilemez");
       

        }
    }
}