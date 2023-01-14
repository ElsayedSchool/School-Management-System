using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Class
    {

        public Class()
        {
            this.Sessions = new HashSet<Session>();
            this.Exams = new HashSet<Exam>();
        }
        public int ClassId { get; set; }
        public float ClassPrice { get; set; }

        // realtion
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }

        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        
        public int HallId { get; set; }
        public virtual Hall Hall { get; set; }
        
        public int CourseId { get; set; }
        public virtual CategoryCourse Course { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
    }
}
