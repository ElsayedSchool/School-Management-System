

namespace Domain.Entities
{
    public class Hall
    {
        public int HallId { get; set; }
        public string HallName { get; set; }
        public int MaxStudents { get; set; }
        public bool IsConditioned { get; set; }
        public double PricePerStudent { get; set; }
        public double PricePerHour { get; set; }
        public double MinReservationTime { get; set; }
        public double HourEquivalentTime { get; set; }


        // realtion
        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
