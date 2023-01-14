using Application.Common.Mediatr;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CourseApp{
    
    public class UpsertCourseCommand : IRequestWrapper<bool>
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string EnglishName { get; set; }
    }
}
