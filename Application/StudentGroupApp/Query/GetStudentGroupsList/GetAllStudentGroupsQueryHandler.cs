using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using AutoMapper;

namespace Application.StudentGroupApp
{
    public class GetAllStudentGroupsQueryHandler : IRequestHandler<GetAllStudentGroupsQuery, List<StudentGroupsListVm>>
    {
        private readonly IApplicationRepo _repo;
        private readonly IMapper _mapper;

        public GetAllStudentGroupsQueryHandler(IApplicationRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<RespDto<List<StudentGroupsListVm>>> Handle(GetAllStudentGroupsQuery request, CancellationToken cancellationToken)
        {
            var studentGroups = await _repo.StudentGroupRepo.GetAllGroupStudents(request.GroupId);
            return _mapper.Map <RespDto<List<StudentGroupsListVm>>>(studentGroups);
        }
    }
}
