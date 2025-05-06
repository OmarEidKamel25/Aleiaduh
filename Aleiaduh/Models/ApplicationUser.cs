using System.ComponentModel.DataAnnotations;
using Aleiaduh.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Aleiaduh.Models
{
    public class ApplicationUser:IdentityUser
    {
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        
    }
}
