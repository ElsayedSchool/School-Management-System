using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HallApp{
    public class DeleteHallCommandHandler : IRequestHandler<DeleteHallCommand, bool>
    {
        private readonly IApplicationRepo _repo;

        public DeleteHallCommandHandler(IApplicationRepo repo)
        {
            _repo = repo;
        }

        public async Task<RespDto<bool>> Handle(DeleteHallCommand request, CancellationToken cancellationToken)
        {
            return await _repo.HallRepo.DeleteAsync(request.Id);
        }
    }
}
