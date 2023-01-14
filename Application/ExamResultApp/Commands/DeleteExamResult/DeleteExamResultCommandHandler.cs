using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ExamResultApp
{
    public class DeleteExamResultCommandHandler : IRequestHandler<DeleteExamResultCommand, bool>
    {
        private readonly IApplicationRepo _repo;

        public DeleteExamResultCommandHandler(IApplicationRepo repo)
        {
            _repo = repo;
        }

        public async Task<RespDto<bool>> Handle(DeleteExamResultCommand request, CancellationToken cancellationToken)
        {
            return await _repo.ExamResultRepo.DeleteAsync(request.Id);
        }
    }
}
