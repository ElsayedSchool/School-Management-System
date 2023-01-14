using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ExamApp
{
    public class ExamDetailVm: IMapFrom<Exam>
    {
        public int Id { get; set; }
    }
}
