using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeanerProject.Models.ViewModels
{
    public class UITeacherViewModel
    {
        public int TeacherID { get; set; }
        public string NameSurname { get; set; }
        public string CourseCount { get; set; }
    }
}