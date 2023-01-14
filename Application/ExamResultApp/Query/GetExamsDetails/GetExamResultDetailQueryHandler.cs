using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ExamResultApp
{
    public class GetExamResultDetailQueryHandler : IRequestHandler<GetExamResultDetailQuery, ExamResultDetailVm>
    {
        private readonly IApplicationRepo _repo;
        private readonly IMapper _mapper;

        public GetExamResultDetailQueryHandler(IApplicationRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<RespDto<ExamResultDetailVm>> Handle(GetExamResultDetailQuery request, CancellationToken cancellationToken)
        { 
            return new RespDto<ExamResultDetailVm>() { Data = new ExamResultDetailVm() { Id = 10} };
        }
    }
}
