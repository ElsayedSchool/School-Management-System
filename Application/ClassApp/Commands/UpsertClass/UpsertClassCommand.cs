using Application.Common.Mediatr;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ClassApp
{
    
    
    public class UpsertClassCommand : IRequestWrapper<bool>
    {
        public int Id { get; set; }
        public int ClassPrice { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
        public int GroupId { get; set; }
        public int HallId { get; set; }

    }
}
