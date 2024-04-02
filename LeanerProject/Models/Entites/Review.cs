
namespace LeanerProject.Models.Entites
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int CourseID { get; set; }
        public virtual Course Course { get; set; }
        public double ReviewValue { get; set; }
        public string Comment { get; set; }

        public int StudentsID { get; set; }
        public virtual Students Students { get; set; }
    }
}