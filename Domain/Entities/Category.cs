using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category
    {

        public Category()
        {
            this.SubCategories = new List<Category>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string? EnglishName { get; set; }
        public int? CategoryParentId { get; set; }
        public bool IsDeleted { get; set; }


        public virtual ICollection<Category> SubCategories { get; set; }
        public virtual ICollection<CategoryCourse> CategoryCourses { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}
