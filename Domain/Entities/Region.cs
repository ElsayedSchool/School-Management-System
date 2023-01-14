using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Region
    {
        public Region()
        {
            this.Addresses = new HashSet<Address>();
        }

        public int RegionId { get; set; }
        public string RegionName { get; set; }
        public string? EnglishName { get; set; }
        public int CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
