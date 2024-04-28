using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeanerProject.Models.Entities
{
    public class Admins
    {
        public int AdminsID { get; set; }
        public string NameSurname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}