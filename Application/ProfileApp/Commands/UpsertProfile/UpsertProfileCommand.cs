using Application.Common.Mappings;
using Application.Common.Mediatr;
using Application.EmployeeApp;
using Application.TeacherApp;
using AutoMapper;

namespace Application.ProfileApp
{
    public class UpsertProfileCommand : IRequestWrapper<int>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string JobTitle { get; set; }
        public bool IsReleased { get; set; }
        public int? ReportsTo { get; set; }

        
    }
}