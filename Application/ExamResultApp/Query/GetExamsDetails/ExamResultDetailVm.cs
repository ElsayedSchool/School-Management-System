using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ExamResultApp
{
    public class ExamResultDetailVm: IMapFrom<ExamResult>
    {
        public int Id { get; set; }
    }
}
