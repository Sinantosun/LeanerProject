
using LeanerProject.Models.Entities;
using LearnerProject.Models.Entities;
using System.Data.Entity;

namespace LeanerProject.Models
{
    public class Context : DbContext
    {
        public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banner { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Classroom> ClassRooms { get; set; }
        public DbSet<Course>  Courses{ get; set; }
        public DbSet<CourseRegister> CourseRegisters { get; set; }
        public DbSet<FAQ> FAQquestions { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<CategoryIcons> CategoryIcons { get; set; }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<CourseVideo> courseVideos { get; set; }
        public DbSet<Admins> Admins { get; set; }
    }
}