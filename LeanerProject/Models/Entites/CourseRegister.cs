

namespace LeanerProject.Models.Entites
{
    public class CourseRegister
    {
        public int CourseRegisterID { get; set; }
        public int StudentsID { get; set; }
        public virtual Students Student { get; set; }

        public int CourseID { get; set; }
        public virtual Course Course { get; set; }
    }
}