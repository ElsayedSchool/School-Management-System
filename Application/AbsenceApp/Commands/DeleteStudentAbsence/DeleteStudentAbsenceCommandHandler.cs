using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;

namespace Application.StudentAbsenceApp
{
    public class DeleteStudentAbsenceCommandHandler : IRequestHandler<DeleteStudentAbsenceCommand, bool>
    {
        private readonly IApplicationRepo _repo;

        public DeleteStudentAbsenceCommandHandler(IApplicationRepo repo)
        {
            _repo = repo;
        }

        public async Task<RespDto<bool>> Handle(DeleteStudentAbsenceCommand request, CancellationToken cancellationToken)
        {
            return await _repo.AbsenceRepo.DeleteAsync(request.Id);
        }
    }
}
