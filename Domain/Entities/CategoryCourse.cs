using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CategoryCourse
    {
        public int CategoryCourseId { get; set; }
        public int CategoryId { get; set; }
        public int CourseId { get; set; }
        public SemsterTypes? Semster { get; set; }
        public string CourseDesc { get; set; }
        public string? EnglishDesc { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Category Category { get; set; }
        public virtual Course Course { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
    }
}
