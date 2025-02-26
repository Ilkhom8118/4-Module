using System.ComponentModel.DataAnnotations;

namespace CarRendalSystem.Bll.DTOs
{
    public class BookingCreateDto
    {
        public long CarId { get; set; }
        public long CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalCost { get; set; }
    }
}
