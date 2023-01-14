using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ExamApp
{
    public class ExamsListVm : IMapFrom<Exam>
    {
        public int Id { get; set; }
        public string OverView { get; set; }
        public int ClassId { get; set; }
        public int? SessionId { get; set; }
        public DateTime? Date { get; set; }
        public int TotalDegree { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Exam, ExamsListVm>()
                .ForMember(s => s.Id, opt => opt.MapFrom(d => d.ExamId));
        }
    }
}
