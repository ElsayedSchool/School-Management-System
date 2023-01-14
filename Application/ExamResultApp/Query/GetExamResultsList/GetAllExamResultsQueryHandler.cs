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
    public class GetAllExamResultsQueryHandler : IRequestHandler<GetAllExamResultsQuery, List<ExamResultsListVm>>
    {
        private readonly IApplicationRepo _repo;
        private readonly IMapper _mapper;

        public GetAllExamResultsQueryHandler(IApplicationRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<RespDto<List<ExamResultsListVm>>> Handle(GetAllExamResultsQuery request, CancellationToken cancellationToken)
        {
           
            var ExamResults = await _repo.ExamResultRepo.GetAllAsync();
            return _mapper.Map<RespDto<List<ExamResultsListVm>>>(ExamResults);
        }
    }
}
