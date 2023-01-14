using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BranchApp
{
    public class BranchesListVm : IMapFrom<IEnumerable<Branch>>
    {
        public int Id { get; set; }
        public string BranchName { get; set; }
        public string BranchDesc { get; set; }
        public string? Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public string? Email { get; set; }
        public List<Hall> Halls { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Branch, BranchesListVm>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.BranchId))
                .ForMember(d => d.Halls, opt => opt.MapFrom(s => s.Halls));
        }
    }
}
