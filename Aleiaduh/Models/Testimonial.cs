using System;
using System.Collections.Generic;

namespace Aleiaduh.Models;

public partial class Testimonial
{
    public int Id { get; set; }

    public int? PatientId { get; set; }

    public string? Comment { get; set; }

    public int? Rating { get; set; }

    public virtual Patient? Patient { get; set; }
}
