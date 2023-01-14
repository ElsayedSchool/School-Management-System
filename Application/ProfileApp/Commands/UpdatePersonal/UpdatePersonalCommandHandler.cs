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
    public class UpdatePersonalCommandHandler : IRequestHandler<UpdatePersonalCommand, bool>
    {
        private readonly IApplicationRepo _repo;

        public UpdatePersonalCommandHandler(IApplicationRepo repo)
        {
            _repo = repo;
        }


        public async Task<RespDto<bool>> Handle(UpdatePersonalCommand request, CancellationToken cancellationToken)
        {
            UserProfile? personal;
            var isBranchExist = await _repo.ProfileRepo.HasAnyWithMessage(p => p.UserProfileId == request.Id);
            if (isBranchExist == null || isBranchExist.Data == false) return isBranchExist;

            var Profile = await _repo.ProfileRepo.FindByIdAsync(request.Id);
            if (Profile == null || Profile?.Data == null || Profile?.Error == true) return Profile.GetNotFoundError("Profile");
            personal = Profile?.Data;

            personal.Photo = request.Photo;
            personal.PhotoPath = request.PhotoPath;
            personal.BirthDate = request.BirthDate;
           
            await _repo.Commit();
            return new RespDto<bool>() { Data = true };
        }
    }
}
