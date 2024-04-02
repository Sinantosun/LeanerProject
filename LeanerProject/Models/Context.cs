
using LeanerProject.Models.Entites;
using System.Data.Entity;

namespace LeanerProject.Models
{
    public class Context : DbContext
    {
        public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banner { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<Course>  Courses{ get; set; }
        public DbSet<CourseRegister> CourseRegisters { get; set; }
        public DbSet<FAQquestions> FAQquestions { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
    }
}