using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TeacherApp
{
    public class TeacherDetailVm: IMapFrom<Teacher>
    {
        public int Id { get; set; }
    }
}
