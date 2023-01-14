using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CenterApp.Query.GetCenter
{
    public class CenterDetailVm: IMapFrom<Center>
    {
        public int Id { get; set; }
        public string CenterName { get; set; }
        public string CenterNameInEnglish { get; set; }
        public string OverView { get; set; }
        public bool IsSchoolInstitue { get; set; }
        public bool IsIinitalized { get; set; }
        public DateTime? StartDate { get; set; }
        public string? LogoPhotoPath { get; set; }
        public string? LoginPagePhotoPath { get; set; }

        public string OwnerId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Center, CenterDetailVm>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.CenterId))
                .ReverseMap();
        }
    }
}
