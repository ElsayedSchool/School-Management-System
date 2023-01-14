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
    public class GetAllStudentExamsQueryHandler : IRequestHandler<GetAllStudentExamsQuery, List<StudentExamsListVm>>
    {
        private readonly IApplicationRepo _repo;
        private readonly IMapper _mapper;

        public GetAllStudentExamsQueryHandler(IApplicationRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<RespDto<List<StudentExamsListVm>>> Handle(GetAllStudentExamsQuery request, CancellationToken cancellationToken)
        {
           
            var StudentExams = await _repo.ExamResultRepo.GetAllAsync();
            return _mapper.Map<RespDto<List<StudentExamsListVm>>>(StudentExams);
        }
    }
}
