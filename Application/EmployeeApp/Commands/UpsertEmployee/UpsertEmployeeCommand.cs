using Application.Common.Mediatr;
using Domain.Entities;
using Domain.Enums;

namespace Application.EmployeeApp
{
    
    public class UpsertEmployeeCommand : IRequestWrapper<bool>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsReleased { get; set; }
        public int? ReportsTo { get; set; }
        public int Salary { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? WorkStartTime { get; set; }
        public DateTime? WorkEndTime { get; set; }
        public int? AbsenceBalance { get; set; }
        public int BranchId { get; set; }
    }
}
