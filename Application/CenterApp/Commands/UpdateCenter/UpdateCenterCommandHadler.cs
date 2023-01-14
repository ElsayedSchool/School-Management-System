using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.CenterApp{

    public class UpdateCenterCommandHadler : IRequestHandler<UpdateCenterCommand, bool>
    {
        private readonly IApplicationRepo _repo;
        private readonly IMapper _mapper;

        public UpdateCenterCommandHadler(IApplicationRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<RespDto<bool>> Handle(UpdateCenterCommand request, CancellationToken cancellationToken)
        {
            var center = await _repo.CenterRepo.FindByIdAsync(request.Id);

            if (center == null || center.Data == null)
            {
                return center.GetNotFoundError("This Center Data");
            }

            var updatedCenter = _mapper.Map<Center>(request.Data);
            var resp = await _repo.CenterRepo.UpdateAsync(request.Id, updatedCenter);
            await _repo.Commit();
            return resp;
        }
    }
    
}
