using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CenterApp.Query.GetSetting
{
    public class GetSettingQueryHandller : IRequestHandler<GetSettingQuery, SettingDetailVm>
    {
        private readonly IApplicationRepo _repo;
        private readonly IMapper _mapper;

        public GetSettingQueryHandller(IApplicationRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<RespDto<SettingDetailVm>> Handle(GetSettingQuery request, CancellationToken cancellationToken)
        {
            var setting = await _repo.CenterSettingRepo.GetAllAsync();


            if(setting.HasError()) return new RespDto<SettingDetailVm>() { Error = setting.Error, Message = setting.Message, StatusCode = setting.StatusCode }; 
            
            if (setting.Data.Count() <= 0) return new RespDto<SettingDetailVm>() { Error = true, Message = "There is no Setting Data, Please Create New Center" };

            return new RespDto<SettingDetailVm>() { Data = _mapper.Map<SettingDetailVm>(setting.Data.FirstOrDefault()) };

        }
    }
}
