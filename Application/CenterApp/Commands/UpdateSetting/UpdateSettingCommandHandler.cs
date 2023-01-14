using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;


namespace Application.CenterApp{
    public class UpdateSettingCommandHandler : IRequestHandler<UpdateSettingCommand, bool>
    {
        private readonly IApplicationRepo _repo;
        private readonly IMapper _mapper;

        public UpdateSettingCommandHandler(IApplicationRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<RespDto<bool>> Handle(UpdateSettingCommand request, CancellationToken cancellationToken)
        {
            var updatedSetting = _mapper.Map<Setting>(request.Data);
            var resp = await _repo.CenterSettingRepo.UpdateAsync(request.Id, updatedSetting);
            await _repo.Commit();
            return resp;
        }
    }
}
