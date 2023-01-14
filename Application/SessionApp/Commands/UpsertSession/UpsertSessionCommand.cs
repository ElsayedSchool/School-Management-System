using Application.Common.Mediatr;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SessionApp
{
    
    
    public class UpsertSessionCommand : IRequestWrapper<bool>
    {
        public int Id { get; set; }
        public string Title { get; set; } = "No Title";
        public int ClassId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public SessionStatus Status { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public DateTime? ActualEndDate { get; set; }

    }
}
