using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeanerProject.Models.Entities
{
    public class CoursesDetails
    {
        public int CoursesDetailsID { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        [AllowHtml]
        public string CourseContent { get; set; }
        [AllowHtml]
        public string CourseDetail { get; set; }
    }
}