using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HallApp
{
    public class HallsListVm : IMapFrom<Hall>
    {
        public int Id { get; set; }
        public string HallName { get; set; }
        public int MaxStudents { get; set; }
        public bool IsConditioned { get; set; }
        public double PricePerStudent { get; set; }
        public double PricePerHour { get; set; }
        public double MinReservationTime { get; set; }
        public double HourEquivalentTime { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Hall, HallsListVm>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.HallId));
        }
    }
}
