using Application.Common.Mediatr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AddressApp
{
    public class GetAddressDetailQuery: IRequestWrapper<BarnchDetailVm>
    {
        public int Id { get; set; }
    }
}
