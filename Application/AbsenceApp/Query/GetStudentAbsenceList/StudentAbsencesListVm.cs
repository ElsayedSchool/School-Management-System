using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.StudentAbsenceApp
{
    public class StudentAbsencesListVm : IMapFrom<StudentAbsence>
    {
        public int StudentId { get; set; }
        public int SessionId { get; set; }
        public string StudentName { get; set; }
        public string StudentPhone { get; set; }
        public DateTime AbsenceDate { get; set; }
        public string SessionName { get; set; }
        public bool IsSick { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<StudentAbsence, StudentAbsencesListVm>();
        }
    }
}
