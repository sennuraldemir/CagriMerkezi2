using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CagriMerkezi2.Models
{
    public class ApplicationUser :IdentityUser
    {

        [Required]

        public int TC { get; set; }

        public string? Ad { get; set; }

        public string? Soyad { get; set; }  
    }
}
