using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;

namespace Application.CategoryCourseApp
{
    public class DeleteCategoryCourseCommandHandler : IRequestHandler<DeleteCategoryCourseCommand, bool>
    {
        private readonly IApplicationRepo _repo;

        public DeleteCategoryCourseCommandHandler(IApplicationRepo repo)
        {
            _repo = repo;
        }

        public async Task<RespDto<bool>> Handle(DeleteCategoryCourseCommand request, CancellationToken cancellationToken)
        {
            return await _repo.CategoryCourseRepo.DeleteAsync(request.Id);
        }
    }
}
