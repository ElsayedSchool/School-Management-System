using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Setting
    {
        public int SettingId { get; set; }
        public byte StudentAbsenceWarning { get; set; }
        public byte StudentAbsenceMax { get; set; }
        public byte StaffAbsenceWarning { get; set; }
        public byte StaffAbsenceMax { get; set; }
        public byte TeacherAbsenceWarning { get; set; }
        public byte TeacherAbsenceMax { get; set; }
        public byte StudentGradeWarning { get; set; }
        public byte StudentGradeMin { get; set; }
        public byte StudentPaymentOverdueWarning { get; set; }
        public byte StudentPaymentOverdiewMax { get; set; }
        
        
        
        public int CenterId { get; set; }
        public virtual Center Center { get; set; }
    }
}
