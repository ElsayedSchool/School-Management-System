using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Exam
    {

        public Exam()
        {
           this.Results = new List<ExamResult>();
        }


        public int ExamId { get; set; }
        public string OverView { get; set; }
        public int ClassId { get; set; }
        public int? SessionId { get; set; }
        public DateTime? Date { get; set; }
        public int TotalDegree { get; set; }


        public virtual Class Class { get; set; }
        public virtual Session Session { get; set; }
        public virtual ICollection<ExamResult> Results { get; set; }

    }
}
