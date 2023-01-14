using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class StudentAbsence
    {
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        public int SessionId { get; set; }
        public virtual Session Session { get; set; }

        public bool IsSick { get; set; }
    }
}
