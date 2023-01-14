using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProfileApp
{
    public class UpsertProfileCommandHandler : IRequestHandler<UpsertProfileCommand, int>
    {
        private readonly IApplicationRepo _repo;

        public UpsertProfileCommandHandler(IApplicationRepo repo)
        {
            _repo = repo;
        }


        public async Task<RespDto<int>> Handle(UpsertProfileCommand request, CancellationToken cancellationToken)
        {
            UserProfile? profile;

            if(request.Id != 0)
            {
                var userProfile = await _repo.ProfileRepo.FindByIdAsync(request.Id);
                if (userProfile == null || userProfile?.Data == null || userProfile?.Error == true) return new RespDto<int>() { Data = 0, Error = true, Message = userProfile.Message};
                profile = userProfile?.Data;
            }else
            {
                profile = new UserProfile();
                await _repo.ProfileRepo.CreateAsync(profile);
                profile.HireDate = DateTime.Now;
            }

            profile.FirstName = request.FirstName;
            profile.LastName = request.LastName;
            profile.Phone = request.Phone;
            profile.JobTitle = request.JobTitle;
            profile.ReportsTo = request.ReportsTo == null || request.ReportsTo == 0 ? null : request.ReportsTo;
            profile.ReleaseDate = request.IsReleased ? DateTime.Now : null;

            await _repo.Commit();
            return new RespDto<int>() { Data = profile.UserProfileId };
        }
    }
}
