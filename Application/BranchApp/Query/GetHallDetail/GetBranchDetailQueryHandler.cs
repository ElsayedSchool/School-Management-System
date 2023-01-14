using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BranchApp
{
    public class GetBranchDetailQueryHandler : IRequestHandler<GetBranchDetailQuery, BranchDetailVm>
    {
        private readonly IApplicationRepo _repo;
        private readonly IMapper _mapper;

        public GetBranchDetailQueryHandler(IApplicationRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<RespDto<BranchDetailVm>> Handle(GetBranchDetailQuery request, CancellationToken cancellationToken)
        { 
            return new RespDto<BranchDetailVm>() { Data = new BranchDetailVm() { Id = 10} };
        }
    }
}
