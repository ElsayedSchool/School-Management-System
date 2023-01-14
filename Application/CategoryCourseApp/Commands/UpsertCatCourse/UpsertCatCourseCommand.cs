using Application.Common.Mediatr;
using Domain.Entities;

namespace Application.CategoryCourseApp
{
    
    public class UpsertCategoryCourseCommand : IRequestWrapper<bool>
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int CourseId { get; set; }
        public string CourseDesc { get; set; }
        public string EnglishDesc { get; set; }
    }
}
