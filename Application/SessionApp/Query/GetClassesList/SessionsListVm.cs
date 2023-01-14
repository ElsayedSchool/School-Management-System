using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SessionApp
{
    public class SessionsListVm : IMapFrom<IEnumerable<Session>>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ClassId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public SessionStatus Status { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public DateTime? ActualEndDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Session, SessionsListVm>();
                
        }
    }
}
