
using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ClassApp
{
    public class DeleteClassCommandHandler : IRequestHandler<DeleteClassCommand, bool>
    {
        private readonly IApplicationRepo _repo;

        public DeleteClassCommandHandler(IApplicationRepo repo)
        {
            _repo = repo;
        }

        public async Task<RespDto<bool>> Handle(DeleteClassCommand request, CancellationToken cancellationToken)
        {
            return await _repo.ClassRepo.DeleteAsync(request.Id);
        }
    }
}
