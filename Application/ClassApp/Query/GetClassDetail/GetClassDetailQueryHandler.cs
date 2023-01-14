using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ClassApp
{
    public class GetClassDetailQueryHandler : IRequestHandler<GetClassDetailQuery, ClassDetailVm>
    {
        private readonly IApplicationRepo _repo;
        private readonly IMapper _mapper;

        public GetClassDetailQueryHandler(IApplicationRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<RespDto<ClassDetailVm>> Handle(GetClassDetailQuery request, CancellationToken cancellationToken)
        { 
            return new RespDto<ClassDetailVm>() { Data = new ClassDetailVm() { Id = 10} };
        }
    }
}
