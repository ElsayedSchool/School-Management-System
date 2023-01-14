using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AddressApp
{
    public class GetAllAddressesQueryHandler : IRequestHandler<GetAllAddressesQuery, AddressesListVm>
    {
        private readonly IApplicationRepo _repo;
        private readonly IMapper _mapper;

        public GetAllAddressesQueryHandler(IMapper mapper, IApplicationRepo repo)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<RespDto<AddressesListVm>> Handle(GetAllAddressesQuery request, CancellationToken cancellationToken)
        {
            var branches = await _repo.BranchRepo.GetAllAsync();
            return _mapper.Map <RespDto<AddressesListVm>>(branches);
        }
    }
}
