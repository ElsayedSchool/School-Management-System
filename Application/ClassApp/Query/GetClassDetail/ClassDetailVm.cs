using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ClassApp
{
    public class ClassDetailVm : IMapFrom<Class>
    {
        public int Id { get; set; }
    }
}
