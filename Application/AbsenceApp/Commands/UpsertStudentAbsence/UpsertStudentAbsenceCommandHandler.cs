using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.StudentAbsenceApp
{
    public class UpsertStudentAbsenceCommandHandler : IRequestHandler<UpsertStudentAbsenceCommand, bool>
    {
        private readonly IApplicationRepo _repo;

        public UpsertStudentAbsenceCommandHandler(IApplicationRepo repo)
        {
            _repo = repo;
        }


        public async Task<RespDto<bool>> Handle(UpsertStudentAbsenceCommand request, CancellationToken cancellationToken)
        {
            var isExist = await _repo.AbsenceRepo.HasAny(p => p.StudentId == request.StudentId && p.SessionId == request.SessionId);

            var isStudentExist = await _repo.StudentRepo.HasAnyWithMessage(p=> p.StudentId == request.StudentId);
            if (isStudentExist == null || isStudentExist.Data == null || isStudentExist.Error == true) return isStudentExist.GetNotFoundError("Student");

            var isSessionExist = await _repo.SessionRepo.HasAnyWithMessage(p=> p.SessionId == request.SessionId);
            if (isSessionExist == null || isSessionExist.Data == null || isSessionExist.Error == true) return isSessionExist.GetNotFoundError("Group");

            StudentAbsence? StudentAbsence;
            if (request.Id != 0)
            {
                var UpdateParentdSub = await _repo.AbsenceRepo.FindByIdAsync(request.Id);
                if (UpdateParentdSub == null || UpdateParentdSub.Data == null || UpdateParentdSub.Error == true) return UpdateParentdSub.GetNotFoundError("Parent Subscription");
                StudentAbsence = UpdateParentdSub?.Data;
                if (!isExist)
                {
                    StudentAbsence.SessionId = request.SessionId;
                    StudentAbsence.StudentId = request.StudentId;
                    StudentAbsence.IsSick = request.IsSick;
                }
            }
            else
            {
                if (isExist)
                {
                    return new RespDto<bool>().Get400Error("Student Absence is already recoreded");
                }
                
                StudentAbsence = new StudentAbsence() { StudentId = request.StudentId, SessionId = request.SessionId, IsSick = request.IsSick};
                await _repo.AbsenceRepo.CreateAsync(StudentAbsence);
            }


            await _repo.Commit();
            return new RespDto<bool>() { Data = true };
        }
    }
}
