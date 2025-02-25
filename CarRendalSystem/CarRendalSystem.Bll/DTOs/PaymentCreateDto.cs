using CarRendalSystem.Dal.Entities;
using CarRendalSystem.Dal.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRendalSystem.Bll.DTOs
{
    public class PaymentCreateDto
    {
        public long BookingId { get; set; }
        public double Amount { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}
