using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using AutoMapper;

namespace Application.StudentParentApp
{
    public class GetAllStudentParentsQueryHandler : IRequestHandler<GetAllStudentParentsQuery, List<StudentParentsListVm>>
    {
        private readonly IApplicationRepo _repo;
        private readonly IMapper _mapper;

        public GetAllStudentParentsQueryHandler(IApplicationRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<RespDto<List<StudentParentsListVm>>> Handle(GetAllStudentParentsQuery request, CancellationToken cancellationToken)
        {
            var studentParents = await _repo.StudentParentRepo.GetAllStudentParents();
            return _mapper.Map <RespDto<List<StudentParentsListVm>>>(studentParents);
        }
    }
}
