using Application.Common.Mediatr;
using Domain.Entities;

namespace Application.StudentAbsenceApp
{
    
    public class UpsertStudentAbsenceCommand : IRequestWrapper<bool>
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SessionId { get; set; }
        public bool IsSick { get; set; }
    }
}
