using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using AutoMapper;

namespace Application.StudentAbsenceApp
{
    public class GetAllStudentAbsencesQueryHandler : IRequestHandler<GetAllStudentAbsencesQuery, List<StudentAbsencesListVm>>
    {
        private readonly IApplicationRepo _repo;
        private readonly IMapper _mapper;

        public GetAllStudentAbsencesQueryHandler(IApplicationRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<RespDto<List<StudentAbsencesListVm>>> Handle(GetAllStudentAbsencesQuery request, CancellationToken cancellationToken)
        {
            var StudentAbsences = await _repo.AbsenceRepo.GetAllAbsenceList();
            return _mapper.Map <RespDto<List<StudentAbsencesListVm>>>(StudentAbsences);
        }
    }
}
