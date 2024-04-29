using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeanerProject.Models.Entities
{
    public class Message
    {
        public int MessageID { get; set; }
        public string SenderNameSurname { get; set; }
        public string ReciverNameSurname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string MessageContent { get; set; }
        public string Attachment { get; set; }
        public string AttachmentNormalizeName { get; set; }
        public bool IsRead { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime MessageDate { get; set; }

      
    }
}