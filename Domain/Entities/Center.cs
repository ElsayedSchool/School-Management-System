using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Center
    {
        public Center()
        {
            this.Branches = new List<Branch>();
        }
        
        public int CenterId { get; set; }
        public string CenterName { get; set; }
        public string CenterNameInEnglish { get; set; }
        public string OverView { get; set; }
        public bool IsSchoolInstitue { get; set; }
        public bool IsIinitalized { get; set; }
        public DateTime? StartDate { get; set; }
        public string? LogoPhotoPath { get; set; }
        public string? LoginPagePhotoPath { get; set; }

        public string OwnerId { get; set; }


        public virtual ICollection<Branch> Branches { get; private set; }
        public virtual Setting Setting { get; set; }
    }
}
