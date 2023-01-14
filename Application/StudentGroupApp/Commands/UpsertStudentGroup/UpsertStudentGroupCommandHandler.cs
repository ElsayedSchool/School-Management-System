using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.StudentGroupApp
{
    public class UpsertStudentGroupCommandHandler : IRequestHandler<UpsertStudentGroupCommand, bool>
    {
        private readonly IApplicationRepo _repo;

        public UpsertStudentGroupCommandHandler(IApplicationRepo repo)
        {
            _repo = repo;
        }


        public async Task<RespDto<bool>> Handle(UpsertStudentGroupCommand request, CancellationToken cancellationToken)
        {
            var isExist = await _repo.StudentGroupRepo.HasAny(p => p.StudentId == request.StudentId && p.GroupId == request.GroupId);

            var isStudentExist = await _repo.StudentRepo.HasAnyWithMessage(p=> p.StudentId == request.StudentId);
            if (isStudentExist == null || isStudentExist.Data == null || isStudentExist.Error == true) return isStudentExist.GetNotFoundError("Student");

            var isGroupExist = await _repo.GroupRepo.HasAnyWithMessage(p=> p.GroupId == request.GroupId);
            if (isGroupExist == null || isGroupExist.Data == null || isGroupExist.Error == true) return isGroupExist.GetNotFoundError("Group");

            StudentGroup? studentGroup;
            if (request.Id != 0)
            {
                var UpdateParentdSub = await _repo.StudentGroupRepo.FindByIdAsync(request.Id);
                if (UpdateParentdSub == null || UpdateParentdSub.Data == null || UpdateParentdSub.Error == true) return UpdateParentdSub.GetNotFoundError("Parent Subscription");
                studentGroup = UpdateParentdSub?.Data;
                if (!isExist)
                {
                    studentGroup.GroupId = request.GroupId;
                    studentGroup.StudentId = request.StudentId;
                }
            }
            else
            {
                if (isExist)
                {
                    return new RespDto<bool>().Get400Error("The Group is already subscripted to its child");
                }
                
                studentGroup = new StudentGroup() { StudentId = request.StudentId, GroupId = request.GroupId, JoinDate = DateTime.Now};
                await _repo.StudentGroupRepo.CreateAsync(studentGroup);
            }


            await _repo.Commit();
            return new RespDto<bool>() { Data = true };
        }
    }
}
