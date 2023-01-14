using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Session
    {
        public Session()
        {
            this.AbsenceStudents = new HashSet<StudentAbsence>();
        }

        public int SessionId { get; set; }
        public string? Title { get; set; }
        public int ClassId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public SessionStatus Status { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public DateTime? ActualEndDate { get; set; }

        public virtual Class Class { get; set; }
        public virtual Exam Exam { get; set; }
        public virtual ICollection<StudentAbsence> AbsenceStudents { get; set; }
    }
}
