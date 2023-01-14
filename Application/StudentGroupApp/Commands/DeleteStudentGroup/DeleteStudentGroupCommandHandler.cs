using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;

namespace Application.StudentGroupApp
{
    public class DeleteStudentGroupCommandHandler : IRequestHandler<DeleteStudentGroupCommand, bool>
    {
        private readonly IApplicationRepo _repo;

        public DeleteStudentGroupCommandHandler(IApplicationRepo repo)
        {
            _repo = repo;
        }

        public async Task<RespDto<bool>> Handle(DeleteStudentGroupCommand request, CancellationToken cancellationToken)
        {
            return await _repo.StudentGroupRepo.DeleteAsync(request.Id);
        }
    }
}
