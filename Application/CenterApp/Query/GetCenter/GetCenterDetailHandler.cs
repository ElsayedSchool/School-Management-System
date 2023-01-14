using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CenterApp.Query.GetCenter
{
    public class GetCenterDetailHandler : IRequestHandler<GetCenterQuery, CenterDetailVm>
    {
        private readonly IApplicationRepo _db;
        private readonly IMapper _mapper;

        public GetCenterDetailHandler(IApplicationRepo db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<RespDto<CenterDetailVm>> Handle(GetCenterQuery request, CancellationToken cancellationToken)
        {
            var centerDetails = await _db.CenterRepo.GetAllAsync();
            if (centerDetails.Error == true) return new RespDto<CenterDetailVm>() { Error = true, Message = centerDetails.Message, StatusCode = centerDetails.StatusCode };

            if (centerDetails == null || centerDetails.Data.Count() == 0) return new RespDto<CenterDetailVm>()
                    .Get500Error("There is not Center Data, Please Add a new Center");

            return new RespDto<CenterDetailVm>() { Data = _mapper.Map<CenterDetailVm>(centerDetails.Data.FirstOrDefault()) };
        }
    }
}
