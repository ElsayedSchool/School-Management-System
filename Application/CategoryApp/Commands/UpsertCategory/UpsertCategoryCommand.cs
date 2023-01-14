using Application.Common.Mediatr;
using Domain.Entities;

namespace Application.CategoryApp{
    
    public class UpsertCategoryCommand : IRequestWrapper<bool>
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string? EnglishName { get; set; }
        public int ParentCategoryId { get; set; }
    }
}
