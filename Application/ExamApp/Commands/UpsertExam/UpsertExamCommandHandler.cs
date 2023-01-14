using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ExamApp
{
    public class UpsertExamCommandHandler : IRequestHandler<UpsertExamCommand, bool>
    {
        private readonly IApplicationRepo _repo;

        public UpsertExamCommandHandler(IApplicationRepo repo)
        {
            _repo = repo;
        }


        public async Task<RespDto<bool>> Handle(UpsertExamCommand request, CancellationToken cancellationToken)
        {
            var isClassExist = await _repo.ClassRepo.HasAnyWithMessage(p => p.ClassId == request.ClassId);
            if (isClassExist == null || isClassExist.Data == null || isClassExist.Error == true) return isClassExist.GetNotFoundError("Class");

            if(request.SessionId != null)
            {
                var isSessionExist = await _repo.SessionRepo.HasAnyWithMessage(p => p.SessionId == request.SessionId);
                if (isSessionExist == null || isSessionExist.Data == null || isSessionExist.Error == true) return isSessionExist.GetNotFoundError("Session");
            }
            

            Exam? exam;

            if (request.Id != 0)
            {
                var modifiedExam = await _repo.ExamRepo.FindByIdAsync(request.Id);
                if (modifiedExam == null || modifiedExam?.Data == null || modifiedExam?.Error == true) return modifiedExam.GetNotFoundError("Exam");
               exam = modifiedExam?.Data;
            }else
            {
               exam = new Exam();
                await _repo.ExamRepo.CreateAsync(exam);
            }

           
            exam.OverView = request.OverView;
            exam.Date = request.Date;
            exam.TotalDegree = request.TotalDegree;
            exam.ClassId = request.ClassId;
            exam.SessionId = request.SessionId;

            await _repo.Commit();
            return new RespDto<bool>() { Data = true };
        }
    }
}
