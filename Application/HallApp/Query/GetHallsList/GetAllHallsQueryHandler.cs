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
    public class GetAllHallQueryHandler : IRequestHandler<GetAllHallsQuery, List<HallsListVm>>
    {
        private readonly IApplicationRepo _repo;
        private readonly IMapper _mapper;

        public GetAllHallQueryHandler(IApplicationRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<RespDto<List<HallsListVm>>> Handle(GetAllHallsQuery request, CancellationToken cancellationToken)
        {
            var halls = await _repo.HallRepo.GetAllAsync();
            return _mapper.Map<RespDto<List<HallsListVm>>>(halls);
        }
    }
}
