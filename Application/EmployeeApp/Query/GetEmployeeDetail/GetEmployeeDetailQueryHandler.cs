using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EmployeeApp
{
    public class GetEmployeeDetailQueryHandler : IRequestHandler<GetEmployeeDetailQuery, EmployeeDetailVm>
    {
        private readonly IApplicationRepo _repo;
        private readonly IMapper _mapper;

        public GetEmployeeDetailQueryHandler(IApplicationRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<RespDto<EmployeeDetailVm>> Handle(GetEmployeeDetailQuery request, CancellationToken cancellationToken)
        { 
            return new RespDto<EmployeeDetailVm>() { Data = new EmployeeDetailVm() { Id = 10} };
        }
    }
}
