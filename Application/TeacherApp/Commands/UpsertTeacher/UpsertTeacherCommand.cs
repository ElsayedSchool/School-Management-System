using Application.Common.Mediatr;
using Domain.Entities;

namespace Application.TeacherApp
{
    
    public class UpsertTeacherCommand : IRequestWrapper<bool>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsReleased { get; set; }
        public int? ReportsTo { get; set; }
        public int YearsOfExperience { get; set; }
        public int CourseId { get; set; }

    }
}
