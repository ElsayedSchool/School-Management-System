using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Teacher
    {
        public Teacher()
        {
            this.Classes = new List<Class>();
        }

        public int TeacherId { get; set; }

        public int YearsOfExperience { get; set; }

        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        public virtual UserProfile Profile { get; set; }

        public virtual ICollection<Class> Classes { get; private set; }
    }
}
