using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HallApp
{
    public class GetHallDetailQueryHandler : IRequestHandler<GetHallDetailQuery, HallDetailVm>
    {
        private readonly IApplicationRepo _repo;
        private readonly IMapper _mapper;

        public GetHallDetailQueryHandler(IApplicationRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<RespDto<HallDetailVm>> Handle(GetHallDetailQuery request, CancellationToken cancellationToken)
        { 
            return new RespDto<HallDetailVm>() { Data = new HallDetailVm() { Id = 10} };
        }
    }
}
