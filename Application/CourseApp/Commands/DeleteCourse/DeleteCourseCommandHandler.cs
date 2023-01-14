using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CourseApp{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, bool>
    {
        private readonly IApplicationRepo _repo;

        public DeleteCourseCommandHandler(IApplicationRepo repo)
        {
            _repo = repo;
        }

        public async Task<RespDto<bool>> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            return await _repo.CourseRepo.DeleteAsync(request.Id);// to check if it is connected or not
        }
    }
}
