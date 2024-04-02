

using System.Collections.Generic;

namespace LeanerProject.Models.Entites
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public bool Status { get; set; }

        public List<Course> Courses{ get; set; }
    }
}