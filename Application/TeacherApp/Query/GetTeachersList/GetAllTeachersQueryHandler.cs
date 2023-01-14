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
    public class GetAllTeachersQueryHandler : IRequestHandler<GetAllTeachersQuery, List<TeachersListVm>>
    {
        private readonly IApplicationRepo _repo;
        private readonly IMapper _mapper;

        public GetAllTeachersQueryHandler(IApplicationRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<RespDto<List<TeachersListVm>>> Handle(GetAllTeachersQuery request, CancellationToken cancellationToken)
        {
           
            var teachers = await _repo.TeacherRepo.GetAllTeachers();
            return _mapper.Map<RespDto<List<TeachersListVm>>>(teachers);
        }
    }
}
