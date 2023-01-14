using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TeacherApp
{
    public class TeachersListVm : IMapFrom<Teacher>
    {
        public int Id { get; set; }
        public string TeacherName { get; set; }
        public string JobTtitle { get; set; }
        public string Phone { get; set; }
        public int CourseId { get; set; }
        public string Course { get; set; }
        public int? ManagerId { get; set; }
        public string? ManagerName { get; set; }
        public int YearsOfExperience { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Teacher, TeachersListVm>()
                .ForMember(s => s.Id, opt => opt.MapFrom(d => d.TeacherId));
        }
    }
}
