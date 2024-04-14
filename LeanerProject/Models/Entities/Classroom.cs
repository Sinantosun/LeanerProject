using LeanerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnerProject.Models.Entities
{
    public class Classroom
    {
        public int ClassroomId { get; set; }
        public string Name { get; set; }

        public int CategoryIconsID { get; set; }
        public CategoryIcons CategoryIcons { get; set; }
        public string Description { get; set; }
        
    }
}