
using System.Collections.Generic;

namespace LeanerProject.Models.Entites
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public int ClassRoomID { get; set; }
        public virtual ClassRoom ClassRoom { get; set; }

        public List<Review> Reviews { get; set; }
        public List<CourseRegister> CourseRegisters { get; set; }
    }
}