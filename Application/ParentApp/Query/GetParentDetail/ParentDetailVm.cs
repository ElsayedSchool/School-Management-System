using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ParentApp
{
    public class ParentDetailVm : IMapFrom<Parent>
    {
        public int Id { get; set; }
    }
}
