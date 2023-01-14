using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CategoryCourseApp
{
    public class CatCoursesListVm : IMapFrom<CategoryCourse>
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string CourseDesc { get; set; }
        public string EnglishDesc { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CategoryCourse, CatCoursesListVm>()
                .ForMember(s => s.Id, opt => opt.MapFrom(d => d.CategoryCourseId));
        }
    }
}
