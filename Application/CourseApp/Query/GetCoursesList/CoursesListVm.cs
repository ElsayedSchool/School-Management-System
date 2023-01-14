using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;


namespace Application.CourseApp
{
    public class CoursesListVm
    {
        public ICollection<CourseDto> Courses { get; set; }
    }
}
