using Application.Common.Mediatr;
using Domain.Entities;

namespace Application.ExamResultApp
{
    
    public class UpsertExamResultCommand : IRequestWrapper<bool>
    {
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public int Score { get; set; }
    }
}
