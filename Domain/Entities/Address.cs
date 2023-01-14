
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Address
    {
        public int AddressId { get; set; }
        public string PostalCode { get; set; }
        public string AddressDetails { get; set; }
        
        public int? RegionId { get; set; }
        public virtual Region Region { get; set; }

        public virtual UserProfile User { get; set; }
    }
}
