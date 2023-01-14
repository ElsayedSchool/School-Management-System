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
    public class UpsertAddressCommandHandler : IRequestHandler<UpsertAddressCommand, bool>
    {
        private readonly IApplicationRepo _repo;

        public UpsertAddressCommandHandler(IApplicationRepo repo)
        {
            _repo = repo;
        }


        public async Task<RespDto<bool>> Handle(UpsertAddressCommand request, CancellationToken cancellationToken)
        {
            Address address;

            var isRegionExist = await _repo.RegionRepo.HasAnyWithMessage(p => p.RegionId == request.RegionId);
            if (isRegionExist == null || isRegionExist.Data == false) return new RespDto<bool>().Get400Error(isRegionExist.Message);

            if (request.AddressId > 0)
            {
                var addressResp = await _repo.AddressRepo.FindByIdAsync(request.AddressId);
                if(addressResp == null || addressResp.Data == null || addressResp.HasError()) return new RespDto<bool>().Get400Error(addressResp.Message);


                address = addressResp.Data;
            }else
            {
                address = new Address();
                await _repo.AddressRepo.CreateAsync(address);
            }

            address.PostalCode = request.PostalCode;
            address.RegionId = request.RegionId;

            await _repo.Commit();
            return new RespDto<bool>() { Data = true };
        }
    }
}
