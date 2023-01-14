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
    public class GetAllBranchesQueryHandler : IRequestHandler<GetAllBranchesQuery, List<BranchesListVm>>
    {
        private readonly IApplicationRepo _repo;
        private readonly IMapper _mapper;

        public GetAllBranchesQueryHandler(IApplicationRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<RespDto<List<BranchesListVm>>> Handle(GetAllBranchesQuery request, CancellationToken cancellationToken)
        {
            var branches = await _repo.BranchRepo.GetAllAsync();
            var halls = branches.Data.ToList()[0].Halls;
            return _mapper.Map<RespDto<List<BranchesListVm>>>(branches);
        }
    }
}
