using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using Domain.Entities;
using Microsoft.Extensions.Options;

namespace Application.CenterApp{
    public class AddCenterCommandHandler : IRequestHandler<AddCenterCommand, bool>
    {
        private readonly IApplicationRepo _repo;

        public AddCenterCommandHandler(IApplicationRepo repo)
        {
            _repo = repo;
        }
        public async Task<RespDto<bool>> Handle(AddCenterCommand request, CancellationToken cancellationToken)
        {
            var center = new Center()
            {
                CenterName = request.CenterName,
                CenterNameInEnglish = request.CenterNameInEnglish,
                OverView = request.OverView,
                LoginPagePhotoPath = request.LoginPagePhotoPath,
                LogoPhotoPath = request.LogoPhotoPath,
                IsIinitalized = request.IsIinitalized,
                IsSchoolInstitue = request.IsSchoolInstitue,
                OwnerId = request.OwnerId,
            };
            return await _repo.CenterRepo.CreateAsync(center);
        }
    }
}
