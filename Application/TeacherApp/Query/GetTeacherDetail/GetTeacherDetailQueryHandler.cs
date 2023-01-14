using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TeacherApp
{
    public class GetTeacherDetailQueryHandler : IRequestHandler<GetTeacherDetailQuery, TeacherDetailVm>
    {
        private readonly IApplicationRepo _repo;
        private readonly IMapper _mapper;

        public GetTeacherDetailQueryHandler(IApplicationRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<RespDto<TeacherDetailVm>> Handle(GetTeacherDetailQuery request, CancellationToken cancellationToken)
        { 
            return new RespDto<TeacherDetailVm>() { Data = new TeacherDetailVm() { Id = 10} };
        }
    }
}
