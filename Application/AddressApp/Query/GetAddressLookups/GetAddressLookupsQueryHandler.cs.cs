using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AddressApp
{
    public class GetAddressLookupsQueryHandler : IRequestHandler<GetAddressLokkupsQuery, List<Country>>
    {
        private readonly IApplicationRepo _repo;

        public GetAddressLookupsQueryHandler(IApplicationRepo repo)
        {
            _repo = repo;
        }


        public async Task<RespDto<List<Country>>> Handle(GetAddressLokkupsQuery request, CancellationToken cancellationToken)
        {
            return await _repo.CountryRepo.GetAllAddressLookups();
        }
    }
}
