using Application.Common.Mediatr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HallApp
{
    public class GetHallDetailQuery: IRequestWrapper<HallDetailVm>
    {
        public int Id { get; set; }
    }
}
