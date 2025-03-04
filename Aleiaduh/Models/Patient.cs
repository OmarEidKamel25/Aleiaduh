using System;
using System.Collections.Generic;

namespace Aleiaduh.Models;

public partial class Patient
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Testimonial> Testimonials { get; set; } = new List<Testimonial>();
}
