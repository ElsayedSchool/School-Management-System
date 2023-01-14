using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using AutoMapper;

namespace Application.GroupApp
{
    public class GetGroupDetailQueryHandler : IRequestHandler<GetGroupDetailQuery, GroupDetailVm>
    {
        private readonly IApplicationRepo _repo;
        private readonly IMapper _mapper;

        public GetGroupDetailQueryHandler(IApplicationRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<RespDto<GroupDetailVm>> Handle(GetGroupDetailQuery request, CancellationToken cancellationToken)
        { 
            return new RespDto<GroupDetailVm>() { Data = new GroupDetailVm() { Id = 10} };
        }
    }
}
