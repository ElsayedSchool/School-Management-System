using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ParentApp
{
    public class GetParentDetailQueryHandler : IRequestHandler<GetParentDetailQuery, ParentDetailVm>
    {
        private readonly IApplicationRepo _repo;
        private readonly IMapper _mapper;

        public GetParentDetailQueryHandler(IApplicationRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<RespDto<ParentDetailVm>> Handle(GetParentDetailQuery request, CancellationToken cancellationToken)
        { 
            return new RespDto<ParentDetailVm>() { Data = new ParentDetailVm() { Id = 10} };
        }
    }
}
