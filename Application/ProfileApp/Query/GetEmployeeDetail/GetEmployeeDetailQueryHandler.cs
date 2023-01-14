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
    public class GetProfileDetailQueryHandler : IRequestHandler<GetProfileDetailQuery, ProfileDetailVm>
    {
        private readonly IApplicationRepo _repo;
        private readonly IMapper _mapper;

        public GetProfileDetailQueryHandler(IApplicationRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<RespDto<ProfileDetailVm>> Handle(GetProfileDetailQuery request, CancellationToken cancellationToken)
        { 
            return new RespDto<ProfileDetailVm>() { Data = new ProfileDetailVm() { Id = 10} };
        }
    }
}
