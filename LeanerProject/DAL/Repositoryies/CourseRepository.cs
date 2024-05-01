using LeanerProject.Models;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LeanerProject.DAL.Repositoryies
{
    public class CourseRepository : GenericRepository<Course>
    {
        Context _context = new Context();

        public Course getListCourseWithReview(int id)
        {
            return _context.Courses.Include(x => x.Reviews).Include(x=>x.CourseRegisters).FirstOrDefault(x => x.CourseId == id);
        }
        public int getCourseVideoCount(int id)
        {
            return _context.courseVideos.Where(x => x.CourseId == id).Count();

        }
    }
}