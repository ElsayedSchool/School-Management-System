

using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Group
    {
        public Group()
        {
            this.Classes = new List<Class>();
            /*this.Studnets = new List<GroupStudent>();*/
        }


        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int Studentpayment { get; set; }


        // relation
        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }

        public int GradeId { get; set; }
        public virtual Category Grade { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
        /*public ICollection<GroupStudent> Studnets { get; set; }*/
    }
}
