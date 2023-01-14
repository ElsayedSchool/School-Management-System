using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class City
    {
        public City()
        {
            this.Regions = new HashSet<Region>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public string? EnglishName { get; set; }
        public int CountryId { get; set; }

        public virtual ICollection<Region> Regions { get; set; }
    }
}
