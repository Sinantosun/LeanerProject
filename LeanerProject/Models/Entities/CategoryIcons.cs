

using LearnerProject.Models.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeanerProject.Models.Entities
{
    public class CategoryIcons
    {
        public int CategoryIconsID { get; set; }
        public string IconType { get; set; }

        public List<Category> categories { get; set; }



    }
}