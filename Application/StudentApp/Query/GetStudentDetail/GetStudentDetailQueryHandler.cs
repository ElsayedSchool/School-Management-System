using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.StudentApp
{
    public class GetStudentDetailQueryHandler : IRequestHandler<GetStudentDetailQuery, StudentDetailVm>
    {
        private readonly IApplicationRepo _repo;
        private readonly IMapper _mapper;

        public GetStudentDetailQueryHandler(IApplicationRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<RespDto<StudentDetailVm>> Handle(GetStudentDetailQuery request, CancellationToken cancellationToken)
        { 
            return new RespDto<StudentDetailVm>() { Data = new StudentDetailVm() { Id = 10} };
        }
    }
}
