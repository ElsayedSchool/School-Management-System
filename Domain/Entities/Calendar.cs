using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Calendar
    {
        public DateTime CalendarId { get; set; }
        public int DayNum { get; set; }
        public Month Month { get; set; }
        public int Year { get; set; }
        public bool IsVacation { get; set; }
        public bool IsHoliday { get; set; }
    }
}
