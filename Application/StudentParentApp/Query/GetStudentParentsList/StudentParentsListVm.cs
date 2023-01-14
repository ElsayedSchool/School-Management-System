using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.StudentParentApp
{
    public class StudentParentsListVm : IMapFrom<StudentParent>
    {
        public int Id { get; set; }
        public bool IsApproved { get; set; }
        
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentPhone { get; set; }
        
        public int ParentId { get; set; }
        public string ParentName { get; set; }
        public string ParentPhone { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<StudentParent, StudentParentsListVm>()
                .ForMember(s => s.Id, opt => opt.MapFrom(d => d.StudentParentId));
        }
    }
}
