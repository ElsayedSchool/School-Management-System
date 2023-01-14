using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserProfile
    {
        public UserProfile()
        {
            this.DirectReports = new HashSet<UserProfile>();
        }
        public int UserProfileId { get; set; }
        public string? UserId { get; set; }

        // data to be changed by application admin
        //public CourtesyTitles? TitleOfCourtesy { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string FullName
        {
            get => FirstName + " " + LastName;
        }
        public string JobTitle { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? ReleaseDate { get; set; }

        public int? ReportsTo { get; set; }

        // personal data to be changed by person
        public byte[]? Photo { get; set; }
        public string? PhotoPath { get; set; }
        public DateTime? BirthDate { get; set; }


        public virtual UserProfile Manager { get; set; }
        public virtual Address Address { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<UserProfile> DirectReports { get; private set; }
    }
}
