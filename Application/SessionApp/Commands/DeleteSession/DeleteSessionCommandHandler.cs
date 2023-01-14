
using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SessionApp
{
    public class DeleteSessionCommandHandler : IRequestHandler<DeleteSessionCommand, bool>
    {
        private readonly IApplicationRepo _repo;

        public DeleteSessionCommandHandler(IApplicationRepo repo)
        {
            _repo = repo;
        }

        public async Task<RespDto<bool>> Handle(DeleteSessionCommand request, CancellationToken cancellationToken)
        {
            return await _repo.SessionRepo.DeleteAsync(request.Id);
        }
    }
}
