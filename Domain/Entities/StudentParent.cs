namespace Domain.Entities
{
    public class StudentParent
    {
        public int StudentParentId { get; set; }
        public bool IsApproved { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        public int ParentId { get; set; }
        public virtual Parent Parent { get; set; }
    }
}