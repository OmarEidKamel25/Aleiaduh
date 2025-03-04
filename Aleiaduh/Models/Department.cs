﻿using System;
using System.Collections.Generic;

namespace Aleiaduh.Models;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
