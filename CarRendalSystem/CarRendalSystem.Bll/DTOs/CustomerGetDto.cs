﻿using CarRendalSystem.Dal.Entities;

namespace CarRendalSystem.Bll.DTOs;

public class CustomerGetDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public ICollection<Booking> Bookings { get; set; }
    public ICollection<Review> Reviews { get; set; }
}
