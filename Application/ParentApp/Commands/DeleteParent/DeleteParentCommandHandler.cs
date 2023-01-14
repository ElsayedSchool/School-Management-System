using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ParentApp
{
    public class DeleteParentCommandHandler : IRequestHandler<DeleteParentCommand, bool>
    {
        private readonly IApplicationRepo _repo;

        public DeleteParentCommandHandler(IApplicationRepo repo)
        {
            _repo = repo;
        }

        public async Task<RespDto<bool>> Handle(DeleteParentCommand request, CancellationToken cancellationToken)
        {
            return await _repo.ParentRepo.DeleteAsync(request.Id);
        }
    }
}
