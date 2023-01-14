using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.StudentGroupApp
{
    public class StudentGroupsListVm : IMapFrom<StudentGroup>
    {
        public int Id { get; set; }
        
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentPhone { get; set; }
        public DateTime JoinDate { get; set; }
        public string GroupName { get; set; }
        
        public int GroupId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<StudentGroup, StudentGroupsListVm>()
                .ForMember(s => s.Id, opt => opt.MapFrom(d => d.StudentGroupId));
        }
    }
}
