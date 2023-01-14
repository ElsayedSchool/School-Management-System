using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ClassApp
{
    public class ClassesListVm : IMapFrom<IEnumerable<Class>>
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public string EnglishName { get; set; }
        public float ClassPrice { get; set; }

        public int HallId { get; set; }
        public string HallName { get; set; }
        
        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public int TeacherId { get; set; }
        public string TeacherName { get; set; }

        public int CourseId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Class, ClassesListVm>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.ClassId));
                //.ForMember(d => d.HallId, opt => opt.MapFrom(s => s.Hall.HallId));
        }
    }
}
