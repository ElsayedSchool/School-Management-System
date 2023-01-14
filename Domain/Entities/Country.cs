using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Country
    {
        public Country()
        {
            this.Cities = new HashSet<City>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string? EnglishName { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
