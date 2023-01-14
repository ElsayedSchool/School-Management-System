using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CourseApp
{
    public class CourseDto:IMapFrom<Course>
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string? EnglishName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Course, CourseDto>()
                .ForMember(p => p.Id, opt => opt.MapFrom(s => s.CourseId));
        }
    }
}
