using Application.Common.Mediatr;
using Domain.Entities;
using Domain.Enums;

namespace Application.ProfileApp
{
    
    public class UpdatePersonalCommand : IRequestWrapper<bool>
    {
        public int Id { get; set; }
        public byte[]? Photo { get; set; }
        public string? PhotoPath { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
