using Application.Common.Mediatr;
using Domain.Entities;

namespace Application.ExamApp
{
    
    public class UpsertExamCommand : IRequestWrapper<bool>
    {
        public int Id { get; set; }
        public string OverView { get; set; }
        public int ClassId { get; set; }
        public int? SessionId { get; set; }
        public DateTime? Date { get; set; }
        public int TotalDegree { get; set; }
    }
}
