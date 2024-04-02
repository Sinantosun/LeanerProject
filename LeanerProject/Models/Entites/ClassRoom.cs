
using System.Collections.Generic;

namespace LeanerProject.Models.Entites
{
    public class ClassRoom
    {
        public int ClassRoomID { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }


        public List<Course> Courses { get; set; }


    }
}