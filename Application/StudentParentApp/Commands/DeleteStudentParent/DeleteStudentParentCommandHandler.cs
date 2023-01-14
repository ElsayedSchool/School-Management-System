using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;

namespace Application.StudentParentApp
{
    public class DeleteStudentParentCommandHandler : IRequestHandler<DeleteStudentParentCommand, bool>
    {
        private readonly IApplicationRepo _repo;

        public DeleteStudentParentCommandHandler(IApplicationRepo repo)
        {
            _repo = repo;
        }

        public async Task<RespDto<bool>> Handle(DeleteStudentParentCommand request, CancellationToken cancellationToken)
        {
            return await _repo.StudentParentRepo.DeleteAsync(request.Id);
        }
    }
}
