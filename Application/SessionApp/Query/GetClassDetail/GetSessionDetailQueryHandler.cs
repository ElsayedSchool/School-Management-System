using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SessionApp
{
    public class GetSessionDetailQueryHandler : IRequestHandler<GetSessionDetailQuery, SessionDetailVm>
    {
        private readonly IApplicationRepo _repo;
        private readonly IMapper _mapper;

        public GetSessionDetailQueryHandler(IApplicationRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<RespDto<SessionDetailVm>> Handle(GetSessionDetailQuery request, CancellationToken cancellationToken)
        { 
            return new RespDto<SessionDetailVm>() { Data = new SessionDetailVm() { Id = 10} };
        }
    }
}
