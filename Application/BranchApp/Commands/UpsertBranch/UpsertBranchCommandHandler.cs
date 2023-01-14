using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BranchApp
{
    public class UpsertBranchCommandHandler : IRequestHandler<UpsertBranchCommand, bool>
    {
        private readonly IApplicationRepo _repo;

        public UpsertBranchCommandHandler(IApplicationRepo repo)
        {
            _repo = repo;
        }


        public async Task<RespDto<bool>> Handle(UpsertBranchCommand request, CancellationToken cancellationToken)
        {
            Branch? branch;

            if(request.Id != 0)
            {
                var storedBranch = await _repo.BranchRepo.FindByIdAsync(request.Id);
                if (storedBranch == null || storedBranch?.Data == null || storedBranch?.Error == true) return storedBranch.GetNotFoundError("Branch");
                branch = storedBranch?.Data;
                
            }else
            {
                branch = new Branch();
                await _repo.BranchRepo.CreateAsync(branch);
            }

            branch.BranchName = request.BranchName;
            branch.BranchDesc = request.BranchDesc;
            branch.Phone1 = request.Phone1;
            branch.Phone2 = request.Phone2;
            branch.Email = request.Email;
            branch.CountryId = request.CountryId;
            branch.CityId = request.CityId;
            branch.RegionId = request.RegionId;
            branch.Street = request.Street;
            //branch.AddressDesc
            branch.CenterId = await _repo.CenterRepo.GetCenterId();

            await _repo.Commit();
            return new RespDto<bool>() { Data = true };
        }
    }
}
