using Application.Common.Mediatr;
using Domain.Entities;

namespace Application.HallApp{
    
    public class UpsertHallCommand : IRequestWrapper<bool>
    {
        public int Id { get; set; }
        public string HallName { get; set; }
        public int MaxStudents { get; set; }
        public bool IsConditioned { get; set; }
        public double PricePerStudent { get; set; }
        public double PricePerHour { get; set; }
        public double MinReservationTime { get; set; }
        public double HourEquivalentTime { get; set; }
        public int BranchId { get; set; }
    }
}
