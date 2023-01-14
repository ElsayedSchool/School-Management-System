using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Student:AuditableEntity
    {
        public Student()
        {
            this.Parents = new HashSet<StudentParent>();
            this.Groups = new HashSet<StudentGroup>();
            this.AbsenceList = new HashSet<StudentAbsence>();
            this.Exams = new HashSet<ExamResult>();
            
        }

        public int StudentId { get; set; }
        public string UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get => FirstName + " " + LastName;
        }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<StudentGroup> Groups { get; set; }
        public virtual ICollection<StudentParent> Parents { get; set; }
        public virtual ICollection<StudentAbsence> AbsenceList { get; set; }
        public virtual ICollection<ExamResult> Exams { get; set; }
    }
}
