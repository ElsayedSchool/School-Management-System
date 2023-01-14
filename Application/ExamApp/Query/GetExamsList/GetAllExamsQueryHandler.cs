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
    public class GetAllExamsQueryHandler : IRequestHandler<GetAllExamsQuery, List<ExamsListVm>>
    {
        private readonly IApplicationRepo _repo;
        private readonly IMapper _mapper;

        public GetAllExamsQueryHandler(IApplicationRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<RespDto<List<ExamsListVm>>> Handle(GetAllExamsQuery request, CancellationToken cancellationToken)
        {
           
            var Exams = await _repo.ExamRepo.GetAllAsync();
            return _mapper.Map<RespDto<List<ExamsListVm>>>(Exams);
        }
    }
}
