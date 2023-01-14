using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ExamApp
{
    public class GetExamDetailQueryHandler : IRequestHandler<GetExamDetailQuery, ExamDetailVm>
    {
        private readonly IApplicationRepo _repo;
        private readonly IMapper _mapper;

        public GetExamDetailQueryHandler(IApplicationRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<RespDto<ExamDetailVm>> Handle(GetExamDetailQuery request, CancellationToken cancellationToken)
        { 
            return new RespDto<ExamDetailVm>() { Data = new ExamDetailVm() { Id = 10} };
        }
    }
}
