using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProfileApp
{
    public class ProfilesListVm : IMapFrom<Profile>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string? HomePhone { get; set; }
        public int Salary { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? WorkStartTime { get; set; }
        public DateTime? WorkEndTime { get; set; }
        public int? AbsenceBalance { get; set; }
        public byte[]? Photo { get; set; }
        public string PhotoPath { get; set; }
        public AppRole Role { get; set; }

        public int BranchId { get; set; }
        public string BranchName { get; set; }

        public int? ManagerId { get; set; }
        public string ManagerName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Profile, ProfilesListVm>();
        }
    }
}
