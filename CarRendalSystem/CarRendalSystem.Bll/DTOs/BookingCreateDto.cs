using CarRendalSystem.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRendalSystem.Bll.DTOs
{
    public class BookingCreateDto
    {
        public long CustomerId { get; set; }
        public long CarId { get; set; }
        public decimal TotalCost { get; set; }
    }
}
