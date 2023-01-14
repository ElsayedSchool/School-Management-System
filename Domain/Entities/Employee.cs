using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Employee
    {

        public int EmployeeId { get; set; }
        public int Salary { get; set; }
        public DateTime? WorkStartTime { get; set; }
        public DateTime? WorkEndTime { get; set; }
        public int? AbsenceBalance { get; set; }
        public EmployeeStatus Status { get; set; }

        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }

        public virtual UserProfile Profile { get; set; }

    }
}
