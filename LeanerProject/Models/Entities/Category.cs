﻿using LeanerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace LearnerProject.Models.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
      
        public bool Status { get; set; } 
        public List<Course> Courses { get; set; }

        public int CategoryIconsID { get; set; }
        public CategoryIcons CategoryIcons { get; set; }


    }
}