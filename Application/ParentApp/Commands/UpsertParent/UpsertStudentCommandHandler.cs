using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ParentApp
{
    public class UpsertParentCommandHandler : IRequestHandler<UpsertParentCommand, bool>
    {
        private readonly IApplicationRepo _repo;

        public UpsertParentCommandHandler(IApplicationRepo repo)
        {
            _repo = repo;
        }


        public async Task<RespDto<bool>> Handle(UpsertParentCommand request, CancellationToken cancellationToken)
        {
            Parent? parent;

            if (request.Id != 0)
            {
                var modifiedParent = await _repo.ParentRepo.FindByIdAsync(request.Id);
                if (modifiedParent == null || modifiedParent?.Data == null || modifiedParent?.Error == true) return modifiedParent.GetNotFoundError("This Branch Data is not Exist");
                parent = modifiedParent?.Data;
            }else
            {
                parent = new Parent();
                await _repo.ParentRepo.CreateAsync(parent);
            }

            parent.FirstName = request.FirstName;
            parent.LastName = request.LastName;
            parent.Phone = request.Phone;
            parent.Email = request.Email;

            await _repo.Commit();
            return new RespDto<bool>() { Data = true };
        }
    }
}
