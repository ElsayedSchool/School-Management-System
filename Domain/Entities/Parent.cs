using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Parent
    {
        public Parent()
        {
            this.Childern = new HashSet<StudentParent>();
        }

        public int ParentId { get; set; }
        public string UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get => FirstName + " " + LastName;
        }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<StudentParent> Childern { get; set; }


    }
}
