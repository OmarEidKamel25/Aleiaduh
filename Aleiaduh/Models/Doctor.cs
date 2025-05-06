using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aleiaduh.Models;

public partial class Doctor
{
    public int Id { get; set; }
    [Required(ErrorMessage = "الاسم مطلوب")]
    [MinLength(3,ErrorMessage ="لا يمكن ان تقل الكلمة عن 3 احرف")]
    [MaxLength(50,ErrorMessage ="لا يمكن ان تزيد الكلمه عن 50 حرف")]
    public string Name { get; set; } = null!;

    public string? Email { get; set; } = null!;

    public string? Phone { get; set; }

    public int? DepartmentId { get; set; }

    public string? ImageURL { get; set; }
    public string? FacebookURL { get; set; }
    public string? TwitterURL { get; set; }
    public string? InstagramURL { get; set; }
    [ValidateNever]
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    [ValidateNever]
    public virtual Department? Department { get; set; }
}
