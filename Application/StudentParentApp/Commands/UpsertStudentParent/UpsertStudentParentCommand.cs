using Application.Common.Mediatr;
using Domain.Entities;

namespace Application.StudentParentApp
{
    
    public class UpsertStudentParentCommand : IRequestWrapper<bool>
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ParentId { get; set; }
        public bool IsApproved { get; set; }
    }
}
