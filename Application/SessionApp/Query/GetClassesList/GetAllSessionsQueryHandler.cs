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
    public class GetAllSessionsQueryHandler : IRequestHandler<GetAllSessionsQuery, List<SessionsListVm>>
    {
        private readonly IApplicationRepo _repo;
        private readonly IMapper _mapper;

        public GetAllSessionsQueryHandler(IApplicationRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<RespDto<List<SessionsListVm>>> Handle(GetAllSessionsQuery request, CancellationToken cancellationToken)
        {
            var sessions = await _repo.SessionRepo.GetAllAsync();
            return _mapper.Map<RespDto<List<SessionsListVm>>>(sessions);
        }
    }
}
