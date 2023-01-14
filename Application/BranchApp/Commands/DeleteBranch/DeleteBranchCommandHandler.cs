using Application.BranchApp;
using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BranchApp
{
    public class DeleteBranchCommandHandler : IRequestHandler<DeleteBranchCommand, bool>
    {
        private readonly IApplicationRepo _repo;

        public DeleteBranchCommandHandler(IApplicationRepo repo)
        {
            _repo = repo;
        }

        public async Task<RespDto<bool>> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
        {
            return await _repo.BranchRepo.DeleteAsync(request.Id);
        }
    }
}
