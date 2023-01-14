using Application.Common.Mediatr;
using Domain.Entities;

namespace Application.ParentApp
{
    
    public class UpsertParentCommand : IRequestWrapper<bool>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
