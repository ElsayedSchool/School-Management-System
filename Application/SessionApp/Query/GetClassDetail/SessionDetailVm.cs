using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SessionApp
{
    public class SessionDetailVm : IMapFrom<Session>
    {
        public int Id { get; set; }
    }
}
