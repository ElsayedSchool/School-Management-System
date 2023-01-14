using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProfileApp
{
    public class GetAllProfilesQueryHandler : IRequestHandler<GetAllProfilesQuery, List<ProfilesListVm>>
    {
        private readonly IApplicationRepo _repo;
        private readonly IMapper _mapper;

        public GetAllProfilesQueryHandler(IApplicationRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<RespDto<List<ProfilesListVm>>> Handle(GetAllProfilesQuery request, CancellationToken cancellationToken)
        {
           
            var Profiles = await _repo.ProfileRepo.GetAllAsync();
            return null;
        }
    }
}
