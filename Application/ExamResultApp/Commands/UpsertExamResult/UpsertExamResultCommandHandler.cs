using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ExamResultApp
{
    public class UpsertExamResultCommandHandler : IRequestHandler<UpsertExamResultCommand, bool>
    {
        private readonly IApplicationRepo _repo;

        public UpsertExamResultCommandHandler(IApplicationRepo repo)
        {
            _repo = repo;
        }


        public async Task<RespDto<bool>> Handle(UpsertExamResultCommand request, CancellationToken cancellationToken)
        {


            ExamResult? ExamResult;

            if (request.StudentId != 0 && request.ExamId != 0)
            {
                var modifiedExamResult = await _repo.ExamResultRepo.FindAllAsync(p => p.StudentId == request.StudentId && p.ExamId == request.ExamId);
                if (modifiedExamResult == null || modifiedExamResult?.Data.Count() > 0 || modifiedExamResult?.Error == true) return modifiedExamResult.GetNotFoundError("Exam");
                ExamResult = modifiedExamResult?.Data.SingleOrDefault();
            }else
            {
                ExamResult = new ExamResult() { ExamId = request.ExamId, StudentId = request.StudentId};
                await _repo.ExamResultRepo.CreateAsync(ExamResult);
            }

            ExamResult.Score = request.Score;

            await _repo.Commit();
            return new RespDto<bool>() { Data = true };
        }
    }
}
