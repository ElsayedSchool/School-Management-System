using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using Domain.Entities;

namespace Application.GroupApp
{
    public class UpsertGroupCommandHandler : IRequestHandler<UpsertGroupCommand, bool>
    {
        private readonly IApplicationRepo _repo;

        public UpsertGroupCommandHandler(IApplicationRepo repo)
        {
            _repo = repo;
        }


        public async Task<RespDto<bool>> Handle(UpsertGroupCommand request, CancellationToken cancellationToken)
        {
            Group? group;
            var isBranchExist = await _repo.BranchRepo.HasAnyWithMessage(p => p.BranchId == request.BranchId);
            if (isBranchExist == null || isBranchExist.Data == false) return isBranchExist;

            var isGradeExist = await _repo.CategoryRepo.HasAnyWithMessage(p => p.CategoryId == request.GradeId);
            if (isGradeExist == null || isGradeExist.Data == false) return isGradeExist;

            if (request.Id != 0)
            {
                var storedGroup = await _repo.GroupRepo.FindByIdAsync(request.Id);
                if (storedGroup == null || storedGroup?.Data == null || storedGroup?.Error == true) return storedGroup.GetNotFoundError("Group");
                group = storedGroup?.Data;
                
            }else
            {
                group = new Group();
                await _repo.GroupRepo.CreateAsync(group);
            }

            group.GroupName = request.GroupName;
            group.Studentpayment = request.StudentPayment;
            group.BranchId = request.BranchId;
            group.GradeId = request.GradeId;

            await _repo.Commit();
            return new RespDto<bool>() { Data = true };
        }
    }
}
