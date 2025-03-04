using System;
using System.Collections.Generic;

namespace Aleiaduh.Models;

public partial class Doctor
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Email { get; set; } = null!;

    public string? Phone { get; set; }

    public int? DepartmentId { get; set; }

    public string? ImageURL { get; set; }
    public string? FacebookURL { get; set; }
    public string? TwitterURL { get; set; }
    public string? InstagramURL { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Department? Department { get; set; }
}
