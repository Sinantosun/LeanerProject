using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeanerProject.Models.Entities
{
    public class CourseVideo
    {
        public int CourseVideoID { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public int VideoNumber { get; set; }
        public string VideoURL { get; set; }
    }
}