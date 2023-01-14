using Application.Common.Mediatr;
using Domain.Entities;

namespace Application.StudentGroupApp
{
    
    public class UpsertStudentGroupCommand : IRequestWrapper<bool>
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int GroupId { get; set; }
    }
}
