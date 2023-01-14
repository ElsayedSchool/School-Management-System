using Application.Common.Mediatr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EmployeeApp
{
    public class GetEmployeeDetailQuery: IRequestWrapper<EmployeeDetailVm>
    {
        public int Id { get; set; }
    }
}
