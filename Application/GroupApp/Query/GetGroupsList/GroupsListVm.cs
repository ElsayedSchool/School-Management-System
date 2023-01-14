using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.GroupApp
{
    public class GroupsListVm : IMapFrom<IEnumerable<Group>>
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public int StudentPayment { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Group, GroupsListVm>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.GroupId));
                //.ForMember(d => d.HallsCount, opt => opt.MapFrom(s => s.Halls.Count()));
        }
    }
}
