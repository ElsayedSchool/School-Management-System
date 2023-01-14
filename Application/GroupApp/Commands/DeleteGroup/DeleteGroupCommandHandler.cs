using Application.GroupApp;
using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.GroupApp
{
    public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommand, bool>
    {
        private readonly IApplicationRepo _repo;

        public DeleteGroupCommandHandler(IApplicationRepo repo)
        {
            _repo = repo;
        }

        public async Task<RespDto<bool>> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {
            return await _repo.GroupRepo.DeleteAsync(request.Id);
        }
    }
}
