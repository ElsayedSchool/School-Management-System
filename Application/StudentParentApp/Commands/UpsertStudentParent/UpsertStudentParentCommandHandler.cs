using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.StudentParentApp
{
    public class UpsertStudentParentCommandHandler : IRequestHandler<UpsertStudentParentCommand, bool>
    {
        private readonly IApplicationRepo _repo;

        public UpsertStudentParentCommandHandler(IApplicationRepo repo)
        {
            _repo = repo;
        }


        public async Task<RespDto<bool>> Handle(UpsertStudentParentCommand request, CancellationToken cancellationToken)
        {
            var isExist = await _repo.StudentParentRepo.HasAny(p => p.StudentId == request.StudentId && p.ParentId == request.ParentId);

            var isStudentExist = await _repo.StudentRepo.HasAnyWithMessage(p=> p.StudentId == request.StudentId);
            if (isStudentExist == null || isStudentExist.Data == null || isStudentExist.Error == true) return isStudentExist.GetNotFoundError("Student");

            var isParentExist = await _repo.ParentRepo.HasAnyWithMessage(p=> p.ParentId == request.StudentId);
            if (isParentExist == null || isParentExist.Data == null || isParentExist.Error == true) return isParentExist.GetNotFoundError("Parent");

            StudentParent? studentParent;
            if (request.Id != 0)
            {
                var UpdateParentdSub = await _repo.StudentParentRepo.FindByIdAsync(request.Id);
                if (UpdateParentdSub == null || UpdateParentdSub.Data == null || UpdateParentdSub.Error == true) return UpdateParentdSub.GetNotFoundError("Parent Subscription");
                studentParent = UpdateParentdSub?.Data;
                if (!isExist)
                {
                    studentParent.ParentId = request.ParentId;
                    studentParent.StudentId = request.StudentId;
                }
                studentParent.IsApproved = request.IsApproved;
               
            }
            else
            {
                if (isExist)
                {
                    return new RespDto<bool>().Get400Error("The Parent is already subscripted to its child");
                }
                
                studentParent = new StudentParent() { StudentId = request.StudentId, ParentId = request.ParentId, IsApproved = request.IsApproved};
                await _repo.StudentParentRepo.CreateAsync(studentParent);
            }


            await _repo.Commit();
            return new RespDto<bool>() { Data = true };
        }
    }
}
