using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Course
    {
        public Course()
        {
            this.CategoryCourses = new List<CategoryCourse>();
            this.Teachers = new List<Teacher>();    
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string? EnglishName { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<CategoryCourse> CategoryCourses { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
