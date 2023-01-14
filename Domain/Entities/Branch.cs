using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Branch
    {
        public Branch()
        {
            this.Employees = new List<Employee>();
            this.Halls = new List<Hall>();
            this.Groups = new List<Group>();
        }


        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string BranchDesc { get; set; }
        public string? Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public string? Email { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public int CityId { get; set; }
        public virtual City City { get; set; }

        public int RegionId { get; set; }
        public virtual Region Region { get; set; }

        public string Street { get; set; }
        public string AddressDesc { get; set; }
        public string EnglishDesc { get; set; }

        public int CenterId { get; set; }
        public virtual Center Center { get; set; }

        public virtual ICollection<Hall> Halls { get; private set; }
        public virtual ICollection<Employee> Employees { get; private set; }
        public virtual ICollection<Group> Groups { get; private set; }
    }
}
