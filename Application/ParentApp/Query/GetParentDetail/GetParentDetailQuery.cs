using Application.Common.Mediatr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ParentApp
{
    public class GetParentDetailQuery : IRequestWrapper<ParentDetailVm>
    {
        public int Id { get; set; }
    }
}
